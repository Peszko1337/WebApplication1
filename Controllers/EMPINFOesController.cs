using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EMPINFOesController : Controller
    {
        private BazaDanychFilipPeszkoEntities db = new BazaDanychFilipPeszkoEntities();

        // GET: EMPINFOes
        public ActionResult Index()
        {
            return View(db.EMPINFOes.ToList());
        }

        // GET: EMPINFOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPINFO eMPINFO = db.EMPINFOes.Find(id);
            if (eMPINFO == null)
            {
                return HttpNotFound();
            }
            return View(eMPINFO);
        }

        // GET: EMPINFOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPINFOes/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpID,Imię,Wiek,Stan_Konta")] EMPINFO eMPINFO)
        {
            if (ModelState.IsValid)
            {
                db.EMPINFOes.Add(eMPINFO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPINFO);
        }

        // GET: EMPINFOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPINFO eMPINFO = db.EMPINFOes.Find(id);
            if (eMPINFO == null)
            {
                return HttpNotFound();
            }
            return View(eMPINFO);
        }

        // POST: EMPINFOes/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpID,Imię,Wiek,Stan_Konta")] EMPINFO eMPINFO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPINFO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPINFO);
        }

        // GET: EMPINFOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPINFO eMPINFO = db.EMPINFOes.Find(id);
            if (eMPINFO == null)
            {
                return HttpNotFound();
            }
            return View(eMPINFO);
        }

        // POST: EMPINFOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EMPINFO eMPINFO = db.EMPINFOes.Find(id);
            db.EMPINFOes.Remove(eMPINFO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
