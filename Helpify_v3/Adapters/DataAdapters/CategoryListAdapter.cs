using Helpify_v3.Data;
using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpify_v3.Adapters.DataAdapters
{
    public class CategoryListAdapter : ICategoryList
    {
        public CategoriesListVm GetAllCategories()
        {
            CategoriesListVm Cvm = new CategoriesListVm();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Cvm.CategoriesList = db.Categories.Select(c => new CategoryVm { CategoryName = c.CategoryName, CategoryId = c.CategoryId }).ToList();
            }

            return Cvm;
        }


       
    }
}