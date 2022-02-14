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
    public class KategoriController : Controller
    {
        // GET: Kategori

        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var kategoriList = c.Kategoris.Where(x => x.Durum == true).ToList().ToPagedList(sayfa,5 );

            return View(kategoriList);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            
            c.Kategoris.Add(k);
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {

            var del = c.Kategoris.Where(x => x.KategoriId == id).FirstOrDefault();
            del.Durum = false;
            c.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult KategoriGetir(int id)
        {
            var gun = c.Kategoris.Where(x => x.KategoriId == id).FirstOrDefault();
            
            return View(gun);
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori k)
        {
            var gun2 = c.Kategoris.Find(k.KategoriId);
            gun2.KategoriAd = k.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}