using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Helpify_v3.Adapters
{
    public interface IProjectListByCategory
    {
        ProjectByCategoryVm GetProjectsByCategory(int id);
    }
}
