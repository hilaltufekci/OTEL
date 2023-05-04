using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using otel.Models;

namespace otel.Controllers
{
    public class TurController : Controller
    {
        // GET: Tur
        OtelEntities2 db = new OtelEntities2();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Turlars.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Turlar save)
        {
            try
            {
                using (OtelEntities2 db = new OtelEntities2())
                {
                    db.Turlars.Add(save);
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

                return View(db.Turlars.Where(x => x.TurNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Turlar yenile)
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

                return View(db.Turlars.Where(x => x.TurNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Turlar Sil)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {

                Sil = db.Turlars.Where(x => x.TurNo == id).FirstOrDefault();
                db.Turlars.Remove(Sil);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}