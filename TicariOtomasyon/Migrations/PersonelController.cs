using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
using System.IO;

namespace TicariOtomasyon.Migrations
{
    public class PersonelController : Controller
    {
        

        Context c = new Context();
        public ActionResult Index()
        {
            var per = c.Personeles.Where(x => x.Durum == true).ToList();
            

            

            return View(per);
        }


        [HttpGet]
        public ActionResult PersonelEkle(){
            List<SelectListItem> depList = (from x in c.Departmen
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmanAd,
                                                Value = x.DepartmanId.ToString()
                                            }).ToList();
            ViewBag.depList = depList;

            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if(Request.Files.Count > 0)
            {
                string dosyaAdı = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + uzantı + dosyaAdı;

                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGörsel = "/Images/" + uzantı + dosyaAdı;




            }
            c.Personeles.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var per = c.Personeles.Find(id);
            per.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult PersonelGetir(int id)
        {
            var per = c.Personeles.Where(x => x.PersonelId == id).FirstOrDefault();
            List<SelectListItem> depList = (from x in c.Departmen
                                            select new SelectListItem
                                            {
                                                Text = x.DepartmanAd,
                                                Value = x.DepartmanId.ToString()
                                            }).ToList();
            ViewBag.depList = depList;
            return View(per);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel p)
        {

            if(Request.Files.Count > 0)
            {
                string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                string uzantı = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Images/" + uzantı + dosyaAdi;

                Request.Files[0].SaveAs(Server.MapPath(yol));

                p.PersonelGörsel = "/Images/" + uzantı + dosyaAdi;
                
            }

   
            var perOld = c.Personeles.Find(p.PersonelId);
            perOld.Durum = p.Durum;
            perOld.PersonelAdSoyad = p.PersonelAdSoyad;
            perOld.PersonelGörsel = p.PersonelGörsel;
            perOld.DepartmanId = p.DepartmanId;

            c.SaveChanges();

            return RedirectToAction("Index");

        }



        
        public ActionResult PersonelYeni()
        {
            var sorgu = c.Personeles.ToList();
            return View(sorgu);
        }
        

    }
}