using Assignment.DataAccess.Data;
using Assignment.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public ICustomerRepository Customer {get; private set;}
        public IStaffRepository Staff { get; private set;}
        public IOrderRepository Order { get; private set;}
        public IStoreRepository Store { get; private set;}
        public IProductRepository Product { get; private set;}
        public ICategoryRepository Category { get; private set;}
        public IBrandRepository Brand { get; private set;}
        public IStockRepository Stock { get; private set;}

        private ApplicationDbContext _db;
        public UnitOfWork (ApplicationDbContext db)
        {
            _db = db;
            Customer = new CustomerRepository(_db);
            Staff = new StaffRepository(_db);
            Order = new OrderRepository(_db);
            Store = new StoreRepository(_db);
            Product = new ProductRepository(_db);
            Category = new CategoryRepository(_db);
            Brand = new BrandRepository(_db);
            Stock = new StockRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
