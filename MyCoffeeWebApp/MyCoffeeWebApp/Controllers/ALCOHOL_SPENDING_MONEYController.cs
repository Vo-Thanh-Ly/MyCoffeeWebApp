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
using PagedList.Mvc;
using Microsoft.Ajax.Utilities;
using PagedList;
using System.Web.UI;

namespace MyCoffeeWebApp.Controllers
{
    public class ALCOHOL_SPENDING_MONEYController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: ALCOHOL_SPENDING_MONEY
        public ActionResult Index(string str, int? page)
        {
            int pageIndex = (page ?? 1);
            int pageSize = 10;
            IPagedList<ALCOHOL_SPENDING_MONEY> aLCOHOL_SPENDING_MONEY;

            if (string.IsNullOrEmpty(str))
            {
                aLCOHOL_SPENDING_MONEY = db.ALCOHOL_SPENDING_MONEY
                                            .Include(a => a.DATE)
                                            .OrderBy(a => a.ALCOHOL_SPENDING_MONEY_ID)
                                            .ToPagedList(pageIndex, pageSize);
            }
            else
            {
                aLCOHOL_SPENDING_MONEY = db.ALCOHOL_SPENDING_MONEY
                                            .Where(ac => ac.ALCOHOL_SPENDING_MONEY_CONTENT.ToUpper().Contains(str.ToUpper()))
                                            .OrderBy(a => a.ALCOHOL_SPENDING_MONEY_ID)
                                            .ToPagedList(pageIndex, pageSize);
            }

            return View(aLCOHOL_SPENDING_MONEY);
        }
        // GET: ALCOHOL_SPENDING_MONEY/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALCOHOL_SPENDING_MONEY aLCOHOL_SPENDING_MONEY = await db.ALCOHOL_SPENDING_MONEY.FindAsync(id);
            if (aLCOHOL_SPENDING_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(aLCOHOL_SPENDING_MONEY);
        }

        // GET: ALCOHOL_SPENDING_MONEY/Create
        public ActionResult Create()
        {

            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "DATE_ID");
            return View();
        }

        // POST: ALCOHOL_SPENDING_MONEY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DATE_ID,ALCOHOL_SPENDING_MONEY_CONTENT,ALCOHOL_SPENDING_MONEY_QUANTITY,ALCOHOL_SPENDING_MONEY_NOTE")] ALCOHOL_SPENDING_MONEY aLCOHOL_SPENDING_MONEY)
        {
            if (ModelState.IsValid)
            {
                List<long> ids =  db.ALCOHOL_SPENDING_MONEY.Select(x=>x.ALCOHOL_SPENDING_MONEY_ID).ToList();
                aLCOHOL_SPENDING_MONEY.ALCOHOL_SPENDING_MONEY_ID = ids.Any() ? ids.Max() + 1 : 1;
                db.ALCOHOL_SPENDING_MONEY.Add(aLCOHOL_SPENDING_MONEY);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "date_name", aLCOHOL_SPENDING_MONEY.DATE_ID);
            return View(aLCOHOL_SPENDING_MONEY);
        }

        // GET: ALCOHOL_SPENDING_MONEY/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALCOHOL_SPENDING_MONEY aLCOHOL_SPENDING_MONEY = await db.ALCOHOL_SPENDING_MONEY.FindAsync(id);
            if (aLCOHOL_SPENDING_MONEY == null)
            {
                return HttpNotFound();
            }
            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "DATE_ID", aLCOHOL_SPENDING_MONEY.DATE_ID);
            return View(aLCOHOL_SPENDING_MONEY);
        }

        // POST: ALCOHOL_SPENDING_MONEY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ALCOHOL_SPENDING_MONEY_ID,DATE_ID,ALCOHOL_SPENDING_MONEY_CONTENT,ALCOHOL_SPENDING_MONEY_QUANTITY,ALCOHOL_SPENDING_MONEY_NOTE")] ALCOHOL_SPENDING_MONEY aLCOHOL_SPENDING_MONEY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLCOHOL_SPENDING_MONEY).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.DATE_ID = new SelectList(db.DATEs, "DATE_ID", "date_name", aLCOHOL_SPENDING_MONEY.DATE_ID);
            return View(aLCOHOL_SPENDING_MONEY);
        }

        // GET: ALCOHOL_SPENDING_MONEY/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALCOHOL_SPENDING_MONEY aLCOHOL_SPENDING_MONEY = await db.ALCOHOL_SPENDING_MONEY.FindAsync(id);
            if (aLCOHOL_SPENDING_MONEY == null)
            {
                return HttpNotFound();
            }
            return View(aLCOHOL_SPENDING_MONEY);
        }

        // POST: ALCOHOL_SPENDING_MONEY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            ALCOHOL_SPENDING_MONEY aLCOHOL_SPENDING_MONEY = await db.ALCOHOL_SPENDING_MONEY.FindAsync(id);
            db.ALCOHOL_SPENDING_MONEY.Remove(aLCOHOL_SPENDING_MONEY);
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
