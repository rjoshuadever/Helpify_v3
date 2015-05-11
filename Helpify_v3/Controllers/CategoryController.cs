using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Helpify_v3.Adapters;
using Helpify_v3.Adapters.DataAdapters;
using Helpify_v3.Data;

namespace Helpify_v3.Controllers
{
    public class CategoryController : Controller
    {
        //instance of the adapter
        private IProjectListByCategory _adapterLocal;


        public CategoryController()
        {
            _adapterLocal = new ProjectListByCategoryAdapter();
        }


         public CategoryController(ProjectListByCategoryAdapter adapterLocal)
        {
            _adapterLocal = adapterLocal;
        }

        //db cotext
         private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Category
        public ActionResult Automotive(int id)
        {
            ProjectByCategoryVm Avm = new ProjectByCategoryVm();
            Avm = _adapterLocal.GetProjectsByCategory(id);
            
        
            return View(Avm);
        }

        public ActionResult Electronic(int id, string catName)
        {
            ProjectByCategoryVm Evm = new ProjectByCategoryVm();
            
            Evm = _adapterLocal.GetProjectsByCategory(id);

            Evm.PageTitle = catName;

            return View(Evm);
        }

        public ActionResult WoodCraft(int id)
        {
            ProjectByCategoryVm Wvm = new ProjectByCategoryVm();
            Wvm = _adapterLocal.GetProjectsByCategory(id);

            return View(Wvm);
        }

        public ActionResult Household(int id)
        {
            ProjectByCategoryVm Hvm = new ProjectByCategoryVm();
            Hvm = _adapterLocal.GetProjectsByCategory(id);

            return View(Hvm);
        }

        public ActionResult HomeImprovement(int id)
        {
            ProjectByCategoryVm Ivm = new ProjectByCategoryVm();
            Ivm = _adapterLocal.GetProjectsByCategory(id);

            return View(Ivm);
        }

        public ActionResult Computers(int id)
        {
            ProjectByCategoryVm Cvm = new ProjectByCategoryVm();
            Cvm = _adapterLocal.GetProjectsByCategory(id);

            return View(Cvm);
        }

        public ActionResult Create()
        {
            CreateCategoryVM model = new CreateCategoryVM();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryVM model)
        {
            return View();
        }
    }
}