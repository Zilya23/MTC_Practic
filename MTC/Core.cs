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

        public static void DeleteService(Service service)
        {
            service.IsDeleted = true;
            bd_connection.connection.SaveChanges();
        }

        public static void RedactServices(string townName, decimal coast, decimal saleCoast, Service service1)
        {
            service1.IsDeleted = true;
            bd_connection.connection.SaveChanges();
            Service service = new Service();
            service.Town_Name = townName;
            service.Date = DateTime.Now;
            service.Min_Coast = coast;
            service.Sale_Coast = saleCoast;
            bd_connection.connection.Service.Add(service);
            bd_connection.connection.SaveChanges();
        }

        public static List<Call> GetCalls()
        {
            return new List<Call>(bd_connection.connection.Call.ToList());
        }

        public static void AddCall(int idClient, int idSer, DateTime date, int durstion)
        {
            Call call = new Call();
            call.ID_Client = idClient;
            call.ID_Services = idSer;
            call.Call_Date = date;
            call.Duration = durstion;
            call.ID_Status = 1;
            bd_connection.connection.Call.Add(call);
            bd_connection.connection.SaveChanges();
        }

        public static void CallOk(Call call)
        {
            call.ID_Status = 3;
            bd_connection.connection.SaveChanges();
        }

        public static void CallNoOk(Call call)
        {
            call.ID_Status = 1;
            bd_connection.connection.SaveChanges();
        }

        public static Client AuthClient(string number)
        {
            Client client = bd_connection.connection.Client.Where(x => x.Telephone_Number == number).FirstOrDefault();
            return client;
        }

        public static List<Call> GetClietCall(int idClient)
        {
            return new List<Call>(bd_connection.connection.Call.Where(x => x.ID_Client == idClient).ToList());
        }

    }
}
