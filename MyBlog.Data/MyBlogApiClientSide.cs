using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;

namespace MyBlog.Data;

public class MyBlogApiClientSide : IMyBlogApi
{
    private readonly IHttpClientFactory _factory;

    public MyBlogApiClientSide(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public Task<int> GetBlogPostCountAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Category>> GetCategoriesAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Tag>> GetTagsAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<BlogPost> GetBlogPostAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<Category> GetCategoryAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<Tag> GetTagAsync(int id)
    {
        throw new System.NotImplementedException();
    }

    public Task<BlogPost> SaveBlogPostAsync(BlogPost item)
    {
        throw new System.NotImplementedException();
    }

    public Task<Category> SaveCategoryAsync(Category item)
    {
        throw new System.NotImplementedException();
    }

    public Task<Tag> SaveTagAsync(Tag item)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteBlogPostAsync(BlogPost item)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteCategoryAsync(Category item)
    {
        throw new System.NotImplementedException();
    }

    public Task DeleteTagAsync(Tag item)
    {
        throw new System.NotImplementedException();
    }
}