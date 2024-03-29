﻿using Assignment.DataAccess.Data;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.DataAccess.Repository.IRepository;

namespace Assignment.DataAccess.Repository
{
    public class CustomerRepository:Repository<Customer>, ICustomerRepository
    {
        private ApplicationDbContext _db;
        public CustomerRepository( ApplicationDbContext db) : base(db)
        { 
            _db = db;
        }

        public void Update(Customer customer)
        {
            _db.Customer.Update(customer);
        }
    }
}
