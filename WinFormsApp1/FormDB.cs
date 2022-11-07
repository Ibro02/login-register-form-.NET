using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string name, string surname, string userName, string password)
        {
            Name = name;
            Surname = surname;
            UserName = userName;
            Password = password;
        }
        public User()
        {
            Name = "None";
            Surname = "None";
            UserName = "None";
            Password = "None";
        }

    }
    public class FormDB
    {
        public static List<User> users = new List<User> {
            new User()
        {
            Name = "Ibrahim",
                Surname = "Hodzic", 
                UserName = "Ibro02", 
                Password = "321ed"
            }

    };



    //public static List<User> SetList(string name = "", string surname ="", string username = "", string password = "")
    //{
    //    return new List<User>() {
    //        new User()
    //        {
    //            Name = name,
    //            Surname = surname,
    //            UserName = username,
    //            Password = password

    //        }

    //    };
    //}


    public static void AddUser(string name, string surname, string username, string password)
        {

            //SetList(name, surname, username, password);

            users.Add(new User(name,surname,username,password));

        }

        User novi = new User("Ibrahim", "Hodzic", "Ibro02", "321ed");
       
        public User FindUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (username == user.UserName)
                    if (password == user.Password)
                        return user;
            }
            return null;
        }
        
    }
}
