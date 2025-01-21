using EnvanterMVC.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvanterMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
           
            return View(user);
        }

        public ActionResult Logout()
        {
            // Çıkış işlemleri (gerekirse oturum temizleme vb.)
            return RedirectToAction("Admin", "Login");
        }
    }

}
