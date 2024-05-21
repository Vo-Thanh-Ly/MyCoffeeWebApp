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
    public class ALCOHOL_COLLECTS_MONEYController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: ALCOHOL_COLLECTS_MONEY
        public async Task<ActionResult> Index()
        {
            var aLCOHOL_COLLECTS_MONEY = db.ALCOHOL_COLLECTS_MONEY.Include(a => a.DATE).Include(a => a.TYPE_OF_WINE);
            return View(await aLCOHOL_COLLECTS_MONEY.ToListAsync());
        }

        // GET: ALCOHOL_COLLECTS_MONEY/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALCOHOL_COLLECTS_MONEY aLCOHOL_COLLECTS_MONEY = await db.ALCOHOL_COLLECTS_MONEY.FindAsync(id);
            if (aLCOHOL_COLLECTS_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(aLCOHOL_COLLECTS_MONEY);
        }

        // GET: ALCOHOL_COLLECTS_MONEY/Create
        public ActionResult Create()
        {
            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "date_name");
            ViewBag.TYPE_OF_WINE_ID = new SelectList(db.TYPE_OF_WINE, "TYPE_OF_WINE_ID", "TYPE_OF_WINE_NAME");
            return View();
        }

        // POST: ALCOHOL_COLLECTS_MONEY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ALCOHOL_COLLECTS_MONEY_QUANTITY,DATE_ID,TYPE_OF_WINE_ID,ALCOHOL_COLLECTS_MONEY_PRICE,ALCOHOL_COLLECTS_MONEY_ID")] ALCOHOL_COLLECTS_MONEY aLCOHOL_COLLECTS_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.ALCOHOL_COLLECTS_MONEY.Add(aLCOHOL_COLLECTS_MONEY);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "date_name", aLCOHOL_COLLECTS_MONEY.DATE_ID);
            ViewBag.TYPE_OF_WINE_ID = new SelectList(db.TYPE_OF_WINE, "TYPE_OF_WINE_ID", "TYPE_OF_WINE_NAME", aLCOHOL_COLLECTS_MONEY.TYPE_OF_WINE_ID);
            return View(aLCOHOL_COLLECTS_MONEY);
        }

        // GET: ALCOHOL_COLLECTS_MONEY/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALCOHOL_COLLECTS_MONEY aLCOHOL_COLLECTS_MONEY = await db.ALCOHOL_COLLECTS_MONEY.FindAsync(id);
            if (aLCOHOL_COLLECTS_MONEY == null)
            {
                return HttpNotFound();
            }
            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "date_name", aLCOHOL_COLLECTS_MONEY.DATE_ID);
            ViewBag.TYPE_OF_WINE_ID = new SelectList(db.TYPE_OF_WINE, "TYPE_OF_WINE_ID", "TYPE_OF_WINE_NAME", aLCOHOL_COLLECTS_MONEY.TYPE_OF_WINE_ID);
            return View(aLCOHOL_COLLECTS_MONEY);
        }

        // POST: ALCOHOL_COLLECTS_MONEY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ALCOHOL_COLLECTS_MONEY_QUANTITY,DATE_ID,TYPE_OF_WINE_ID,ALCOHOL_COLLECTS_MONEY_PRICE,ALCOHOL_COLLECTS_MONEY_ID")] ALCOHOL_COLLECTS_MONEY aLCOHOL_COLLECTS_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLCOHOL_COLLECTS_MONEY).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "date_name", aLCOHOL_COLLECTS_MONEY.DATE_ID);
            ViewBag.TYPE_OF_WINE_ID = new SelectList(db.TYPE_OF_WINE, "TYPE_OF_WINE_ID", "TYPE_OF_WINE_NAME", aLCOHOL_COLLECTS_MONEY.TYPE_OF_WINE_ID);
            return View(aLCOHOL_COLLECTS_MONEY);
        }

        // GET: ALCOHOL_COLLECTS_MONEY/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALCOHOL_COLLECTS_MONEY aLCOHOL_COLLECTS_MONEY = await db.ALCOHOL_COLLECTS_MONEY.FindAsync(id);
            if (aLCOHOL_COLLECTS_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(aLCOHOL_COLLECTS_MONEY);
        }

        // POST: ALCOHOL_COLLECTS_MONEY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ALCOHOL_COLLECTS_MONEY aLCOHOL_COLLECTS_MONEY = await db.ALCOHOL_COLLECTS_MONEY.FindAsync(id);
            db.ALCOHOL_COLLECTS_MONEY.Remove(aLCOHOL_COLLECTS_MONEY);
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
