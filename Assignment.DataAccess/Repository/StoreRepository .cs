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
    public class StoreRepository:Repository<Store>, IStoreRepository
    {
        private ApplicationDbContext _db;
        public StoreRepository( ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }

        public void Update(Store store)
        {
            _db.Store.Update(store);
        }
    }
}
