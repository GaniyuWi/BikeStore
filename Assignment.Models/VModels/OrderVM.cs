using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Assignment.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Assignment.Models.VModels
{
    public class OrderVM
    {
        public Order Order { get; set; }
        //[ValidateNever]
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        //[ValidateNever]
        public IEnumerable<SelectListItem> StaffList { get; set; }
        ////[ValidateNever]
        public IEnumerable<SelectListItem> StoreList { get; set; }
    }
}
