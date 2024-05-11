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
    public class COLLECT_MONEYController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: COLLECT_MONEY
        public async Task<ActionResult> Index()
        {
            var cOLLECT_MONEY = db.COLLECT_MONEY.Include(c => c.DATE1).Include(c => c.MENU);
            return View(await cOLLECT_MONEY.ToListAsync());
        }

        // GET: COLLECT_MONEY/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECT_MONEY cOLLECT_MONEY = await db.COLLECT_MONEY.FindAsync(id);
            if (cOLLECT_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(cOLLECT_MONEY);
        }

        // GET: COLLECT_MONEY/Create
        public ActionResult Create()
        {
            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note");
            ViewBag.MN_ID = new SelectList(db.MENUs, "MN_ID", "MN_PRODUCTNAME");
            return View();
        }

        // POST: COLLECT_MONEY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CLMN_ID,DATE,MN_ID,CLMN_QUANLITY,CLMN_PRICE,CLMN_NOTE")] COLLECT_MONEY cOLLECT_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.COLLECT_MONEY.Add(cOLLECT_MONEY);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note", cOLLECT_MONEY.DATE);
            ViewBag.MN_ID = new SelectList(db.MENUs, "MN_ID", "MN_PRODUCTNAME", cOLLECT_MONEY.MN_ID);
            return View(cOLLECT_MONEY);
        }

        // GET: COLLECT_MONEY/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECT_MONEY cOLLECT_MONEY = await db.COLLECT_MONEY.FindAsync(id);
            if (cOLLECT_MONEY == null)
            {
                return HttpNotFound();
            }
            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note", cOLLECT_MONEY.DATE);
            ViewBag.MN_ID = new SelectList(db.MENUs, "MN_ID", "MN_PRODUCTNAME", cOLLECT_MONEY.MN_ID);
            return View(cOLLECT_MONEY);
        }

        // POST: COLLECT_MONEY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CLMN_ID,DATE,MN_ID,CLMN_QUANLITY,CLMN_PRICE,CLMN_NOTE")] COLLECT_MONEY cOLLECT_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLLECT_MONEY).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DATE = new SelectList(db.DATEs, "DATE1", "note", cOLLECT_MONEY.DATE);
            ViewBag.MN_ID = new SelectList(db.MENUs, "MN_ID", "MN_PRODUCTNAME", cOLLECT_MONEY.MN_ID);
            return View(cOLLECT_MONEY);
        }

        // GET: COLLECT_MONEY/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLLECT_MONEY cOLLECT_MONEY = await db.COLLECT_MONEY.FindAsync(id);
            if (cOLLECT_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(cOLLECT_MONEY);
        }

        // POST: COLLECT_MONEY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            COLLECT_MONEY cOLLECT_MONEY = await db.COLLECT_MONEY.FindAsync(id);
            db.COLLECT_MONEY.Remove(cOLLECT_MONEY);
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
