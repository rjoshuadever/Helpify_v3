using Helpify_v3.Adapters;
using Helpify_v3.Adapters.DataAdapters;
using Helpify_v3.Data;
using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Helpify_v3.Controllers
{
    public class HomeController : Controller
    {
        //instance of the adapter
        private ICategoryList _adapter;
        private IAllProjectList _adapterProject;
        private IProjectList _adapterMyProjectList; 
            
        public HomeController()
        {
            _adapter = new CategoryListAdapter();
            _adapterProject = new AllProjectListDataAdapter();
            _adapterMyProjectList = new ProjectListDataAdapter();
        }

        
        public HomeController(CategoryListAdapter adapter)
        {
            _adapter = adapter;
            
        }

        public HomeController(AllProjectListDataAdapter adapterProject)
        {
            _adapterProject = adapterProject;
        }

        public HomeController(ProjectListDataAdapter adapterMyProjectList)
        {
            _adapterMyProjectList = adapterMyProjectList;
        }

        //instance of the dbcontext
        private ApplicationDbContext db = new ApplicationDbContext();


        //Begin Action Results
        public ActionResult Index()
        {
            IndexPageSuperVm Ivm = new IndexPageSuperVm();

            // get user GUID
            var names = User.Identity.Name;
            // Get user name///
            string uid = User.Identity.GetUserId();
            
            Ivm.CategoriesListVm = _adapter.GetAllCategories();

            Ivm.AllProjectsListVm = _adapterProject.GetProjects();
     
            //Ivm.AllProjectsListVm = _adapterProject.GetProjects(uid, names);

         
            return View(Ivm);
        }

        [Authorize]
        public ActionResult MyProjects()
        {
            IndexPageSuperVm Ipm = new IndexPageSuperVm();
            // Get user name///
            var names = User.Identity.Name;
            
            // get user GUID
            string uid = User.Identity.GetUserId();

            Ipm.AllProjectsListVm = _adapterMyProjectList.GetProjects(uid, names);

            return View(Ipm);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}