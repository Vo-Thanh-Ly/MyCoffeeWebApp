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
using System.Drawing.Printing;

namespace MyCoffeeWebApp.Controllers
{
    public class MENUsController : Controller
    {
        private MyCoffeeWebAppEntities db = new MyCoffeeWebAppEntities();

        // GET: MENUs
        public async Task<ActionResult> Index(string str)
        {
            if (str == null)
            {
                return View(await db.MENUs.ToListAsync());
            }
            else
            {
                // Chuyển str và d.MN_PRODUCTNAME sang cùng một kiểu chữ
                str = str.ToUpper();

                // Sử dụng Contains để tìm kiếm các bản ghi có MN_PRODUCTNAME chứa str
                var searchResults = await db.MENUs.Where(d => d.MN_PRODUCTNAME.ToUpper().Contains(str)).ToListAsync();

                return View(searchResults);
            }
        }



        // GET: MENUs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = await db.MENUs.FindAsync(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // GET: MENUs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MENUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MN_ID,MN_PRODUCTNAME,MN_PRICE")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.MENUs.Add(mENU);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(mENU);
        }

        // GET: MENUs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = await db.MENUs.FindAsync(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: MENUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MN_ID,MN_PRODUCTNAME,MN_PRICE")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mENU).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(mENU);
        }

        // GET: MENUs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = await db.MENUs.FindAsync(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: MENUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MENU mENU = await db.MENUs.FindAsync(id);
            db.MENUs.Remove(mENU);
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
