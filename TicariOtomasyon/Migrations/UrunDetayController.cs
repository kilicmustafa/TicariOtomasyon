using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Migrations
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay

        Context c = new Context();

    
        public ActionResult Index()
        {

            TabloBirlestir tb = new TabloBirlestir();
            tb.UrunTable = c.Uruns.Where(x => x.UrunId == 1).ToList();
            tb.DetayTable = c.Detays.Where(x => x.DetayId == 1).ToList();


            return View(tb);
        }
    }
}