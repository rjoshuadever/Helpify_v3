using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpify_v3.Adapters
{
    public interface IProjectMessagesInterface
    {
        MessageListVm GetMessagesByProject(int id);
    }
}
