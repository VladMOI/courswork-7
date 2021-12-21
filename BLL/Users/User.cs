using System;
using System.Collections.Generic;

namespace BLL
{
    public class User
    {
        public string firstName;
        public string lastName;
        public string groupName;
        public int docCount = 0;
        public List<Doc> docArray;


        public User(string fname, string lname, string gname )
        {
            firstName = fname;
            lastName = lname;
            groupName = gname;
        }

        public string AddDocument(Doc doc)
        {
            if (docCount < 5)
            {
                docArray = new List<Doc>();
                docArray.Add(doc);
                docCount++;
                return "200";
            }
            else
            {
                return "500";
            }
        }

        public string GetUserInfo()
        {
            return $"{firstName} {lastName} группа {groupName} документы: {docCount}, список: {docArray}";
        }
        
        public string GetFirstName()
        {
            return firstName;
        }
        public string GetLastName()
        {
            return lastName;
        }

        public string GetGroupName()
        {
            return groupName;
        }

        public int GetDocCount()
        {
            return docCount;
        }

        public List<Doc> GetDocArray()
        {
            return docArray;
        }
    }
}