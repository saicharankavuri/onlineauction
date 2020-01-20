using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using auctionfinal.Iservice;
using auctionfinal.DAL;

namespace auctionfinal.Iservice
{
    public class userservicer: userservice
    {
        auctionEntities entities = new auctionEntities();
        public Boolean save(user user)
        {
            entities.users.Add(user);
            entities.SaveChanges();
            return true;
        }
        public Boolean check(int a)
        {
            user user = entities.users.Find(a);
            if (user == null)
                return false;
            return true;
        }
    }
}