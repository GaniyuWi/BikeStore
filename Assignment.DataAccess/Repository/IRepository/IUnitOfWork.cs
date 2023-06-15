using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IStaffRepository Staff { get; }
        IStoreRepository Store { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IBrandRepository Brand { get; }
        IStockRepository Stock { get; }
        void Save();

    }
}
