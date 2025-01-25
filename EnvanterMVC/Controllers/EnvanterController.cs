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
        KullanicilarDAL KullanicilarDAL = new KullanicilarDAL();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string ara)
        {
            var model = UserDAL.GetAll(context);
            if (ara != null)
            {
                model = UserDAL.GetAll(context, x => x.Tur.Contains(ara) || x.Marka.Contains(ara) || x.Model.Contains(ara) || x.SeriNo.Contains(ara) || x.Tarih.ToString().Contains(ara) || x.TeslimEden.Contains(ara) || x.TeslimAlan.Contains(ara) || x.TeslimEdilenDepartman.Contains(ara) || x.UrunDurum.Contains(ara) || x.IMEI.ToString().Contains(ara) || x.Aciklama.Contains(ara));

            }
            return View(model);
        }
        [HttpPost]
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
            if (ModelState.IsValid)
            {
                UserDAL.InsertorUpdate(context, user);
                UserDAL.Save(context);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public ActionResult Duzenle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = UserDAL.GetById(context, id);
            return View(model);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult Duzenle(User user)
        {
            if (ModelState.IsValid)
            {
                UserDAL.InsertorUpdate(context, user);
                UserDAL.Save(context);
                return RedirectToAction("List");
            }
            return View(user);
        }
        public ActionResult Sil(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            UserDAL.Delete(context, x => x.Id == id);
            UserDAL.Save(context);
            return RedirectToAction("List");
        }
        [HttpPost]
        public JsonResult AddBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return Json(new { success = false, message = "Barkod bilgisi eksik!" });
            }

            try
            {
                // Barkoddan sadece gerekli alanları doldur
                var data = barcode.Split(',');
                if (data.Length != 4)
                {
                    return Json(new { success = false, message = "Beklenen format: Tür,Marka,Model,SeriNo" });
                }

                var newUser = new User
                {
                    Tur = data[0],
                    Marka = data[1],
                    Model = data[2],
                    SeriNo = data[3],
                    Tarih = DateTime.Now,
                    TeslimEden = null,
                    TeslimAlan = null,
                    TeslimEdilenDepartman = null,
                    UrunDurum = null,
                    IMEI = 0,
                    Aciklama = null
                };

                // Veritabanına ekle
                UserDAL.InsertorUpdate(context, newUser);
                UserDAL.Save(context);

                return Json(new { success = true, message = "Barkod başarıyla kaydedildi.", barcode });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Hata: " + ex.Message });
            }
        }

        public ActionResult KullaniciOlustur()
        {
            return View();
        }

        // Kullanıcı kayıt işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KullaniciOlustur(Kullanicilar kullanicilar)
        {
            // Kullanıcı adı ve şifre doğrulama
            if (string.IsNullOrWhiteSpace(kullanicilar.KullaniciAdi) || kullanicilar.KullaniciAdi.Length < 3 || kullanicilar.KullaniciAdi.Length > 50)
            {
                ModelState.AddModelError("", "Kullanıcı adı 3 ile 50 karakter arasında olmalıdır ve boş bırakılamaz.");
                return View(kullanicilar);
            }

            if (string.IsNullOrWhiteSpace(kullanicilar.Sifre) || kullanicilar.Sifre.Length < 3 || kullanicilar.Sifre.Length > 15)
            {
                ModelState.AddModelError("", "Şifre 6 ile 15 karakter arasında olmalıdır ve boş bırakılamaz.");
                return View(kullanicilar);
            }

            try
            {
                if (context.Kullanicilar.Any(k => k.KullaniciAdi == kullanicilar.KullaniciAdi))
                {
                    ViewBag.Message = "Bu kullanıcı adı zaten mevcut.";
                    return View(kullanicilar);
                }

                // Yeni kullanıcı ekle
                context.Kullanicilar.Add(kullanicilar);
                context.SaveChanges();

                ViewBag.Message = "Kullanıcı başarıyla oluşturuldu.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Bir hata oluştu: " + ex.Message;
                System.Diagnostics.Debug.WriteLine(ex); // Hata loglama
            }

            return View(kullanicilar);
        }


    }
}