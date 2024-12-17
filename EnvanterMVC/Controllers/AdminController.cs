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
        private const string AdminUsername = "admin"; // Giriş için kullanılacak kullanıcı adı
        private const string AdminPassword = "1234"; // Giriş için kullanılacak şifre


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
            if (ModelState.IsValid)
            {

                if (user.Username == AdminUsername && user.Password == AdminPassword)
                {
                    // Giriş başarılı ise ana sayfaya yönlendir

                    return RedirectToAction("Envanter" , "Index");
                }
                else
                {

                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
                }
            }
            return View(user);
        }

        public ActionResult Logout()
        {
            // Çıkış işlemleri (gerekirse oturum temizleme vb.)
            return RedirectToAction("Admin", "Login");
        }
    }

}
