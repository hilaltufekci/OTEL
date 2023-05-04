using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using otel.Models;

namespace otel.Controllers
{
    public class SubeController : Controller
    {
        // GET: Sube
        OtelEntities2 db = new OtelEntities2();
        [HttpGet]
        public ActionResult Index()
        {
             return View(db.Subelers.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Subeler save)
        {
            try
            {
                using (OtelEntities2 db = new OtelEntities2())
                {
                    db.Subelers.Add(save);
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {

                return View(db.Subelers.Where(x => x.SubeNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Subeler yenile)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {
                db.Entry(yenile).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");


            }
        }
        public ActionResult Delete(int id)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {

                return View(db.Subelers.Where(x => x.SubeNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Subeler Sil)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {

                Sil = db.Subelers.Where(x => x.SubeNo == id).FirstOrDefault();
                db.Subelers.Remove(Sil);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}