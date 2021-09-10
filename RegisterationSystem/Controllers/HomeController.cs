using RegisterationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RegisterationSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tbl_users user)
        {
            Entities db = new Entities();
            var data = db.tbl_users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (data != null)
            {
                return RedirectToAction("UsersList");
            }
            else
            { 
            return View();
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tbl_users user)
        {
            Entities db = new Entities();
            db.tbl_users.Add(user);
            db.SaveChanges();


            return RedirectToAction("UsersList");
        }

        public ActionResult UsersList()
        {
            Entities db = new Entities();
            var users = db.tbl_users.ToList();
    
            return View(users);
        }
        
        public ActionResult UserProfile(int id)
        {
            Entities db = new Entities();
            var user = db.tbl_users.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult UserProfile(tbl_users Objuser, String cSharp , String Java,String Python)
        {
            if(cSharp == "true")
            {
                Objuser.InterestedInCSharp = true;
            }
            else
            {
                Objuser.InterestedInCSharp = false;
            }
            if (Java == "true")
            {
                Objuser.InterestedInJava = true;
            }
            else
            {
                Objuser.InterestedInJava = false;

            }
            if (Python == "true")
            {
                Objuser.InterestedInPython = true;
            }
            else
            {
                Objuser.InterestedInPython = false;

            }

            Entities db = new Entities();
            db.Entry(Objuser).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UsersList");
        }
        

        [HttpGet]
        
        public ActionResult Edit(int id)
        {
            Entities db = new Entities();
            var user = db.tbl_users.Find(id);
            user.InterestedInCSharp = (user.InterestedInCSharp == null) ? false : user.InterestedInCSharp;
            user.InterestedInJava = (user.InterestedInJava == null) ? false : user.InterestedInJava;
            user.InterestedInPython = (user.InterestedInPython == null) ? false : user.InterestedInPython;
            var CityList = db.tbl_city.ToList();
            ViewBag.CityList = new SelectList(CityList, "CityID", "CityName");
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(tbl_users Objuser , String cSharp, String Java, String Python)
        {
            Objuser.InterestedInCSharp = (cSharp == "true") ? true : false;
            Objuser.InterestedInJava = (Java == "true") ? true : false;
            Objuser.InterestedInPython = (Python == "true") ? true : false;


            //if (cSharp == "true")
            //{
            //    Objuser.InterestedInCSharp = true;
            //}
            //else
            //{
            //    Objuser.InterestedInCSharp = false;
            //}
            //if (Java == "true")
            //{
            //    Objuser.InterestedInJava = true;
            //}
            //else
            //{
            //    Objuser.InterestedInJava = false;

            //}
            //if (Python == "true")
            //{
            //    Objuser.InterestedInPython = true;
            //}
            //else
            //{
            //    Objuser.InterestedInPython = false;

            //}

            Entities db = new Entities();
            db.Entry(Objuser).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("UsersList");
        }


        public ActionResult Delete(int UserId)
        {
            Entities db = new Entities();
            var user = db.tbl_users.Find(UserId);
            db.tbl_users.Remove(user);
            db.SaveChanges();
            return View();
        }

    }
}