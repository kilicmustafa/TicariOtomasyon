using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
namespace TicariOtomasyon.Migrations
{
    public class YapılacaklarController : Controller
    {
        // GET: Yapılacaklar

        Context c = new Context();
        public ActionResult Index()
        {


            var d1 = c.Caris.Count().ToString();
            var d2 = c.Caris.Select(x => x.CariSehir).Distinct().Count().ToString();
            var d3 = c.Uruns.Count().ToString();
            var d4 = c.Kategoris.Count().ToString();

            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            return View();
        }


        public PartialViewResult ToDo()
        {
            
            var sorgu = c.Yapılacaklars.ToList();
            return PartialView(sorgu);
        }
    }
}