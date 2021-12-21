using System.Collections.Generic;
using DAL;
using Newtonsoft.Json;

namespace BLL
{
    public class DocControl
    {
        private localdb _localdb = new localdb();

        public string AttachUser(string fname, string lname, string group, string dname, string author)
        {
            string status;
            User userToAttach;
            Doc docToAttach;
            //finding user
            string currentDatauser = _localdb.ReadStudentDB();
            List<User> userAdapter = JsonConvert.DeserializeObject<List<User>>(currentDatauser);
            for (int i = 0; i < userAdapter.Count; i++)
            {
                User currentUser = userAdapter[i];
                if (currentUser.GetFirstName() == fname && currentUser.GetLastName() == lname &&
                    currentUser.GetGroupName() == group)
                {
                    status = "200";
                    userToAttach = userAdapter[i];
                    //finding document            
                    string currentDataDoc = _localdb.ReadDocsDB();
                    List<Doc> DocAdapter = JsonConvert.DeserializeObject<List<Doc>>(currentDataDoc);
                    for (int j = 0; j < DocAdapter.Count; j++)
                    {
                        Doc currentDoc = DocAdapter[j];
                        if (currentDoc.GetDocName() == dname && currentDoc.GetDocAuthor() == author)
                        {
                            docToAttach =new Doc(dname, author);
                            string currentUserName = currentUser.GetFirstName();
                            string currentUserLastName = currentUser.GetLastName();
                            string currentUserGroup = currentUser.GetGroupName();
                            User userToAdd = new User(currentUserName, currentUserLastName, currentUserGroup);
                            userAdapter.RemoveAt(i);
                            userToAdd.AddDocument(docToAttach);
                            userAdapter.Add(userToAdd);

                        }
                    }
                }
            }
            return "501";
        }
    }
}