using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpify_v3.Data.Model
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }


        //Foreign Keys
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public List<Tag> TagList { get; set; }

        public List<ImageUrl> ImageList { get; set; }
    }
}
