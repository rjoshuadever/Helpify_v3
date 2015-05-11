using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Helpify_v3.Models
{
    public class MessageVm
    {
        public int MessageId { get; set; }
        [DisplayName("Sender Name")]

        public string SenderName { get; set; }

        public string Location { get; set; }

        public string MessageBody { get; set; }

        public int ProjectId { get; set; }
    }
}