 using Assignment.DataAccess.Repository.IRepository;
using Assignment.Models;
using Assignment.Models.VModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assignment.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private readonly IUnitOfWork _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private string message = "Product";
        private string status;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            IEnumerable<Product> objlist = _db.Product.GetAll(IncludeProperties: "Category,Brand").ToList();
            //foreach (Product obj in objlist)
            //{
            //    obj.Category = _db.Category.Get(u => u.CategoryId == obj.CategoryId);
            //    obj.Brand = _db.Brand.Get(u => u.BrandId == obj.BrandId);
            //}
            return View(objlist);
        }
        // POST: OrderController/Create
        public ActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _db.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()

                }),
                BrandList = _db.Brand.GetAll().Select(u => new SelectListItem
                {
                    Text = u.BrandName,
                    Value = u.BrandId.ToString()

                }),
            };
            if( id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                // Edit
                productVM.Product = _db.Product.Get(u => u.ProductId == id);
                return View(productVM);
            }    
        }

        // POST: OrderController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Upsert(ProductVM productVM, IFormFile? file )
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetFileName(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Products");
                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImagePath =
                            Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\Images\Products\" + fileName;
                }

                if(productVM.Product.ProductId == 0)
                {
                    _db.Product.Add(productVM.Product);
                    status = "Added";
                }
                else
                {
                    _db.Product.Update(productVM.Product);
                    status = "Updated";
                }
                _db.Save();
                TempData["success"] = message+" "+status+" sucessfully";
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _db.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()

                });
                productVM.BrandList = _db.Brand.GetAll().Select(u => new SelectListItem
                {
                    Text = u.BrandName,
                    Value = u.BrandId.ToString()

                });
                return View(productVM);
            }
        }

        // GET: OrderController/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Product.Get(u => u.ProductId == id);
        //    obj.Category = _db.Category.Get(u => u.CategoryId == obj.CategoryId);
        //    obj.Brand = _db.Brand.Get(u => u.BrandId == obj.BrandId);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    ProductVM productVM = new ProductVM()
        //    {
        //        Product = obj,
        //        CategoryList = _db.Category.GetAll().Select(u => new SelectListItem
        //        {
        //            Text = u.CategoryName,
        //            Value = u.CategoryId.ToString()

        //        }),
        //        BrandList = _db.Brand.GetAll().Select(u => new SelectListItem
        //        {
        //            Text = u.BrandName,
        //            Value = u.BrandId.ToString()

        //        }),
        //    };
        //    return View(productVM);
        //}

        //// POST: OrderController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(ProductVM obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Product.Update(obj.Product);
        //        _db.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // GET: OrderController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Product.Get(u => u.ProductId == id);
            obj.Category = _db.Category.Get(u => u.CategoryId == obj.CategoryId);
            obj.Brand = _db.Brand.Get(u => u.BrandId == obj.BrandId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Product obj)
        {
            //var obj = _db.Customers.Find(CUSTOMER_ID);
            //if (CUSTOMER_ID == null)
            //{
            //    return NotFound();
            //}
            _db.Product.Remove(obj);
            _db.Save();
            TempData["success"] = message + " deleted sucessfully";
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public ActionResult GetAll()
        {
            List<Product> objlist = _db.Product.GetAll(IncludeProperties: "Category,Brand").ToList();
            return Json(new{data = objlist});
        }
        #endregion
    }

}
