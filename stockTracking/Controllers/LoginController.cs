using stockTracking.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace stockTracking.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        stockManagementSystemEntities1 db = new stockManagementSystemEntities1();
        
        [HttpGet]
        public ActionResult LoginPage()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult LoginPage(users user)
        {
            var isRegistered = db.users.FirstOrDefault(m=>m.username==user.username && m.password==user.password);
            if(isRegistered == null)
            {
                ViewBag.message = "Invalid username or password";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(isRegistered.username,false);
                return RedirectToAction("ProductList","Products");
            }
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginPage");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(users kullanıcı)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.users.Add(kullanıcı);
            db.SaveChanges();
            return RedirectToAction("LoginPage");

        }
    }
}