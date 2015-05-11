using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helpify_v3.Data;

namespace Helpify_v3.Adapters.DataAdapters
{
    public class ProjectListByCategoryAdapter: IProjectListByCategory
    {
        public ProjectByCategoryVm GetProjectsByCategory(int id)
        {
            ProjectByCategoryVm Pavm = new ProjectByCategoryVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Pavm.ProjectByCategoryList = db.Projects.Select(p => new ProjectVm { Title = p.Title, Description = p.Description, Location = p.Location, CategoryId = p.CategoryId, ProjectId = p.ProjectId }).Where(p => p.CategoryId == id).ToList();
            }

            return Pavm;
        }
    }
}





