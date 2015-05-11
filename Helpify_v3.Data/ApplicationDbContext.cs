using Helpify_v3.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Helpify_v3.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HelpifyDbConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //DB Sets

        public DbSet<Project> Projects { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ImageUrl> ImageUrls { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<UserProjectLookup> UserProjectLookups { get; set; }

        public DbSet<MessageProjectLookup> MessageProjects { get; set; }

        public DbSet<Message> Messages { get; set; }
    }
}
