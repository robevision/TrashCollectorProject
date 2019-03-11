using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trash_Collector_Project.Models;

namespace Trash_Collector_Project.Controllers
{
    public class EmployeeController : Controller
    {
        public ApplicationDbContext context;
        public CustomerAddressViewModels customerAddresses = new CustomerAddressViewModels();
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var employeeZipCode = context.Employees.Select(e => e.ZipCode).Single();
            var customerswithZipCode = customerAddresses.Addresses.Where(a => a.ZipCode == employeeZipCode).Select(a => a.Customer);
            var customers = from c in customerswithZipCode select c;
            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.PickupDay.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    customers = customers.OrderByDescending(c => c.LastName);
                    break;
                case "Date":
                    customers = customers.OrderBy(c => c.PickupDay);
                    break;
                case "date_desc":
                    customers = customers.OrderByDescending(c => c.PickupDay);
                    break;
                default:
                    customers = customers.OrderBy(c => c.LastName);
                    break;
            }
            return View(customers.ToList());
        }

        // GET: Employee/Details/5
        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(context.Employees, "Id", "ZipCode");
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Employees.Add(employee);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
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

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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
