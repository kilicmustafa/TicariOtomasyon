using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Migrations
{
    public class GaleriController : Controller
    {
        // GET: Galeri

        Context c = new Context();

        public ActionResult Index()
        {

            var urun = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urun);
        }
    }
}