using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using otel.Models;

namespace otel.Controllers
{
    public class OtelController : Controller
    {
        // GET: Otel
        OtelEntities2 db = new OtelEntities2();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Otellers.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Oteller save)
        {
            try
            {
                using (OtelEntities2 db = new OtelEntities2())
                {
                    db.Otellers.Add(save);
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

                return View(db.Otellers .Where(x => x.OtelNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Oteller yenile)
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

                return View(db.Otellers.Where(x => x.OtelNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Oteller Sil)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {

                Sil = db.Otellers.Where(x => x.OtelNo == id).FirstOrDefault();
                db.Otellers.Remove(Sil);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}