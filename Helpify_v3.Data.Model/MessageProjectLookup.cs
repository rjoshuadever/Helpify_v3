using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpify_v3.Data.Model
{
    public class MessageProjectLookup
    {
       public int MessageProjectLookupId {get; set;}

       public int MessageId { get; set; }
       public virtual Message Message { get; set; }

       public int ProjectId { get; set; }
       public virtual Project Project { get; set; }


    }
}
