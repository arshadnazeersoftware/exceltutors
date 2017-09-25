using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private exceltutorsEntities db = new exceltutorsEntities();
        public bool User(string Username, string Password)
        {
            var user = db.Accounts.SingleOrDefault(k => k.Username == Username && k.Password == Password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Create(string username, string password, string email)
        {
            var existingAuthorCount = db.Accounts.Count(a => a.Username == username);
            if (existingAuthorCount == 0)
            {
                Accounts myAccount = new Accounts();
                myAccount.Username = username;
                myAccount.Password = password;
                myAccount.Email = email;
                db.Accounts.Add(myAccount);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
