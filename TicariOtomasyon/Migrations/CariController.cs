using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

using PagedList;
using PagedList.Mvc;
namespace TicariOtomasyon.Migrations
{
    public class CariController : Controller
    {
        // GET: Cari

        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var cari = c.Caris.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 3);

            return View(cari);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {

            return View();
        }
    
        [HttpPost]
        public ActionResult CariEkle(Cari cari)
        {
            c.Caris.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = c.Caris.Find(id);
            cari.Durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGetir(int id)
        {
            var cari = c.Caris.Find(id);

            return View(cari);

        }

        [HttpPost]
        public ActionResult CariGuncelle(Cari cari)
        {
            var oldCari = c.Caris.Find(cari.CariId);

            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }



            oldCari.Durum = cari.Durum;
            oldCari.CariAd = cari.CariAd;
            oldCari.CariSoyad = cari.CariSoyad;
            oldCari.CariMail = cari.CariMail;
            oldCari.CariSehir = cari.CariSehir;

            c.SaveChanges();




            return RedirectToAction("Index");
        }
        
}
}