using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Migrations
{
    public class LoginController : Controller
    {
        // GET: Login
        
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialKayitOl()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialKayitOl(Cari p)
        {
            c.Caris.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult LoginCari()
        {   

            return View();

        }
        [HttpPost]
        public ActionResult LoginCari(Cari p)
       {
            var bilgiler = c.Caris.FirstOrDefault(x => x.CariMail == p.CariMail && x.Sifre == p.Sifre);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                

                return RedirectToAction("Index", "CariPanel");
            }

            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        public ActionResult LoginPersonel()
        {


            return View();
        }


        [HttpPost]
        public ActionResult LoginPersonel(Personel p)
        {
            var bilgiler = c.Personeles.Where(x => x.PersonelKullaniciAdi == p.PersonelKullaniciAdi && x.PersonelSifre == p.PersonelSifre).FirstOrDefault();
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(p.PersonelKullaniciAdi, false);
                Session["PersonelKullaniciAdi"] = p.PersonelKullaniciAdi.ToString();

                return RedirectToAction("Index", "Departman");



            }


            return RedirectToAction("Index", "Login");
        }
    }
}