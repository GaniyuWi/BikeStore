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
    public class StaffRepository:Repository<Staff>, IStaffRepository
    {
        private ApplicationDbContext _db;
        public StaffRepository( ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }

        public void Update(Staff staff)
        {
            _db.Staff.Update(staff);
        }
    }
}
