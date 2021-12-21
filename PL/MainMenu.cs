using System;
using System.Configuration;
using BLL;
using DAL;
using static System.Console;

namespace PL
{
    public class MainMenu 
    {
        public void MessageHandler()
        {
            localdb db = new localdb();
            Users users = new Users();
            Docs docs = new Docs();
            DocControl docControl = new DocControl();
            Search search = new Search();
            char message;
            WriteLine("Главное меню:");
            WriteLine("1 - Пользователи\n2 - Документы\n3 - Управление документами\n4 - Поиск");
            message = ReadLine()[0];
            if (IsValid(message, 4))//if message is num & <= 4 
            {
                switch (ToInteger(message.ToString()))
                {
                    case 1://users
                        Clear();
                        WriteLine("Пользователи:");
                        WriteLine("1 - Новый пользователь\n2 - Удалить пользователя\n3 - Редактировать пользователя\n4 - Поиск пользователя\n5 - Все пользователи\n6 - Назад");
                        message = ReadLine()[0];
                        if (IsValid(message, 6))
                        {
                            switch(ToInteger(message.ToString()))
                            {
                                case 1:
                                    Clear();
                                    WriteLine("Новый пользователь:");
                                    Write("Имя: ");
                                    string firtsName = ReadLine();
                                    Write("Фамилия: ");
                                    string lastName = ReadLine();
                                    Write("Группа: ");
                                    string groupName = ReadLine();
                                    
                                    users.NewUser(firtsName, lastName, groupName);
                                    Clear();
                                    MessageHandler();
                                    break;
                                case 2:
                                    Clear();
                                    WriteLine("Удалить пользователя:");
                                    Write("Имя: ");
                                    string firtsNameDel = ReadLine();
                                    Write("Фамилия: ");
                                    string lastNameDel = ReadLine();
                                    Write("Группа: ");
                                    string groupNameDel = ReadLine();


                                    string status = users.DeleteUser(firtsNameDel, lastNameDel, groupNameDel);
                                    if (status == "200")
                                    {
                                        Console.WriteLine("Пользователь удалён. Введите любой символ чтобы продолжить");
                                        Console.ReadLine();
                                        Clear();
                                        MessageHandler();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Пользователь не найден. Введите любой символ чтобы продолжить");
                                        Console.ReadLine();
                                        Clear();
                                        MessageHandler();                                    }
                                    break;
                                case 3:
                                    Clear();
                                    WriteLine("Редактировать пользователя:");
                                    Write("Имя: ");
                                    string firtsNameEdit = ReadLine();
                                    Write("Фамилия: ");
                                    string lastNameEdit = ReadLine();
                                    Write("Группа: ");
                                    string groupNameEdit = ReadLine();

                                    if (users.IsUserExists(firtsNameEdit, lastNameEdit, groupNameEdit))
                                    {
                                        WriteLine("Пользователь найден, введите новые данные: ");
                                        Write("Новое имя: ");
                                        string newFirtsNameEdit = ReadLine();
                                        Write("Новая фамилия: ");
                                        string newLastNameEdit = ReadLine();
                                        Write("Новая группа: ");
                                        string newGroupNameEdit = ReadLine();
                                        string result_edit = users.EditUser(firtsNameEdit, lastNameEdit, groupNameEdit, newFirtsNameEdit , newLastNameEdit, newGroupNameEdit);
                                        if (result_edit == "200")
                                        {
                                            WriteLine("Пользователь изменён. Введите любой символ чтобы продолжить");
                                            ReadLine();
                                            Clear();
                                            MessageHandler();                                         
                                        }
                                        else
                                        {
                                            WriteLine("Пользователь не найден. Введите любой символ чтобы продолжить");
                                            ReadLine();
                                            Clear();
                                            MessageHandler(); 
                                        }
                                        
                                    }
                                    else
                                    {
                                        WriteLine("Пользователь не найден. Введите любой символ чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler(); 
                                    }
                                    Clear();
                                    MessageHandler();
                                    break;
                                case 4:
                                    Clear();
                                    WriteLine("Поиск пользователя:");
                                    Write("Имя: ");
                                    string firtsNameSearch = ReadLine();
                                    Write("Фамилия: ");
                                    string lastNameDelSearch = ReadLine();
                                    Write("Группа: ");
                                    string groupNameDelSearch = ReadLine();

                                    if (users.IsUserExists(firtsNameSearch, lastNameDelSearch, groupNameDelSearch))
                                    {
                                        WriteLine("Найден пользователь: " + users.GetUserInfo(firtsNameSearch, lastNameDelSearch, groupNameDelSearch));
                                        WriteLine("Введите любой символ чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler();  
                                    }
                                    else
                                    {
                                        WriteLine("Пользователь не найден. Введите любой символ чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler(); 
                                    }
                                    break;
                                case 5:
                                    Clear();
                                    WriteLine("Все пользователи: ");
                                    users.ShowAll();
                                    WriteLine("1 - Сортировка по имени\n2 - Сортировка по фамилии\n3 - Сортировка по группе\n4 - Назад");
                                    message = ReadLine()[0];
                                    if (IsValid(message, 4))
                                    {
                                        switch (message.ToString())
                                        {
                                            case "1":
                                                WriteLine(users.SortByName());
                                                WriteLine("Введите любой символ чтобы продолжить");
                                                ReadLine();
                                                Clear();
                                                MessageHandler();
                                                break;
                                            case "2":
                                                WriteLine(users.SortByLastName());
                                                WriteLine("Введите любой символ чтобы продолжить");
                                                ReadLine();
                                                Clear();
                                                MessageHandler();
                                                break;
                                            case "3":
                                                WriteLine(users.SortByGroup());
                                                WriteLine("Введите любой символ чтобы продолжить");
                                                ReadLine();
                                                Clear();
                                                MessageHandler();
                                                break;
                                            case "4":
                                                Clear();
                                                MessageHandler();
                                                break;
                                        }
                                    }
                                    ReadLine();
                                    Clear();
                                    MessageHandler();
                                    break;
                                case 6:
                                    Clear();
                                    MessageHandler();
                                    break;
                                default:
                                    WriteLine("Пожалуйста, выберите пункт меню 1 - 6");
                                    MessageHandler();
                                    break;
                            }
                        }
                        else
                        {
                            WriteLine("Пожалуйста, выберите пункт меню 1 - 4");
                            MessageHandler();
                        }
                        break;
                    case 2: //docs
                        WriteLine("Документы:");
                        WriteLine(
                            "1 - Новый документ\n2 - Удалить документ\n3 - Редактировать документ\n4 - Поиск документа\n5 - Все документы\n6 - Назад");
                        message = ReadLine()[0];
                        if (IsValid(message, 6))
                        {
                            switch (message.ToString())
                            {
                                case "1":
                                    Clear();
                                    WriteLine("Новый документ:");
                                    Write("Имя документа:");
                                    string documentName = ReadLine();
                                    Write("Автор:");
                                    string documentAuthor = ReadLine();
                                    
                                    docs.NewDoc(documentName, documentAuthor);
                                    Clear();
                                    MessageHandler();
                                    break;
                                case "2":
                                    Clear();
                                    WriteLine("Удалить документ:");
                                    Write("Имя документа:");
                                    string documentNameDel = ReadLine();
                                    Write("Автор:");
                                    string documentAuthorDel = ReadLine();
                                    string res_delete = docs.DeleteDoc(documentNameDel, documentAuthorDel);
                                    if (res_delete == "200")
                                    {
                                        WriteLine("Документ удалён, нажмите ENTER чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler();
                                    }
                                    else
                                    {
                                        WriteLine("Ошибка при удалении, нажмите ENTER чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler();
                                    }
                                    Clear();
                                    MessageHandler();
                                    break;
                                case "3"://edit doc
                                    Clear();
                                    WriteLine("Редактировать документ:");
                                    Write("Имя документа:");
                                    string documentNameEdit = ReadLine();
                                    Write("Автор:");
                                    string documentAuthorEdit = ReadLine();
                                    if (docs.IsDocExists(documentNameEdit, documentAuthorEdit))
                                    {
                                        WriteLine($"Документ {documentNameEdit} {documentAuthorEdit} найден, введите новые данные:");
                                        Write("Новое имя документа:");
                                        string documentNameEditNew = ReadLine();
                                        Write("Автор:");
                                        string documentAuthorEditNew = ReadLine();
                                        
                                        string res_edit = docs.EditDoc( documentNameEdit, documentAuthorEdit, documentNameEditNew, documentAuthorEditNew);
                                        if (res_edit == "200")
                                        {
                                            WriteLine("Документ изменён, нажмите ENTER чтобы продолжить");
                                            ReadLine();
                                            Clear();
                                            MessageHandler();
                                        }
                                        else
                                        {
                                            WriteLine("Ошибка при изменении, нажмите ENTER чтобы продолжить");
                                            ReadLine();
                                            Clear();
                                            MessageHandler();
                                        }
                                    }
                                    break;
                                case "4"://show doc
                                    Clear();
                                    WriteLine("Поиск документа:");
                                    Write("Имя документа:");
                                    string documentNameShow = ReadLine();
                                    Write("Автор:");
                                    string documentAuthorShow = ReadLine();
                                    if (docs.IsDocExists(documentNameShow, documentAuthorShow))
                                    {
                                        WriteLine($"Документ {documentNameShow} {documentAuthorShow} найден, его полная информация: " + docs.ShowDoc(documentNameShow, documentAuthorShow));
                                        WriteLine("Hажмите ENTER чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler();
                                    }
                                    else
                                    {
                                        WriteLine("Ошибка при поиске, нажмите ENTER чтобы продолжить");
                                        ReadLine();
                                        Clear();
                                        MessageHandler();
                                    }

                                    break;
                                case "5"://all docs
                                    WriteLine("Все документы:");
                                    string all_docs = docs.ShowAll();
                                    WriteLine(all_docs);
                                    WriteLine("1 - Сортировка по имени\n2 - Сортировка по автору\n3 - Назад");
                                    message = ReadLine()[0];
                                    if (IsValid(message, 4))
                                    {
                                        switch (message.ToString())
                                        {
                                            case "1":
                                                WriteLine(docs.SortByName());
                                                WriteLine("Введите любой символ чтобы продолжить");
                                                ReadLine();
                                                Clear();
                                                MessageHandler();
                                                break;
                                            case "2":
                                                WriteLine(docs.SortByAuthor());
                                                WriteLine("Введите любой символ чтобы продолжить");
                                                ReadLine();
                                                Clear();
                                                MessageHandler();
                                                break;
                                            case "3":
                                                WriteLine("Введите любой символ чтобы продолжить");
                                                ReadLine();
                                                Clear();
                                                MessageHandler();
                                                break;
                                        }
                                    }
                                    break;
                                case "6":
                                    break;
                            }
                        }
                        
                        Clear();
                        break;
                    case 3://doc control
                        Clear();
                        WriteLine("Управление документами:");
                        WriteLine("1 - Выдать пользователю документ\n2 - Документы пользователя\n3 - Найти документ\n4 - Вернуть документ\n 5 - Назад");
                        message = ReadLine()[0];
                        if (IsValid(message, 5))
                        {
                            switch (message.ToString())
                            {
                                case "1"://attach
                                    Clear();
                                    WriteLine("Выдача документа пользователю:");
                                    WriteLine("Введите данные кому вы хотите выдать документ");
                                    Write("Имя:");
                                    string stName = ReadLine();
                                    Write("Фамилия:");
                                    string stLastname = ReadLine();
                                    Write("Группа:");
                                    string stGroup = ReadLine();
                                    Clear();
                                    WriteLine("Введите какой документ вы хотитк выдать:");
                                    Write("Название: ");
                                    string docName = ReadLine();
                                    Write("Автор: ");
                                    string docAuthor = ReadLine();

                                    string res_attach = docControl.AttachUser(stName, stLastname, stGroup, docName, docAuthor);
                                    if (res_attach == "200")
                                    {
                                        WriteLine("Документ выдан пользователю");
                                        ReadLine();
                                        Clear();
                                        MessageHandler();
                                    }

                                    break;
                                case "2"://docs by user
                                    break;
                                case "3"://find doc
                                    break;
                                case "4"://take to library
                                    break;
                                case "5"://back
                                    Clear();
                                    MessageHandler();
                                    break;
                            }
                        }
                        
                        MessageHandler();
                        break;
                    case 4:
                        Clear();
                        break;
                    default:
                        WriteLine("Пожалуйста, выберите пункт меню 1 - 4");
                        MessageHandler();
                        break;
                }
            }
            else
            {
                WriteLine("Пожалуйста, выберите пункт меню 1 - 4");
                MessageHandler();
            }

        }

        public bool IsValid(char msg, int n)
        {
            if (IsNumeric(msg.ToString()) && ToInteger(msg.ToString()) <= n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsNumeric(string str)
        {
            int n;
            bool isNumeric = int.TryParse(str, out n);
            return isNumeric;
        }

        public int ToInteger(string str)
        {
            int n;
            int.TryParse(str, out n);
            return n;
        }
    }
}