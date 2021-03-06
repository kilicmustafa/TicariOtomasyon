using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;

namespace TicariOtomasyon.Migrations
{
  
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            var degerler = c.Caris.FirstOrDefault(x => x.CariMail == mail);

            ViewBag.mail = mail;

           
            return View(degerler);
        } 

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = c.Caris.Where(x => x.CariMail == mail.ToString()).Select(y => y.CariId).FirstOrDefault();

            var degerler = c.SatisHarekets.Where(x => x.CariId == id).ToList();

            return View(degerler);
        }
    }
}