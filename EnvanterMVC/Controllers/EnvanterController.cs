using EnvanterMVC.Entities.DAL;
using EnvanterMVC.Entities.Model;
using EnvanterMVC.Entities.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace EnvanterMVC.Controllers
{
    public class EnvanterController : Controller
    {
        // GET: Envanter,
        EnvanterContext context = new EnvanterContext();
        UserDAL UserDAL = new UserDAL();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var model = UserDAL.GetAll(context);
            return View(model);
        }
        public ActionResult Ekle()
        { 
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Ekle(User user)
        {
            if(ModelState.IsValid)
            {
                UserDAL.InsertorUpdate(context, user);
                UserDAL.Save(context);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}