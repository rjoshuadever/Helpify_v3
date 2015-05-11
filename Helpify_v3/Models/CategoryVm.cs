using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpify_v3.Models
{
    public class CategoryVm
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public class CreateCategoryVM
    {
        public string CategoryName { get; set; }
    }
}