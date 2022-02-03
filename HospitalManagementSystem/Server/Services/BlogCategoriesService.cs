using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.BlogCategories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class BlogCategoriesService : IBlogCategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public BlogCategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllBlogCategoriesViewModel>> GetAll()
        {
            return await this.dbContext.BlogCategories
                .Select(c => new AllBlogCategoriesViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BlogPostsCount = c.BlogPosts.Count(),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllBlogCategoriesForDropDownViewModel>> GetAllForDropDown()
        {
            return await this.dbContext.BlogCategories
                .OrderBy(c => c.Name)
                .Select(c => new AllBlogCategoriesForDropDownViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }
    }
}
