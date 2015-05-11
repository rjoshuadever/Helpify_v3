using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpify_v3.Data;

namespace Helpify_v3.Adapters.DataAdapters
{
    public class GetMessagesAdapter : IProjectMessagesInterface
    {
        public MessageListVm GetMessagesByProject(int id)
        {
            MessageListVm Mvm = new MessageListVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Mvm.MessagesByProject = db.MessageProjects.Where(p => p.ProjectId == id).Select(m => new MessageVm
                {
                    SenderName = m.Message.SenderName,
                    Location = m.Message.Location,
                    MessageBody = m.Message.MessageBody,
                    MessageId = m.Message.MessageId,

                }).Take(10).ToList();
            }

            return Mvm;
        }
    }
}