using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionfinal.DAL;
using auctionfinal.Iservice;
using System.IO;

namespace auctionfinal.Areas.Admin.Controllers
{
    public class adminController : Controller
    {

        Playerservice ps = new Playerservice();
        // GET: Admin/admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult check(int userid, string username, string password, string submit)
        {
            auctionEntities entities = new auctionEntities();
            user users = entities.users.FirstOrDefault(x => x.username == username);
            if ((users.password.ToString().Trim()).Equals(password))
            {
                ViewData["tested"] = "true";
            }
            else
            {
                ViewData["tested"] = "false";
            }
            return View();
        }
        [HttpGet]
        public ActionResult addplayer()
        {
            ViewData["data"] = "false";
            return View();
        }
        byte[] bytes1;
        [HttpPost]
        public ActionResult addplayer(int playerid, string playername, int baseprice, HttpPostedFileBase photo)
        {
            player player1 = new player();
            player1.playerid = playerid;
            player1.playername = playername;
            player1.baseprice = baseprice;
            System.IO.BinaryReader br = new System.IO.BinaryReader(photo.InputStream);
            bytes1 = new byte[photo.ContentLength];
            br.Read(bytes1, 0, bytes1.Length);
            br.Close();
            player1.photo = bytes1;
            ps.save(player1);
            ViewData["data"] = "true";
            return View();
        }
       
        public ActionResult editplayer()
        {
            player[] players=ps.getall();
            return View(players);
        }
        public FileStreamResult display(int id)
        {
            player player=ps.getbyid(id);
            Stream stream = new MemoryStream(player.photo);
            FileStreamResult fsr = new FileStreamResult(stream, "image/jpeg");
            return fsr;

        }
        public ActionResult editing(int id)
        {
            player player = ps.getbyid(id);
            return View(player);
        }
        public ActionResult edit(int playerid, string playername, int baseprice, HttpPostedFileBase photo)
        {
            player player1 = new player();
            player1.playerid = playerid;
            player1.playername = playername;
            player1.baseprice = baseprice;
            if (photo != null)
            {
                System.IO.BinaryReader br = new System.IO.BinaryReader(photo.InputStream);
                bytes1 = new byte[photo.ContentLength];
                br.Read(bytes1, 0, bytes1.Length);
                br.Close();
            }
            player1.photo = bytes1;
            ps.update(player1);
            return View();
        }
        public ActionResult deleteplayer()
        {
            player[] players = ps.getall();
            return View(players);
        }
        public ActionResult delete(int id)
        {
            ps.delete(id);
            return View();
        }
        public ActionResult startauction()
        {
            return View();
        }
    }
}