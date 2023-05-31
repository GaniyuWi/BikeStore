using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Assignment.Models;

namespace Assignment.Models.VModels
{
    public class StaffVM
    {
        public Staff Staff { get; set; }
        public IEnumerable<SelectListItem> ManagerList { get; set; }
        public IEnumerable<SelectListItem> StoreList { get; set; }
    }
}
