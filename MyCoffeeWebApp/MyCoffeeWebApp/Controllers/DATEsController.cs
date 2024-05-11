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
    public class DATEsController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: DATEs
        public async Task<ActionResult> Index()
        {
            return View(await db.DATEs.ToListAsync());
        }

        // GET: DATEs/Details/5
        public async Task<ActionResult> Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATE dATE = await db.DATEs.FindAsync(id);
            if (dATE == null)
            {
                return HttpNotFound();
            }
            return View(dATE);
        }

        // GET: DATEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DATEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DATE1,date_name,note")] DATE dATE)
        {
            if (ModelState.IsValid)
            {
                db.DATEs.Add(dATE);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(dATE);
        }

        // GET: DATEs/Edit/5
        public async Task<ActionResult> Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATE dATE = await db.DATEs.FindAsync(id);
            if (dATE == null)
            {
                return HttpNotFound();
            }
            return View(dATE);
        }

        // POST: DATEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DATE1,date_name,note")] DATE dATE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dATE).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dATE);
        }

        // GET: DATEs/Delete/5
        public async Task<ActionResult> Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DATE dATE = await db.DATEs.FindAsync(id);
            if (dATE == null)
            {
                return HttpNotFound();
            }
            return View(dATE);
        }

        // POST: DATEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(DateTime id)
        {
            DATE dATE = await db.DATEs.FindAsync(id);
            db.DATEs.Remove(dATE);
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
