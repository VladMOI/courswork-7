using System;
using System.IO;

namespace DAL
{
    public class localdb
    {
        private string PATH_TO_LOCALDB = @"C:\LocalDBCursWork";
        private string PATH_TO_SAVE_USER = @"\users-db.txt";
        private string PATH_TO_SAVE_DOC = @"\docs-db.txt";

        public localdb()
        {
            if (!Directory.Exists(PATH_TO_LOCALDB))
            {
                Directory.CreateDirectory(@"C:\LocalDBCursWork");
                if (!File.Exists(PATH_TO_LOCALDB + PATH_TO_SAVE_USER))
                {
                    File.Create(PATH_TO_LOCALDB + PATH_TO_SAVE_USER);
                }
                if (!File.Exists(PATH_TO_LOCALDB + PATH_TO_SAVE_DOC))
                {
                    File.Create(PATH_TO_LOCALDB + PATH_TO_SAVE_DOC);
                }
            }
            
        }

        public void CreateUserDB(string objToWrite)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(PATH_TO_LOCALDB + PATH_TO_SAVE_USER, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(objToWrite);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void CreateDocsDB(string objToWrite)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(PATH_TO_LOCALDB + PATH_TO_SAVE_DOC, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(objToWrite);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string ReadStudentDB()
        {
            try
            {
                using (StreamReader sr = new StreamReader(PATH_TO_LOCALDB + PATH_TO_SAVE_USER))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public  string ReadDocsDB()
        {
            try
            {
                using (StreamReader sr = new StreamReader(PATH_TO_LOCALDB + PATH_TO_SAVE_DOC))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}