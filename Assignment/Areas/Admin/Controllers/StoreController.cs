﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assignment.DataAccess.Data;
using Assignment.Models;
using Assignment.DataAccess.Repository.IRepository;

namespace Assignment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoreController : Controller
    {
        private readonly IUnitOfWork _db;
        private string message = "Store";
        public StoreController(IUnitOfWork db)
        {
            _db = db;
        }
        // GET: StoreController
        public ActionResult Index()
        {
            IEnumerable<Store> objlist = _db.Store.GetAll().ToList();
            return View(objlist);
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store obj)
        {
            if (ModelState.IsValid)
            {
                _db.Store.Add(obj);
                _db.Save();
                TempData["success"] = message + " created sucessfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        // POST: StoreController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Store.Get(u => u.StoreId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Store obj)
        {
            if (ModelState.IsValid)
            {
                _db.Store.Update(obj);
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
            var obj = _db.Store.Get(u => u.StoreId == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Customer1Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Store obj)
        {
            //var obj = _db.Customers.Find(CUSTOMER_ID);
            //if (CUSTOMER_ID == null)
            //{
            //    return NotFound();
            //}
            _db.Store.Remove(obj);
            _db.Save();
            TempData["success"] = message + " deleted sucessfully";
            return RedirectToAction("Index");
        }
    }
}
