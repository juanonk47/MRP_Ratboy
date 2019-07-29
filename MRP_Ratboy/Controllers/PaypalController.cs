using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRP_Ratboy.Controllers
{
    public class PaypalController : Controller
    {
        // GET: Paypal
        public ActionResult Index()
        {
            return View();
        }

        // GET: Paypal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paypal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paypal/Create
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

        // GET: Paypal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paypal/Edit/5
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

        // GET: Paypal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paypal/Delete/5
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
