using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Migrations
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik

        Context c = new Context();
        public ActionResult Index()
        {

            var d1 = c.Caris.Count().ToString();
            var d2 = c.Uruns.Count().ToString();
            var d3 = c.Personeles.Count().ToString();
            var d4 = c.Kategoris.Count().ToString();
            var d5 = c.Uruns.Sum(x => x.Stok).ToString();
            var d6 = (from x in c.Uruns select x.Marka).Distinct().Count().ToString();

           
            var d7 = c.Uruns.Where(x => x.Stok <= 20).Count();
            var d8 = c.Uruns.OrderByDescending(x => x.SatisFiyat).Select(y => y.UrunAd).FirstOrDefault();
            var d9 = c.Uruns.OrderBy(x => x.SatisFiyat).Select(y => y.UrunAd).FirstOrDefault();
            var d10 = c.Uruns.Where(x => x.UrunAd == "Buzdolabı").Count().ToString();
            var d11 = c.Uruns.Where(x => x.UrunAd == "Laptop").Count().ToString();
            var d12 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();

            var d144 = c.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            var d13 = c.SatisHarekets.GroupBy(x => x.Urun.UrunAd).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            var d14 = c.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            var bugun = DateTime.Today;
            var d15 = c.SatisHarekets.Where(x => x.Tarih == bugun).Count().ToString();
            var d16 = c.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => (decimal?)y.ToplamTutar).ToString();

            


            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            ViewBag.d8 = d8;
            ViewBag.d9 = d9;
            ViewBag.d10 = d10;
            
            ViewBag.d11 = d11;
            ViewBag.d12 = d12;
            ViewBag.d13 = d13;
            ViewBag.d14 = d14;
            ViewBag.d15 = d15;

            ViewBag.d16 = d16;

            return View();
        }


        public ActionResult BasitTablolar()
        {
            var sorgu = (from x in c.Caris
                         group x by x.CariSehir into g
                         select new SınıfGrup
                         {
                             Sehir = g.Key,
                             Sayi = g.Count()
                         }).ToList();



    
            return View(sorgu);
        }


        public PartialViewResult Partial1()
        {
            var sorgu = from x in c.Personeles
                        group x by x.departman.DepartmanAd into g
                        select new SinifGrup2
                        {
                            Departman = g.Key,
                            Adet = g.Count()
                        };
            return PartialView(sorgu.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = c.Caris.ToList();

            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = c.Uruns.ToList();
            return PartialView(sorgu);
        }
         
        public PartialViewResult Partial4()
        {
            var sorgu = from x in c.Uruns
                        group x by x.Marka into g
                        select new SinifGrup3
                        {
                            Marka = g.Key,
                            Adet = g.Count()
                        };
                       
            return PartialView(sorgu.ToList());
        }
    
    }
}