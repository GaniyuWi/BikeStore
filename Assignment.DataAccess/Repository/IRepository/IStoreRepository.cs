using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess.Repository.IRepository
{
    public interface IStoreRepository : IRepository<Store>
    {
        void Update (Store store);
    }
}
