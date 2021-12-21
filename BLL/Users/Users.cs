using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Newtonsoft.Json;

namespace BLL
{
    public class Users
    {
        private localdb _localdb = new localdb();

        public void NewUser(string fname, string lname, string group)
        {
            string currentData = _localdb.ReadStudentDB();
            if (string.IsNullOrEmpty(currentData))
            {
                List<User> adapter = new List<User>();
                adapter.Add(new User(fname, lname, group));
                string json =JsonConvert.SerializeObject(adapter, Formatting.Indented);
                _localdb.CreateUserDB(json);
            }
            else
            {
                List<User> usersArray = JsonConvert.DeserializeObject <List<User>>(currentData);
                usersArray.Add(new User(fname, lname, group));
                string jsonToSave = JsonConvert.SerializeObject(usersArray, Formatting.Indented);
                _localdb.CreateUserDB(jsonToSave);
            }
                
        }

        public string DeleteUser(string fname, string lname, string groupName)
        {
            string currentData = _localdb.ReadStudentDB();
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                if (currentUser.GetFirstName() == fname && currentUser.GetLastName() == lname &&
                    currentUser.GetGroupName() == groupName)
                {
                    Console.WriteLine(200);
                    adapter.RemoveAt(i);
                    string json = JsonConvert.SerializeObject(adapter, Formatting.Indented);
                    _localdb.CreateUserDB(json);
                    return "200";
                }
            }

            return "500";
        }

        public bool IsUserExists(string fname, string lname, string group)
        {
            string currentData = _localdb.ReadStudentDB();
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                if (currentUser.GetFirstName() == fname && currentUser.GetLastName() == lname &&
                    currentUser.GetGroupName() == group)
                {
                    return true;
                }
            }

            return false;
        }
        
        public string EditUser(string fname, string lname, string group, string newFname, string newLname, string newGroup)
        {
            string currentData = _localdb.ReadStudentDB();
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                if (currentUser.GetFirstName() == fname && currentUser.GetLastName() == lname &&
                    currentUser.GetGroupName() == group)
                {
                    adapter.RemoveAt(i);
                    adapter.Add(new User(newFname, newLname, newGroup));
                    string json = JsonConvert.SerializeObject(adapter, Formatting.Indented);
                    _localdb.CreateUserDB(json);
                    return "200";
                }
            }

            return "500";
        }

        public string GetUserInfo(string fname, string lname, string group)
        {
            string currentData = _localdb.ReadStudentDB();
            string res;
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                if (currentUser.GetFirstName() == fname && currentUser.GetLastName() == lname &&
                    currentUser.GetGroupName() == group)
                {
                    res = $"{currentUser.GetFirstName()} {currentUser.GetLastName()} группа {currentUser.GetGroupName()} документы: {currentUser.GetDocCount()}, список: {currentUser.GetDocArray()}";
                    
                    return res;
                }
            }

            return "500";        }

        public string ShowAll()
        {
            string currentData = _localdb.ReadStudentDB();
            string allUsersInfo = "";
            
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            foreach (var currentUser in adapter)
            {
                allUsersInfo += currentUser.GetUserInfo();
            }
            return allUsersInfo;
        }
        public string SortByName()
        {
            string currentData = _localdb.ReadStudentDB();
            string allUsersInfo = "";
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            adapter.Sort(delegate(User x, User y) {
                return x.firstName.CompareTo(y.firstName);
            });
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                allUsersInfo += currentUser.GetUserInfo() + "\n";
            }
            return allUsersInfo;
        }

        public string SortByLastName()
        {
            string currentData = _localdb.ReadStudentDB();
            string allUsersInfo = "";
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            adapter.Sort(delegate(User x, User y) { return x.lastName.CompareTo(y.lastName); });
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                allUsersInfo += currentUser.GetUserInfo() + "\n";
            }

            return allUsersInfo;

        }

        public string SortByGroup()
        {
            
            string currentData = _localdb.ReadStudentDB();
            string allUsersInfo = "";
            List<User> adapter = JsonConvert.DeserializeObject<List<User>>(currentData);
            adapter.Sort(delegate(User x, User y) { return x.groupName.CompareTo(y.groupName); });
            for (int i = 0; i < adapter.Count; i++)
            {
                User currentUser = adapter[i];
                allUsersInfo += currentUser.GetUserInfo() + "\n";
            }

            return allUsersInfo;
        }
    }
}