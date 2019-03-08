using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            var user = User.Identity.GetUserId();
            var userFirstName = context.Customers.Where(c => c.UserId == user).Select(c => c.FirstName).Single();
            ViewBag.Name = userFirstName;
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
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PickupDay,Pickup")] Customer customer, Address address)
        {
            var user = User.Identity.GetUserId();
            address.CustomerId = customer.ID;
            customer.UserId = user;
            try
            {
                if (ModelState.IsValid)
                {
                    context.Addresses.Add(address);
                    context.Customers.Add(customer);
                    context.SaveChanges();
                    switch (customer.PickupDay)
                    {
                        case "Monday":
                            customer.Pickup = true;
                            break;
                        case "Tuesday":
                            customer.Pickup = true;
                            break;
                        case "Wednesday":
                            customer.Pickup = true;
                            break;
                        case "Thursday":
                            customer.Pickup = true;
                            break;
                        case "Friday":
                            customer.Pickup = true;
                            break;
                        case "Saturday":
                            customer.Pickup = true;
                            break;
                        case null:
                            customer.Pickup = false;
                            break;
                        default:
                            customer.Pickup = false;
                            break;
                    }
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit()
        {
            CustomerAddressViewModels customerAddress = new CustomerAddressViewModels();
            var userId = User.Identity.GetUserId();
            var id = context.Customers.Where(c => c.UserId == userId).Select(c => c.ID).Single();
            customerAddress.Customer = context.Customers.Where(c => c.ID == id).Single();
            customerAddress.Address = context.Addresses.Where(a => a.CustomerId == id).Single();
            return View(customerAddress);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "ID,FirstName,LastName,PickupDay,Pickup")] CustomerAddressViewModels customerAddress)
        {
            try
            {
                context.Entry(customerAddress).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
              
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
