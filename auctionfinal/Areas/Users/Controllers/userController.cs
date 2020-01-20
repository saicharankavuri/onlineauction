using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using auctionfinal.DAL;
using auctionfinal.Iservice;

namespace auctionfinal.Areas.Users.Controllers
{
    public class userController : Controller
    {
        // GET: Users/user
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult check(int userid, string username, string password, string type)
        {
            user user = new user();
            userservicer us = new userservicer();
            Playerservice ps = new Playerservice();
            if (type == "SUBMIT")
            {
                ViewData["signup"] = "false";
                Boolean x = us.check(userid);
                if (x == true)
                {
                    ViewData["tested"] = "true";
                }
                else
                {
                    ViewData["tested"] = "false";
                }
                player[] arr = ps.getall();
                return View(arr);

            }
            else
            {
                       
                ViewData["signup"] = "true";
                
            }
            return View();
        }
        public ActionResult adduser(int userid,string username,string password)
        {
            user user = new user();
            user.userid = userid;
            user.username = username;
            user.password = password;
            user.usertype = "user";
            user.active = "true";
            userservicer us = new userservicer();
            us.save(user);
            return View();
        }
    }
}