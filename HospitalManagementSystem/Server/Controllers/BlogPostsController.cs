using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.BlogPosts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Controllers
{
    public class BlogPostsController : ApiController
    {
        private readonly IBlogPostsService blogPostsService;
        private readonly IBlogCategoriesService blogCategoriesService;
        private readonly ITagsService tagsService;

        public BlogPostsController(IBlogPostsService blogPostsService, IBlogCategoriesService blogCategoriesService, ITagsService tagsService)
        {
            this.blogPostsService = blogPostsService;
            this.blogCategoriesService = blogCategoriesService;
            this.tagsService = tagsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AllLatestBlogPostsViewModel>>> GetAllLatest()
        {
            IEnumerable<AllLatestBlogPostsViewModel> viewModel = await this.blogPostsService.GetAllLatest();
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AllBlogsWithPaginationViewModel>>> GetAllWithPagination(int id = 1)
        {
            IEnumerable<AllBlogsWithPaginationViewModel> viewModel = await this.blogPostsService.GetAllWithPagination(id);
            return this.Ok(viewModel);
        }

        [HttpGet("{blogCategoryId}/{id}")]
        public async Task<ActionResult<IEnumerable<AllBlogsWithPaginationViewModel>>> GetAllWithPaginationByCategoryId(int blogCategoryId, int id = 1)
        {
            IEnumerable<AllBlogsWithPaginationViewModel> viewModel = await this.blogPostsService.GetAllWithPaginationByCategoryId(blogCategoryId, id);
            return this.Ok(viewModel);
        }

        [HttpGet("{tagId}/{id}")]
        public async Task<ActionResult<IEnumerable<AllBlogsWithPaginationViewModel>>> GetAllWithPaginationByTagId(int tagId, int id = 1)
        {
            IEnumerable<AllBlogsWithPaginationViewModel> viewModel = await this.blogPostsService.GetAllWithPaginationByTagId(tagId, id);
            return this.Ok(viewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostDetailsViewModel>> Details(int id)
        {
            BlogPostDetailsViewModel viewModel = await this.blogPostsService.GetById(id);
            return this.Ok(viewModel);
        }

        [HttpGet]
        public ActionResult<int> GetAllCount()
        {
            int count = this.blogPostsService.GetAllCount();
            return this.Ok(count);
        }

        [HttpGet("{blogCategoryId}")]
        public ActionResult<int> GetCountByCategoryId(int blogCategoryId)
        {
            int count = this.blogPostsService.GetCountByCategoryId(blogCategoryId);
            return this.Ok(count);
        }

        [HttpGet("{tagId}")]
        public ActionResult<int> GetCountByTagId(int tagId)
        {
            int count = this.blogPostsService.GetCountByTagId(tagId);
            return this.Ok(count);
        }

        [HttpGet]
        public async Task<ActionResult<CreateBlogPostInputModel>> Create()
        {
            CreateBlogPostInputModel input = new CreateBlogPostInputModel
            {
                BlogCategories = await this.blogCategoriesService.GetAllForDropDown(),
                Tags = await this.tagsService.GetAllForDropDown(),
            };

            return this.Ok(input);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogPostInputModel input)
        {
            string userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.ModelState.IsValid)
            {
                input.BlogCategories = await this.blogCategoriesService.GetAllForDropDown();
                input.Tags = await this.tagsService.GetAllForDropDown();
                return this.BadRequest(input);
            }

            input.CreatorId = userId;
            await this.blogPostsService.CreateAsync(input);

            return this.Ok();
        }
    }
}
