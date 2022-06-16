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

        public static List<Client> GetClient()
        {
            return new List<Client>(bd_connection.connection.Client.ToList());
        }

        public static List<Service> GetServices()
        {
            return new List<Service>(bd_connection.connection.Service.Where(x => x.IsDeleted != true).ToList());
        }

        public static bool AddClient(string name, string tel, string add)
        {
            Client new_client = new Client();
            List<Client> allClient = bd_connection.connection.Client.ToList();
            bool tel_unic = true;
            foreach (var i in allClient)
            {
                if (i.Telephone_Number == tel)
                {
                    tel_unic = false;
                }
            }
            if(tel_unic)
            {
                new_client.FIO = name;
                new_client.Telephone_Number = tel;
                new_client.Regist_Date = DateTime.Now;
                new_client.Addres = add;
                bd_connection.connection.Client.Add(new_client);
                bd_connection.connection.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AddService(string townName, decimal coast, decimal saleCoast)
        {
            Service service = new Service();
            List<Service> allService = bd_connection.connection.Service.Where(x => x.IsDeleted != true).ToList();
            bool uniq_ser = true;
            foreach(var i in allService)
            {
                if(i.Town_Name == townName)
                {
                    uniq_ser = false;
                }
            }
            if(uniq_ser)
            {
                service.Town_Name = townName;
                service.Date = DateTime.Now;
                service.Min_Coast = coast;
                service.Sale_Coast = saleCoast;
                bd_connection.connection.Service.Add(service);
                bd_connection.connection.SaveChanges();
                return true;
            }
            else
            {
                int uniq_serv = 0;
                Service service1 = new Service();
                foreach (var i in allService)
                {
                    if (i.Town_Name == townName)
                    {
                        uniq_serv = i.ID;
                    }
                }
                service1 = bd_connection.connection.Service.Where(x => x.ID == uniq_serv).FirstOrDefault();
                service1.IsDeleted = true;
                bd_connection.connection.SaveChanges();
                RedactService(townName, coast, saleCoast);
                return false;
            }
        }

        public static void RedactService(string townName, decimal coast, decimal saleCoast)
        {
            Service service = new Service();
            service.Town_Name = townName;
            service.Date = DateTime.Now;
            service.Min_Coast = coast;
            service.Sale_Coast = saleCoast;
            bd_connection.connection.Service.Add(service);
            bd_connection.connection.SaveChanges();
        }
    }
}
