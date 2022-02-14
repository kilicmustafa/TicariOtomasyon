using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Migrations
{
    public class FaturaController : Controller
    {
        Context c = new Context();
        
        public ActionResult Index()
        {
            TabloBirlestirForPopup tbpop = new TabloBirlestirForPopup();

            tbpop.FaturaKalemTable = c.FaturasKalem.ToList();
            tbpop.FaturaTable= c.Faturas.Where(x => x.Durum == true).ToList();
            return View(tbpop);
        }


        [HttpGet]
        public ActionResult FaturaEkle()
        {


            return View();
        }

        [HttpPost]

        public ActionResult FaturaEkle(Fatura f)
        {
            f.Tarih = DateTime.Now;
            f.Durum = true;

            c.Faturas.Add(f);

            c.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            
            return View(fatura);
        }


        public ActionResult FaturaGuncelle(Fatura f)
        {
            var ftrOld = c.Faturas.Find(f.FaturaId);
            
            ftrOld.FaturaSeriNo = f.FaturaSeriNo;
            ftrOld.FaturaSıraNo = f.FaturaSıraNo;
            ftrOld.TeslimAlan = f.TeslimAlan;
            ftrOld.TeslimEden = f.TeslimEden;
            ftrOld.VergiDairesi = f.VergiDairesi;
            c.SaveChanges();


            return RedirectToAction("Index");


        }


        public ActionResult FaturaKalemDetay(int id)
        {
            var kalem = c.FaturasKalem.Where(x => x.FaturaId == id ).ToList();
            ViewBag.FaturaId = id;
            return View(kalem);

        }

        [HttpGet]
        public ActionResult FaturaKalemEkle()
        {
            
            
            return View();
        }

        [HttpPost]
        public ActionResult FaturaKalemEkle(FaturaKalem fk)
        {

            
            c.FaturasKalem.Add(fk);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}