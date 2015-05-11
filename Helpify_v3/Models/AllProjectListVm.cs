using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpify_v3.Models
{
    public class AllProjectListVm
    {
        public List<ProjectVm> ProjectList { get; set; }
        public string Name { get; set; }
    }
}