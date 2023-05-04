using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using otel.Models;

namespace otel.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Personel
        OtelEntities2 db = new OtelEntities2();
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Musterilers.ToList());
        }
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Musteriler save)
        {
            try
            {
                using (OtelEntities2 db = new OtelEntities2())
                {
                    db.Musterilers.Add(save);
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

                    return View(db.Musterilers.Where(x => x.MüşteriNo == id).FirstOrDefault());


                }
            }
            [HttpPost]
            public ActionResult Edit(int id, Musteriler yenile)
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

                return View(db.Musterilers.Where(x => x.MüşteriNo == id).FirstOrDefault());


            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Musteriler Sil)
        {
            using (OtelEntities2 db = new OtelEntities2())
            {

                Sil = db.Musterilers.Where(x => x.MüşteriNo == id).FirstOrDefault();
                db.Musterilers.Remove(Sil);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
    }
