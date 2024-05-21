using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCoffeeWebApp.Controllers
{
    public class CharController : Controller
    {
        // GET: Char
        public ActionResult Index()
        {
            return View();
        }

        // GET: Char/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Char/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Char/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Char/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Char/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Char/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Char/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
