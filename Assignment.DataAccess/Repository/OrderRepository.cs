using Assignment.DataAccess.Data;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DataAccess.Repository.IRepository;

namespace Assignment.DataAccess.Repository
{
    public class OrderRepository:Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext _db;
        public OrderRepository( ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }

        public void Update(Order order)
        {
            _db.Order.Update(order);
        }
    }
}
