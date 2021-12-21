namespace BLL
{
    public class Doc
    {
        public string docName;
        public string docAuthor;
        public string attachedUser;

        public Doc(string name, string author)
        {
            this.docName = name;
            this.docAuthor = author;
        }

        public string GetDocInfo()
        {
            return $"Название: {docName}, aвтор: {docAuthor}, выдано пользователю:{attachedUser}";
        }
        
        public string GetDocName()
        {
            return docName;
        }
        public string GetDocAuthor()
        {
            return docAuthor;
        }
        public string GetAttachedUser()
        {
            return attachedUser;
        }
        
        
    }
}