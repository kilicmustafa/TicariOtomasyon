using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;
namespace TicariOtomasyon.Migrations
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context c = new Context();
        public ActionResult Index(int sayfa = 1)
        {
            var dep = c.Departmen.Where(x => x.Durum == true).ToList().ToPagedList(sayfa ,5);
            return View(dep);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DepartmanGetir(int id)
        {
            var dep = c.Departmen.Find(id);

            return View(dep);
        }
        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman dep)
        {
            var depOld = c.Departmen.Find(dep.DepartmanId);
            depOld.DepartmanAd = dep.DepartmanAd;
            
            c.SaveChanges();
            
            return RedirectToAction("Index");
        }


        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmen.Find(id);
            dep.Durum = false;

            c.SaveChanges();


            return RedirectToAction("Index");

        }


        public ActionResult DepartmanPersonelDetay(int id)
        {
            var per = c.Personeles.Where(x => x.DepartmanId == id).ToList();

            var dep = c.Departmen.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();

            ViewBag.depAd = dep;
            return View(per);
        }

    }
}