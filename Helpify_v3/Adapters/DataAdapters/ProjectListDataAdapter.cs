using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpify_v3.Adapters;
using Helpify_v3.Data;


namespace Helpify_v3.Adapters.DataAdapters
{
    public class ProjectListDataAdapter : IProjectList
    {

        public Models.AllProjectListVm GetProjects(string uid, string namo)
        {
            AllProjectListVm PVm = new AllProjectListVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                //PVm.ProjectList = db.Projects.Select(p => new ProjectVm { Title = p.Title, Description = p.Description, ProjectId = p.ProjectId, CategoryId = p.CategoryId }).Take(20).ToList();

                PVm.ProjectList = db.UserProjectLookups.Where(u => u.ApplicationUserId == uid).Select(p => new ProjectVm
                {
                    Title = p.Project.Title,
                    Description = p.Project.Description,
                    ProjectId = p.Project.ProjectId,
                    CategoryId = p.Project.CategoryId,
                    UserName = p.ApplicationUser.FirstName



                }).Take(20).ToList();

            }
            PVm.Name = namo;
            return PVm;
        }


    }

    public class AllProjectListDataAdapter : IAllProjectList
    {
        public AllProjectListVm GetProjects()
        {
            AllProjectListVm Avm = new AllProjectListVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Avm.ProjectList = db.UserProjectLookups.Select(p => new ProjectVm { Title = p.Project.Title, Description = p.Project.Description, ProjectId = p.ProjectId, CategoryId = p.Project.CategoryId, Location = p.Project.Location, UserName = p.ApplicationUser.FirstName }).Take(5).ToList();
            }
            return Avm;
        }

    }
}
