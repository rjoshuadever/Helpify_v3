using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helpify_v3.Models
{
    public class ProjectVm
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }


        //Foreign Keys
        public int CategoryId { get; set; }

    }
}
