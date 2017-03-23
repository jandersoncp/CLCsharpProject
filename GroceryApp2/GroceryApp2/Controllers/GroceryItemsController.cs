using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GroceryApp.Models;
using GroceryApp2.Models;

namespace GroceryApp2.Controllers
{
    public class GroceryItemsController : Controller
    {
        private GroceryApp2Context db = new GroceryApp2Context();

        // GET: GroceryItems
        public ActionResult Index()
        {
            return View(db.GroceryItems.ToList());
        }

        // GET: GroceryItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroceryItems groceryItems = db.GroceryItems.Find(id);
            if (groceryItems == null)
            {
                return HttpNotFound();
            }
            return View(groceryItems);
        }

        // GET: GroceryItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroceryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Item,Amount,Price")] GroceryItems groceryItems)
        {
            if (ModelState.IsValid)
            {
                db.GroceryItems.Add(groceryItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(groceryItems);
        }

        // GET: GroceryItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroceryItems groceryItems = db.GroceryItems.Find(id);
            if (groceryItems == null)
            {
                return HttpNotFound();
            }
            return View(groceryItems);
        }

        // POST: GroceryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Item,Amount,Price")] GroceryItems groceryItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groceryItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(groceryItems);
        }

        // GET: GroceryItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GroceryItems groceryItems = db.GroceryItems.Find(id);
            if (groceryItems == null)
            {
                return HttpNotFound();
            }
            return View(groceryItems);
        }

        // POST: GroceryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroceryItems groceryItems = db.GroceryItems.Find(id);
            db.GroceryItems.Remove(groceryItems);
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
