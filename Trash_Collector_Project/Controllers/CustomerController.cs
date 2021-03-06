﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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
            try
            {
                var user = User.Identity.GetUserId();
                string userFirstName = context.Customers.Where(c => c.UserId == user).Select(c => c.FirstName).Single();
                ViewBag.Name = userFirstName;
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            try
            {
                string userId = User.Identity.GetUserId();
                var user = context.Customers.Where(c => c.UserId == userId).Single();
                if (user.PickupTotalFromMonth != 0)
                {
                    ViewBag.amount = 30 * user.PickupTotalFromMonth;
                }
                else
                {
                    ViewBag.amount = 0;
                }
                return View(user);
            }
            catch
            {
                return RedirectToAction("Index");

            }
          
        }
        //GET: Customer/Suspend
        public ActionResult Suspend()
        {
            string userId = User.Identity.GetUserId();

            Customer customer = context.Customers.Where(c => c.UserId == userId).Select(c => c).Single();
            return View(customer);

        }

        // POST: Customer/Suspend
        [HttpPost]
        public ActionResult Suspend(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int id = customer.ID;
                    Customer updatedCustomers = context.Customers.Where(c => c.ID == id).Select(c => c).Single();
                    updatedCustomers.StartBreak = customer.StartBreak;
                    updatedCustomers.EndBreak = customer.EndBreak;
                    context.SaveChanges();
                    if(DateTime.Now >= customer.StartBreak && DateTime.Now <= customer.EndBreak)
                    {
                        customer.Pickup = false;

                    }
                    string day = DateTime.Today.DayOfWeek.ToString();
                    if (DateTime.Now < customer.StartBreak && DateTime.Now > customer.EndBreak && day == customer.PickupDay)
                    {
                        customer.Pickup = true;
                    }
                    var startText = customer.StartBreak.ToString();
                    //DateTime start = Convert.ToInt16(startText);
                    //List<DateTime?> dateList = new List<DateTime?>();while (start.)
                    //foreach (DateTime day in start.(customer.EndBreak))
                    //{

                    //}
                    
                    return RedirectToAction("Index");
                }

                return View(customer);
            }
            catch
            {
                return View();
            }
        }
        // GET: Customer/Create
        public ActionResult Create()
        {
            ViewBag.ID = new SelectList(context.Customers, "Id", "Name");
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer, Address address)
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
        [HttpGet]
        public ActionResult Edit(string userId)
        {
      
                CustomerAddressViewModels customerAddress = new CustomerAddressViewModels();
                userId = User.Identity.GetUserId();
                var id = context.Customers.Where(c => c.UserId == userId).Select(c => c.ID).Single();
                customerAddress.Customer = context.Customers.Where(c => c.ID == id).Single();
                var customerId = context.Customers.Where(c => c.ID == customerAddress.Customer.ID).Select(c => c.ID).Single();
                customerAddress.Address = context.Addresses.Where(a => a.CustomerId == id).Single();
                return View(customerAddress);
            
           
               
            
            
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(CustomerAddressViewModels customerAddress)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Customer customer = context.Customers.Where(c => c.ID == customerAddress.Customer.ID).Single();
                    //customer.FirstName = customerAddress.Customer.FirstName;
                    //customer.LastName = customerAddress.Customer.LastName;
                    //customer.ExtraPickup = customerAddress.Customer.ExtraPickup;
                    context.Entry(customerAddress.Customer).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    context.Entry(customerAddress.Address).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                }
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
