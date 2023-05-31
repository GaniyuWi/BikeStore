using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Assignment.Models;

namespace Assignment.Models.VModels
{
    public class OrderVM
    {
        public Order Order { get; set; }
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> StaffList { get; set; }
        public IEnumerable<SelectListItem> StoreList { get; set; }
    }
}
