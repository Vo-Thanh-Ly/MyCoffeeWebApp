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
    public class SPENDING_MONEYController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: SPENDING_MONEY
        public async Task<ActionResult> Index()
        {
            var sPENDING_MONEY = db.SPENDING_MONEY.Include(s => s.DATE1);
            return View(await sPENDING_MONEY.ToListAsync());
        }

        // GET: SPENDING_MONEY/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPENDING_MONEY sPENDING_MONEY = await db.SPENDING_MONEY.FindAsync(id);
            if (sPENDING_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(sPENDING_MONEY);
        }

        // GET: SPENDING_MONEY/Create
        public ActionResult Create()
        {
            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note");
            return View();
        }

        // POST: SPENDING_MONEY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SPENDING_ID,DATE,SPENDING_CONTENT,SPENDING_QUANLITY,SPENDING_PRICE,SPENDING_NOTE")] SPENDING_MONEY sPENDING_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.SPENDING_MONEY.Add(sPENDING_MONEY);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note", sPENDING_MONEY.DATE);
            return View(sPENDING_MONEY);
        }

        // GET: SPENDING_MONEY/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPENDING_MONEY sPENDING_MONEY = await db.SPENDING_MONEY.FindAsync(id);
            if (sPENDING_MONEY == null)
            {
                return HttpNotFound();
            }
            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note", sPENDING_MONEY.DATE);
            return View(sPENDING_MONEY);
        }

        // POST: SPENDING_MONEY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SPENDING_ID,DATE,SPENDING_CONTENT,SPENDING_QUANLITY,SPENDING_PRICE,SPENDING_NOTE")] SPENDING_MONEY sPENDING_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sPENDING_MONEY).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note", sPENDING_MONEY.DATE);
            return View(sPENDING_MONEY);
        }

        // GET: SPENDING_MONEY/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SPENDING_MONEY sPENDING_MONEY = await db.SPENDING_MONEY.FindAsync(id);
            if (sPENDING_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(sPENDING_MONEY);
        }

        // POST: SPENDING_MONEY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            SPENDING_MONEY sPENDING_MONEY = await db.SPENDING_MONEY.FindAsync(id);
            db.SPENDING_MONEY.Remove(sPENDING_MONEY);
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
