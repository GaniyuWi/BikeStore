using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using Assignment.DataAccess.Data;
using Assignment.Models;
using Assignment.Models.VModels;
using Assignment.DataAccess.Repository.IRepository;

namespace Assignment.Controllers
{
    public class StaffController : Controller
    {
        private readonly IUnitOfWork _db;
        public StaffController(IUnitOfWork db)
        {
            _db = db;
        }
        // GET: StaffController
        public ActionResult Index()
        {
            IEnumerable<Staff> objlist = _db.Staff.GetAll().ToList();
            foreach (Staff obj in objlist)
            {
                obj.Store = _db.Store.Get(u => u.StoreId == obj.StoreId);
                obj.Manager = _db.Staff.Get(u => u.StaffId == obj.ManagerId);
            }
            return View(objlist);
        }
        public ActionResult Create()
        {
            StaffVM staffVM = new StaffVM()
            {
                Staff = new Staff(),
                ManagerList = _db.Staff.GetAll().Select(u => new SelectListItem
                {
                    Text= u.FirstName +" "+ u.LastName,
                    Value=u.StaffId.ToString()

                }),
                StoreList = _db.Store.GetAll().Select(u => new SelectListItem
                {
                    Text = u.StoreName,
                    Value = u.StoreId.ToString()
                }),
            };
            return View(staffVM);
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Staff.Add(obj.Staff);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Staff.Get(u => u.StaffId==id);
            if (obj == null)
            {
                return NotFound();
            }
            StaffVM staffVM = new StaffVM()
            {
                Staff = obj,
                ManagerList = _db.Staff.GetAll().Select(u => new SelectListItem
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
            return View(staffVM);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Staff.Update(obj.Staff);
                _db.Save();
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: StaffController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Staff.Get(u => u.StaffId == id);
            obj.Store = _db.Store.Get(u => u.StoreId == obj.StoreId);
            obj.Manager = _db.Staff.Get(u => u.StaffId == obj.ManagerId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Staff obj)
        {
            //var obj = _db.Customers.Find(CUSTOMER_ID);
            //if (CUSTOMER_ID == null)
            //{
            //    return NotFound();
            //}
            _db.Staff.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
