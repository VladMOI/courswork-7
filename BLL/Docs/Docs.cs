using System;
using System.Collections.Generic;
using DAL;
using Newtonsoft.Json;

namespace BLL
{
    public class Docs
    {
        private localdb _localdb = new localdb();
        public void NewDoc(string docName, string docAuthor)
        {
            string currentData = _localdb.ReadDocsDB();
            if (string.IsNullOrEmpty(currentData))
            {
                List<Doc> adapter = new List<Doc>();
                adapter.Add(new Doc(docName, docAuthor));
                string json =JsonConvert.SerializeObject(adapter, Formatting.Indented);
                _localdb.CreateDocsDB(json);
            }
            else
            {
                List<Doc> docsArray = JsonConvert.DeserializeObject <List<Doc>>(currentData);
                docsArray.Add(new Doc(docName, docAuthor));
                string jsonToSave = JsonConvert.SerializeObject(docsArray, Formatting.Indented);
                _localdb.CreateDocsDB(jsonToSave);
            }
        }

        public string DeleteDoc(string name, string author)
        {
            string currentData = _localdb.ReadDocsDB();
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                if (currentDoc.GetDocName() == name && currentDoc.GetDocAuthor() == author)
                {
                    adapter.RemoveAt(i);
                    string json = JsonConvert.SerializeObject(adapter, Formatting.Indented);
                    _localdb.CreateDocsDB(json);
                    return "200";
                }
            }
            return "500";
        }

        public string EditDoc(string name, string author, string newName, string newAuthor)
        {
            string currentData = _localdb.ReadDocsDB();
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                if (currentDoc.GetDocName() == name && currentDoc.GetDocAuthor() == author)
                {
                    adapter.RemoveAt(i);
                    adapter.Add(new Doc(newName, newAuthor));
                    string json = JsonConvert.SerializeObject(adapter, Formatting.Indented);
                    _localdb.CreateDocsDB(json);
                    return "200";
                }
            }
            return "500";
        }

        public string ShowDoc(string name, string author)
        {
            string currentData = _localdb.ReadDocsDB();
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                if (currentDoc.GetDocName() == name && currentDoc.GetDocAuthor() == author)
                {
                    return currentDoc.GetDocInfo();
                }
            }
            return "500";
        }

        public string ShowAll()
        {
            string currentData = _localdb.ReadDocsDB();
            string allDocsData = "";
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                allDocsData += currentDoc.GetDocInfo();

            }
            return allDocsData;
        }

        public string SortByName()
        {
            string currentData = _localdb.ReadDocsDB();
            string allDocsData = "";
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            adapter.Sort(delegate(Doc x, Doc y) {
                return x.docName.CompareTo(y.docName);
            });
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                allDocsData += currentDoc.GetDocInfo() + "\n";
            }
            return allDocsData;
        }

        public string SortByAuthor()
        {
            string currentData = _localdb.ReadDocsDB();
            string allDocsData = "";
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            adapter.Sort(delegate(Doc x, Doc y) {
                return x.docAuthor.CompareTo(y.docAuthor);
            });
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                allDocsData += currentDoc.GetDocInfo() + "\n";
            }
            return allDocsData;
        }

        public bool IsDocExists(string name, string author)
        {
            string currentData = _localdb.ReadDocsDB();
            List<Doc> adapter = JsonConvert.DeserializeObject<List<Doc>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                Doc currentDoc = adapter[i];
                if (currentDoc.GetDocName() == name && currentDoc.GetDocAuthor() == author)
                {
                    return true;
                }
            }
            return false;
        }
    }
}