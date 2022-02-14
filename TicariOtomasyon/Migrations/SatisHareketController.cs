using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Migrations
{
    public class SatisHareketController : Controller
    {
        // GET: SatisHareket

        Context c = new Context();
        public ActionResult Index()
        {
            var satis = c.SatisHarekets.Where(x => x.Durum == true).ToList();


            return View(satis);
        }


        public ActionResult SatisSil(int id)
        {
            var satis = c.SatisHarekets.Find(id);
            satis.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult SatisEkle(int id)
        {


            ViewBag.Id = id;


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




            return View();
        }

        [HttpPost]
        public ActionResult SatisEkle(SatisHareket sh)
        {

            sh.Tarih = DateTime.Today;
            sh.Durum = true;
            c.SatisHarekets.Add(sh);
            c.SaveChanges();




            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult SatisGetir(int id)
        {
            var satis = c.SatisHarekets.Find(id);


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










            return View(satis);
        }


        [HttpPost]
        public ActionResult SatisGuncelle(SatisHareket sh)
        {
            var oldSh = c.SatisHarekets.Find(sh.SatisId);

            oldSh.CariId = sh.CariId;
            oldSh.Adet = sh.Adet;
            oldSh.UrunID = sh.UrunID;
            oldSh.PersonelId = sh.PersonelId;
            oldSh.Fiyat = sh.Fiyat;
            oldSh.ToplamTutar = sh.ToplamTutar;
            
            c.SaveChanges();

            return RedirectToAction("Index");
        
        }

        public ActionResult SatisDetay(int id)
        {
            var satis = c.SatisHarekets.Where(x => x.SatisId == id).ToList();

            return View(satis);
        }
        
        public ActionResult PersonelSatisDetay(int id)
        {
            var satis = c.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personelAd = c.Personeles.Find(id).PersonelAdSoyad.ToString();

            ViewBag.personelAd = personelAd;


            return View(satis);


        }




    }
}