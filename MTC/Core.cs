using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTC.DataBase;
using System.Collections.ObjectModel;

namespace MTC
{
    public class Core
    {
        public static ObservableCollection<User> users { get; set; }
        public static User AuthorizationUser(string login, string password)
        {
            users = new ObservableCollection<User>(bd_connection.connection.User.ToList());
            var userExists = users.Where(user => user.Login == login && user.Password == password).FirstOrDefault();
            if (userExists != null)
            {
                return userExists;
            }
            else
            {
                return userExists;
            }
        }
    }
}
