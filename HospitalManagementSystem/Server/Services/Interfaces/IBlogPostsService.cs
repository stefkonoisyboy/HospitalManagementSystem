using HospitalManagementSystem.Shared.BlogPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services.Interfaces
{
    public interface IBlogPostsService
    {
        Task CreateAsync(CreateBlogPostInputModel input);

        Task<IEnumerable<AllLatestBlogPostsViewModel>> GetAllLatest();

        Task<IEnumerable<AllBlogsWithPaginationViewModel>> GetAllWithPagination(int id, int itemsPerPage = 8);

        Task<IEnumerable<AllBlogsWithPaginationViewModel>> GetAllWithPaginationByCategoryId(int blogCategoryId, int id, int itemsPerPage = 8);

        Task<IEnumerable<AllBlogsWithPaginationViewModel>> GetAllWithPaginationByTagId(int tagId, int id, int itemsPerPage = 8);

        Task<BlogPostDetailsViewModel> GetById(int blogPostId);

        int GetAllCount();

        int GetCountByCategoryId(int blogCategoryId);

        int GetCountByTagId(int tagId);
    }
}
