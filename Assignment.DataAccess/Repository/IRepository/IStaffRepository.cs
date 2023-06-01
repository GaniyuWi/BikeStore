using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DataAccess.Repository.IRepository
{
    public interface IStaffRepository : IRepository<Staff>
    {
        void Update (Staff staff);
    }
}
