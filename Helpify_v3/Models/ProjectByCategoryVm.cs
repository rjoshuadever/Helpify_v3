using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpify_v3.Models
{
    public class ProjectByCategoryVm
    {
        public List<ProjectVm> ProjectByCategoryList { get; set; }
        public string PageTitle { get; set; }
    }
}