using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpify_v3.Data.Model
{
    public class UserProjectLookup
    {
        public int UserProjectLookupId {get; set;}

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }
    }
}
