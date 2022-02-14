using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Migrations
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Index7()
        {
            return View();

        }

        public ActionResult Index2()
        {

            var grafikciz = new Chart(width:600 ,height:600);
            grafikciz.AddTitle(text: "Kategori - Urun Stok Grafiği");
            grafikciz.AddLegend(title: "Stok")
                .AddSeries(
                "Degerler",
                xValue: new[] { "Beyaz Eşya", "Ofis", "Teknoloji" },
                yValues: new[] { 30, 60, 90 }


                ).Write();


            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }


        public ActionResult Index6()
        {

            var yeniGrafik = new Chart(width: 1000, height: 1000);
            yeniGrafik.AddTitle(text: "Kategori - Urun Stok Grafiği");
            yeniGrafik.AddLegend(title: "Stok");
            yeniGrafik.AddSeries(
                name: "Degerler",
                xValue: new[] { "Aksesuar", "Akıllı Ev Aletleri", "Temizlik Ürünleri" },
                yValues: new[] { 10, 20, 30 }

                ).Write();

            return File(yeniGrafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index5()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            Context c = new Context();

            var sonuclar = c.Uruns.ToList();

            sonuclar.ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ForEach(x => yValue.Add(x.Stok));


            var grafikciz = new Chart(width: 700, height: 700);
            grafikciz.AddTitle(text: "Urun - Urun Stok Grafiği");
            grafikciz.AddLegend("Stok")
                .AddSeries(
                name: "Degerler",
                xValue : xValue,
                yValues : yValue
                ).Write();


            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");


        }

        public ActionResult Index3()
        {

            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();


            Context c = new Context();
            var sonuclar = c.Uruns.ToList();

            sonuclar.ForEach(x => xValue.Add(x.UrunAd));
            sonuclar.ForEach(x => yValue.Add(x.Stok));




            Chart grafik = new Chart(width: 1000, height: 1000);

            grafik.AddTitle("Urun - Stok Grafiği");
            grafik.AddLegend(title: "Stoklar");
            grafik.AddSeries(
                chartType: "Bar",
                name:"Stok",
                xValue : xValue,
                yValues : yValue
                
                );


            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

 
        public ActionResult VisualizeUrunResult()
        {

          
                return Json( UrunListesi() , JsonRequestBehavior.AllowGet);
    
           

        }
     


        public List<GoogleChart> UrunListesi()
        {

            List<GoogleChart> gogchart = new List<GoogleChart>();
            gogchart.Add(new GoogleChart()
            {

                UrunAd = "Bilgisayar",
                Stok = 130


            });


            gogchart.Add(new GoogleChart(){

                UrunAd = "Beyaz Eşya",
                Stok = 200
            });



           return gogchart;
        }



        public ActionResult Index9()
        {

            return View();
        }

        public ActionResult VirutilazeUrunStok2()
        {



            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);

        }

        public List<GoogleChart> UrunListesi2()
        {
            List<GoogleChart> gogchart = new List<GoogleChart>();
            using (var c = new Context())
            {

                gogchart = c.Uruns.Select(x => new GoogleChart
                {
                    UrunAd = x.UrunAd,
                    Stok = x.Stok
                }).ToList();


            };


            return gogchart;
        }
    }
}