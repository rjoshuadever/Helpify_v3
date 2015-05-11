using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Helpify_v3.Data;
using Helpify_v3.Data.Model;
using Helpify_v3.Models;
using Helpify_v3.Adapters;
using Helpify_v3.Adapters.DataAdapters;
using Microsoft.AspNet.Identity;

namespace Helpify_v3.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private IProjectMessagesInterface _adapter;
        private ApplicationDbContext db = new ApplicationDbContext();

        public MessagesController()
        {
            _adapter = new GetMessagesAdapter();
        }

        public MessagesController(GetMessagesAdapter adapter)
        {
            
            _adapter = adapter;
        }

        // GET: Messages
        public ActionResult ProjectMessage(int id)
        {
            MessageListVm Mvm = new MessageListVm();
            Mvm = _adapter.GetMessagesByProject(id);
            

            return View(Mvm);
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create(int Id)
        {
            
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Id, [Bind(Include = "MessageId,SenderName,Location,MessageBody")] MessageVm message)
        {
            string userId = User.Identity.GetUserId();

            if (!db.UserProjectLookups.Any(p => p.ProjectId == Id && p.ApplicationUserId == userId))
            {
                ModelState.AddModelError("InvalidProject", new Exception("Invalid Project ID"));
                return View(message);
            }

            if (ModelState.IsValid)
            {
                Message m = new Message
                {
                    Location = message.Location,
                    MessageBody = message.MessageBody,
                    SenderName = message.SenderName
                };

                db.Messages.Add(m);

                //Fetch Project Id for Lookup table
                var MessageLookupItem = new MessageProjectLookup()
                {
                    ProjectId = Id,
                    MessageId = message.MessageId
                };

                db.MessageProjects.Add(MessageLookupItem);
                db.SaveChanges();
                return RedirectToAction("MyProjects", "Home");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,SenderName,Location,MessageBody")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
