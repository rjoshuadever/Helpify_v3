﻿using Helpify_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Helpify_v3.Adapters
{
    public interface ICategoryList
    {
        CategoriesListVm GetAllCategories();
    }
}
