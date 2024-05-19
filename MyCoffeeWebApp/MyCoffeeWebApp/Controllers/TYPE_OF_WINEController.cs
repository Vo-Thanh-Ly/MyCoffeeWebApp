using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCoffeeWebApp;

namespace MyCoffeeWebApp.Controllers
{
    public class TYPE_OF_WINEController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: TYPE_OF_WINE
        public ActionResult Index(string str)
        {
            List<TYPE_OF_WINE> resual = new List<TYPE_OF_WINE>();
            if (str == null)
            {
                resual = db.TYPE_OF_WINE.ToList();
            }
            else
            {
                resual = db.TYPE_OF_WINE.Where(r => r.TYPE_OF_WINE_NAME.Contains(str)).ToList();

            }
            return View(resual);

        }

        // GET: TYPE_OF_WINE/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_OF_WINE tYPE_OF_WINE = await db.TYPE_OF_WINE.FindAsync(id);
            if (tYPE_OF_WINE == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_OF_WINE);
        }

        // GET: TYPE_OF_WINE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TYPE_OF_WINE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TYPE_OF_WINE_ID,TYPE_OF_WINE_NAME,TYPE_OF_WINE_PRICE")] TYPE_OF_WINE tYPE_OF_WINE)
        {
            if (ModelState.IsValid)
            {
                db.TYPE_OF_WINE.Add(tYPE_OF_WINE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tYPE_OF_WINE);
        }

        // GET: TYPE_OF_WINE/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_OF_WINE tYPE_OF_WINE = await db.TYPE_OF_WINE.FindAsync(id);
            if (tYPE_OF_WINE == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_OF_WINE);
        }

        // POST: TYPE_OF_WINE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TYPE_OF_WINE_ID,TYPE_OF_WINE_NAME,TYPE_OF_WINE_PRICE")] TYPE_OF_WINE tYPE_OF_WINE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tYPE_OF_WINE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tYPE_OF_WINE);
        }

        // GET: TYPE_OF_WINE/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_OF_WINE tYPE_OF_WINE = await db.TYPE_OF_WINE.FindAsync(id);
            if (tYPE_OF_WINE == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_OF_WINE);
        }

        // POST: TYPE_OF_WINE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TYPE_OF_WINE tYPE_OF_WINE = await db.TYPE_OF_WINE.FindAsync(id);
            db.TYPE_OF_WINE.Remove(tYPE_OF_WINE);
            await db.SaveChangesAsync();
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
