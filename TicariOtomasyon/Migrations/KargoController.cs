using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Migrations
{
    public class KargoController : Controller
    {
        Context c = new Context();
        // GET: Kargo
        public ActionResult Index(string p)
        {

            var kargolar = from x in c.KargoDetays select x;
            if(!string.IsNullOrEmpty(p))
            {
                kargolar = kargolar.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargolar.ToList());
        }


        [HttpGet]
        public ActionResult KargoEkle() {

            Random rdn = new Random();

            string[] karakter = { "A", "B", "C", "D" };

            int k1 = rdn.Next(0, 4);
            int k2 = rdn.Next(0, 4);
            int k3 = rdn.Next(0, 4);

            int s1 = rdn.Next(100, 200);
            int s2 = rdn.Next(100, 200);
            int s3 = rdn.Next(10, 99);

            string kod = s1.ToString()+ karakter[k1] + s2.ToString()+ karakter[k2] + s3.ToString() + karakter[k3];

            ViewBag.takipKod = kod;

            




            List<SelectListItem> personelList = (from x in c.Personeles
                                                     select new SelectListItem
                                                     {
                                                         Text = x.PersonelAdSoyad,
                                                         Value = x.PersonelId.ToString()
                                                     }).ToList();
            ViewBag.perList = personelList;
            return View();
        }
    
        [HttpPost]
        public ActionResult KargoEkle(KargoDetay kd)
        {
           
           
            c.KargoDetays.Add(kd);
            c.SaveChanges();
            
            return RedirectToAction("Index", "Kargo");
        }
    

        public ActionResult KargoDetay(string id)
        {
           
            var kargo = c.KargoTakips.Where(x => x.TakipKodu == id);
            ViewBag.TakipKodu = id;

            return View(kargo.ToList());


        }

    }
}