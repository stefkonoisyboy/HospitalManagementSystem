using HospitalManagementSystem.Server.Data;
using HospitalManagementSystem.Server.Models;
using HospitalManagementSystem.Server.Services.Interfaces;
using HospitalManagementSystem.Shared.BlogPosts;
using HospitalManagementSystem.Shared.Tags;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Server.Services
{
    public class BlogPostsService : IBlogPostsService
    {
        private readonly ApplicationDbContext dbContext;

        public BlogPostsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(CreateBlogPostInputModel input)
        {
            BlogPost blogPost = new BlogPost
            {
                Title = input.Title,
                Content = input.Content,
                CreatedOn = DateTime.UtcNow,
                CreatorId = input.CreatorId,
                BlogCategoryId = input.BlogCategoryId,
                RemoteImageUrl = input.RemoteImageUrl,
            };

            await this.dbContext.BlogPosts.AddAsync(blogPost);
            await this.dbContext.SaveChangesAsync();

            foreach (var tagId in input.TagIds)
            {
                BlogPostTag blogPostTag = new BlogPostTag
                {
                    TagId = tagId,
                    BlogPostId = blogPost.Id,
                };

                await this.dbContext.BlogPostTags.AddAsync(blogPostTag);
            }

            await this.dbContext.SaveChangesAsync();
        }

        public int GetAllCount()
        {
            return this.dbContext.BlogPosts.Count();
        }

        public async Task<IEnumerable<AllLatestBlogPostsViewModel>> GetAllLatest()
        {
            return await this.dbContext.BlogPosts
                .OrderByDescending(p => p.CreatedOn)
                .Take(3)
                .Select(p => new AllLatestBlogPostsViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    BlogCategoryName = p.BlogCategory.Name,
                    CreatedOn = p.CreatedOn,
                    CreatorRemoteProfileImageUrl = p.Creator.ProfileImageRemoteUrl,
                    CreatorFullName = p.Creator.FirstName + ' ' + p.Creator.LastName,
                    RemoteImageUrl = p.RemoteImageUrl,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AllBlogsWithPaginationViewModel>> GetAllWithPagination(int id, int itemsPerPage)
        {
            return await this.dbContext.BlogPosts
               .OrderByDescending(p => p.CreatedOn)
               .Skip((id - 1) * itemsPerPage).Take(itemsPerPage)
               .Select(p => new AllBlogsWithPaginationViewModel
               {
                   Id = p.Id,
                   Title = p.Title,
                   BlogCategoryName = p.BlogCategory.Name,
                   CreatedOn = p.CreatedOn,
                   CreatorRemoteProfileImageUrl = p.Creator.ProfileImageRemoteUrl,
                   CreatorFullName = p.Creator.FirstName + ' ' + p.Creator.LastName,
                   RemoteImageUrl = p.RemoteImageUrl,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<AllBlogsWithPaginationViewModel>> GetAllWithPaginationByCategoryId(int blogCategoryId, int id, int itemsPerPage = 8)
        {
            return await this.dbContext.BlogPosts
               .Where(p => p.BlogCategoryId == blogCategoryId)
               .OrderByDescending(p => p.CreatedOn)
               .Skip((id - 1) * itemsPerPage).Take(itemsPerPage)
               .Select(p => new AllBlogsWithPaginationViewModel
               {
                   Id = p.Id,
                   Title = p.Title,
                   BlogCategoryName = p.BlogCategory.Name,
                   CreatedOn = p.CreatedOn,
                   CreatorRemoteProfileImageUrl = p.Creator.ProfileImageRemoteUrl,
                   CreatorFullName = p.Creator.FirstName + ' ' + p.Creator.LastName,
                   RemoteImageUrl = p.RemoteImageUrl,
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<AllBlogsWithPaginationViewModel>> GetAllWithPaginationByTagId(int tagId, int id, int itemsPerPage = 8)
        {
            return await this.dbContext.BlogPosts
              .Where(p => p.Tags.Any(t => t.TagId == tagId))
              .OrderByDescending(p => p.CreatedOn)
              .Skip((id - 1) * itemsPerPage).Take(itemsPerPage)
              .Select(p => new AllBlogsWithPaginationViewModel
              {
                  Id = p.Id,
                  Title = p.Title,
                  BlogCategoryName = p.BlogCategory.Name,
                  CreatedOn = p.CreatedOn,
                  CreatorRemoteProfileImageUrl = p.Creator.ProfileImageRemoteUrl,
                  CreatorFullName = p.Creator.FirstName + ' ' + p.Creator.LastName,
                  RemoteImageUrl = p.RemoteImageUrl,
              })
              .ToListAsync();
        }

        public async Task<BlogPostDetailsViewModel> GetById(int blogPostId)
        {
            return await this.dbContext.BlogPosts
                .Where(p => p.Id == blogPostId)
                .Select(p => new BlogPostDetailsViewModel 
                {
                    Id = p.Id,
                    Title = p.Title,
                    BlogCategoryName = p.BlogCategory.Name,
                    CreatedOn = p.CreatedOn,
                    CreatorRemoteProfileImageUrl = p.Creator.ProfileImageRemoteUrl,
                    CreatorFullName = p.Creator.FirstName + ' ' + p.Creator.LastName,
                    RemoteImageUrl = p.RemoteImageUrl,
                    Content = p.Content,
                    Tags = p.Tags
                    .Select(t => new AllTagsForDropDownViewModel
                    {
                        Id = t.TagId,
                        Name = t.Tag.Name,
                    })
                    .ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public int GetCountByCategoryId(int blogCategoryId)
        {
            return this.dbContext.BlogPosts
                .Count(p => p.BlogCategoryId == blogCategoryId);
        }

        public int GetCountByTagId(int tagId)
        {
            return this.dbContext.BlogPosts
                .Count(p => p.Tags.Any(t => t.TagId == tagId));
        }
    }
}
