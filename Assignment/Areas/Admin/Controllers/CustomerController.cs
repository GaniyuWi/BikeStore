﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assignment.DataAccess.Data;
using Assignment.Models;
using Assignment.DataAccess.Repository.IRepository;

namespace Assignment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _db;
        private string message = "Customer";
        public CustomerController(IUnitOfWork db)
        {
            _db = db;
        }
        // GET: Customer1Controller
        public ActionResult Index()
        {
            IEnumerable<Customer> objlist = _db.Customer.GetAll().ToList();
            return View(objlist);
        }

        // GET: Customer1Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer1Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customer.Add(obj);
                _db.Save();
                TempData["success"] = message + " Created sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Customer1Controller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Customer.Get(u => u.CustomerId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Customer1Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customer.Update(obj);
                _db.Save();
                TempData["success"] = message + " updated sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Customer1Controller/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Customer.Get(u => u.CustomerId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Customer1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Customer obj)
        {
            //var obj = _db.Customers.Find(CUSTOMER_ID);
            //if (CUSTOMER_ID == null)
            //{
            //    return NotFound();
            //}
            _db.Customer.Remove(obj);
            _db.Save();
            TempData["success"] = message + " deleted sucessfully";
            return RedirectToAction("Index");
        }
    }
}
