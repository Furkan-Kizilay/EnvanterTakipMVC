using EnvanterMVC.Entities.DAL;
using EnvanterMVC.Entities.Mapping;
using EnvanterMVC.Entities.Model;
using EnvanterMVC.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EnvanterMVC.Controllers
{
    [AllowAnonymous]
    public class AdminController : Controller
    {
        EnvanterContext context = new EnvanterContext(); 
        KullanicilarDAL kullanicilarDAL = new KullanicilarDAL();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar kullanicilar)
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
            }
            var model = kullanicilarDAL.GetByFilter(context, x => x.KullaniciAdi == kullanicilar.KullaniciAdi && x.Sifre == kullanicilar.Sifre);
            if (model != null)
            {
                FormsAuthentication.SetAuthCookie(model.KullaniciAdi,false);
                return RedirectToAction("List", "Envanter");
            }
            ViewBag.error = "Kullanıcı adı veya şifre hatalı";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Admin");
        }

    }

}
