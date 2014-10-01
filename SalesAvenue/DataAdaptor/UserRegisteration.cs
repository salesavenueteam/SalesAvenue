using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SalesAvenue.Models;
using SalesAvenue.Util;

namespace SalesAvenue.DataAdaptor
{
    public class UserRegisteration
    {

        public static string GetStoreName(string storeName)
        {
            using(SalesAvenueEntities _db = new SalesAvenueEntities())
	        {
                return _db.Users.Where(a => a.StoreName == storeName).Select(a => a.StoreName).SingleOrDefault(); 
	        }
        }

        public static string GetEmail(string email)
        {
            using (SalesAvenueEntities _db = new SalesAvenueEntities())
            {
                return _db.Users.Where(a => a.Email == email).Select(a => a.Email).SingleOrDefault(); ;
            }
        }

        public static void RegisterUsers(string storeName, string email, byte[] password, Guid tokenId)
        {
            using (SalesAvenueEntities _db = new SalesAvenueEntities())
            {
                if (tokenId == Guid.Empty)
                {
                    _db.RegisterUsers(storeName, email, null, (int)UserStatus.PendingVerification, null);

                    var token = (from t in _db.Users
                                   where t.StoreName == storeName && t.Email == email
                                   select t.TokenID).SingleOrDefault();
                  
                    Mailer.SendMail(email, (Guid)token);
                 
                }
                else
                    _db.RegisterUsers(null, null, password, (int)UserStatus.Active, tokenId);
            }
           
        }

        public static User GetRegisteredUsers(Guid tokenId)
        {
            using (SalesAvenueEntities _db = new SalesAvenueEntities())
            {
                return _db.Users.Where(a => a.TokenID == tokenId).SingleOrDefault();                
            }
        }
    }
}