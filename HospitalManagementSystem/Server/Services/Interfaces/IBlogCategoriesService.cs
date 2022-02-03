using HospitalManagementSystem.Shared.BlogCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IBlogCategoriesService
    {
        Task<IEnumerable<AllBlogCategoriesForDropDownViewModel>> GetAllForDropDown();

        Task<IEnumerable<AllBlogCategoriesViewModel>> GetAll();
    }
}
