using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collector_Project.Models;

namespace Trash_Collector_Project.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext context;
        // GET: Customer
       public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(context.Customers, "Id", "Name");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,,AlternativeAbility,CatchPhrase")] Customer customer)
        {
            var user = User.Identity.GetUserId();
            customer.UserId = user;
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
