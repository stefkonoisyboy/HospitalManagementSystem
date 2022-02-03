using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.BlogCategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class BlogCategoriesController : ApiController
    {
        private readonly IBlogCategoriesService blogCategoriesService;

        public BlogCategoriesController(IBlogCategoriesService blogCategoriesService)
        {
            this.blogCategoriesService = blogCategoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllBlogCategoriesViewModel>>> GetAll()
        {
            IEnumerable<AllBlogCategoriesViewModel> viewModel = await this.blogCategoriesService.GetAll();
            return this.Ok(viewModel);
        }
    }
}
