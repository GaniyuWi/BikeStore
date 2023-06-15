using Assignment.DataAccess.Data;
using Assignment.DataAccess.Repository.IRepository;
using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
            
        }

        public void Update(Product product)
        {
           var Product = _db.Product.FirstOrDefault(u => u.ProductId == product.ProductId);
            if(Product != null)
            {
                Product.ProductId = product.ProductId;
                Product.ProductName = product.ProductName;
                Product.BrandId = product.BrandId;
                Product.CategoryId = product.CategoryId;
                Product.ListPrice = product.ListPrice;
                Product.ModelYear = product.ModelYear;
                if(product.ImageUrl != null)
                { 
                Product.ImageUrl = product.ImageUrl;
                }
            }
            _db.Product.Update(product);
        }
    }
}
