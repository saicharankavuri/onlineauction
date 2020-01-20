using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using auctionfinal.Iservice;
using auctionfinal.DAL;

namespace auctionfinal.Iservice
{
    public class Playerservice :Iservice
    {
        auctionEntities entities=new auctionEntities();
        public Boolean save(player player)
        {         
            entities.players.Add(player);
            entities.SaveChanges();
            return true;
        }    
        public Boolean delete(int a)
        {
            player player = entities.players.Find(a);
            entities.players.Remove(player);
            entities.SaveChanges();
            return true;
        }
        public player getbyid(int a)
        {
            player player = entities.players.Find(a);
            return player;
        }
        public Boolean update(player player)
        {
            player player1 = entities.players.Find(player.playerid);
            player1.playername = player.playername;
            player1.baseprice = player.baseprice;
            player1.photo = player.photo;
            entities.SaveChanges();
            return true;
        }
        public player[] getall()
        {
            return entities.players.ToArray();
        }
        
    }
}