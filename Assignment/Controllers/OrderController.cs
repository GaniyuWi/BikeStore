using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Assignment.DataAccess.Data;
using Assignment.Models;
using Assignment.Models.VModels;
using Assignment.DataAccess.Repository.IRepository;

namespace Assignment.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _db;
        public OrderController(IUnitOfWork db)
        {
            _db = db;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            IEnumerable<Order> objlist = _db.Order.GetAll().ToList();
            foreach (Order obj in objlist)
            {
                obj.Customer = _db.Customer.Get(u => u.CustomerId == obj.CustomerId);
                obj.Store = _db.Store.Get(u => u.StoreId == obj.StoreId);
                obj.Staff = _db.Staff.Get(u => u.StaffId == obj.StaffId);
            }
            return View(objlist);
        }

        // POST: OrderController/Create
        public ActionResult Create()
        {
            OrderVM OrderVM = new OrderVM()
            {
                Order = new Order(),
                CustomerList = _db.Customer.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.CustomerId.ToString()

                }),
                StaffList = _db.Staff.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.StaffId.ToString()

                }),
                StoreList = _db.Store.GetAll().Select(u => new SelectListItem
                {
                    Text = u.StoreName,
                    Value = u.StoreId.ToString()
                }),
            };
            return View(OrderVM);
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Order.Add(obj.Order);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Order.Get(u=> u.OrderId==id);
            obj.Customer = _db.Customer.Get(u => u.CustomerId == obj.CustomerId);
            obj.Store = _db.Store.Get(u => u.StoreId == obj.StoreId);
            obj.Staff = _db.Staff.Get(u => u.StaffId == obj.StaffId);
            if (obj == null)
            {
                return NotFound();
            }
            OrderVM OrderVM = new OrderVM()
            {
                Order = obj,
                CustomerList = _db.Customer.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.CustomerId.ToString()

                }),
                StaffList = _db.Staff.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FirstName + " " + u.LastName,
                    Value = u.StaffId.ToString()

                }),
                StoreList = _db.Store.GetAll().Select(u => new SelectListItem
                {
                    Text = u.StoreName,
                    Value = u.StoreId.ToString()
                }),
            };
            return View(OrderVM);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Order.Update(obj.Order);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: OrderController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Order.Get(u => u.OrderId == id);
            obj.Customer = _db.Customer.Get(u => u.CustomerId == obj.CustomerId);
            obj.Store = _db.Store.Get(u => u.StoreId == obj.StoreId);
            obj.Staff = _db.Staff.Get(u => u.StaffId == obj.StaffId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Order obj)
        {
            //var obj = _db.Customers.Find(CUSTOMER_ID);
            //if (CUSTOMER_ID == null)
            //{
            //    return NotFound();
            //}
            _db.Order.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
