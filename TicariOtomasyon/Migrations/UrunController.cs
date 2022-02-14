using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Migrations
{
    public class UrunController : Controller
    {
        // GET: Urun

        Context c = new Context();
        public ActionResult Index(string p)
        {
            var urunler = from x in c.Uruns select x;
                          if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            };
            
           
            return View(urunler.ToList());
        }



       

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris
                                           select new SelectListItem()
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Urun u)
        {
            

            c.Uruns.Add(u);
            c.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult UrunSil(int id)
        {

            var urn = c.Uruns.Find(id);
            urn.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from i in c.Kategoris
                                           select new SelectListItem()
                                           {
                                               Text = i.KategoriAd,
                                               Value = i.KategoriId.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;

            var urn = c.Uruns.Find(id);

            return View(urn);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun u)
        {
            var urn = c.Uruns.Find(u.UrunId);
            urn.UrunAd = u.UrunAd;
            urn.UrunGorsel = u.UrunGorsel;
            urn.Durum = u.Durum;
            urn.Marka = u.Marka;
            urn.KategoriId = u.KategoriId;
            urn.SatisFiyat = u.SatisFiyat;
            urn.AlisFiyat = u.AlisFiyat;
            urn.Stok = u.Stok;

            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {


            List<SelectListItem> urunList = (from x in c.Uruns
                                             select new SelectListItem
                                             {
                                                 Text = x.UrunAd,
                                                 Value = x.UrunId.ToString()
                                             }).ToList();

            List<SelectListItem> cariList = (from x in c.Caris
                                             select new SelectListItem
                                             {
                                                 Text = x.CariAd,
                                                 Value = x.CariId.ToString()
                                             }).ToList();

            List<SelectListItem> personelList = (from x in c.Personeles
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PersonelAdSoyad,
                                                     Value = x.PersonelId.ToString()
                                                 }).ToList();


            ViewBag.urunList = urunList;
            ViewBag.cariList = cariList;
            ViewBag.personelList = personelList;

            var deger = c.Uruns.Find(id);
            ViewBag.dgr1 = deger.UrunId.ToString();
            ViewBag.dgr3 = deger.Stok.ToString();

            ViewBag.dgr2 = deger.SatisFiyat;
            return View();
        }




        [HttpPost]
        public ActionResult SatisYap(SatisHareket sh)
        {


            return RedirectToAction("Index", "SatisHareket");

        }
    }
}