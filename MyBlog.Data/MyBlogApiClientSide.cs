using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;
using Newtonsoft.Json;

namespace MyBlog.Data;

public class MyBlogApiClientSide : IMyBlogApi
{
    private readonly IHttpClientFactory _factory;

    public MyBlogApiClientSide(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<int> GetBlogPostCountAsync()
    {
        var httpClient = _factory.CreateClient("Public");
        return await httpClient.GetFromJsonAsync<int>("MyBlogApi/BlogPostCount");
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
    {
        var httpClient = _factory.CreateClient("Public");
        return await httpClient.GetFromJsonAsync<List<BlogPost>>($"MyBlogApi/BlogPosts?numberOfPosts={numberofposts}&startIndex={startindex}");
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var httpClient = _factory.CreateClient("Public");
        return await httpClient.GetFromJsonAsync<List<Category>>("MyBlogApi/GetCategories");
    }

    public Task<List<Tag>> GetTagsAsync()
    {
       // var httpClient = _factory.CreateClient("Public");
       throw new System.NotImplementedException();

    }

    public async Task<BlogPost> GetBlogPostAsync(int id)
    {
        var httpClient = _factory.CreateClient("Public");
        return await httpClient.GetFromJsonAsync<BlogPost>($"MyBlogApi/BlogPosts/{id}");
    }

    public Task<Category> GetCategoryAsync(int id)
    {
        //var httpClient = _factory.CreateClient("Public");
        throw new System.NotImplementedException();
    }

    public Task<Tag> GetTagAsync(int id)
    {
      //  var httpClient = _factory.CreateClient("Public");
      throw new System.NotImplementedException();
    }

    public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
    {
        try
        {
            var httpClient = _factory.CreateClient("Authenticated");
            var response = await httpClient.PutAsJsonAsync("MyBlogApi/BlogPosts", item);
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<BlogPost>(json);
        }
        catch (AccessTokenNotAvailableException exception)
        {
            exception.Redirect();
        }

        return null;
    }

    public Task<Category> SaveCategoryAsync(Category item)
    {
     //   var httpClient = _factory.CreateClient("Public");
        throw new System.NotImplementedException();

    }

    public Task<Tag> SaveTagAsync(Tag item)
    {
      //  var httpClient = _factory.CreateClient("Public");
        throw new System.NotImplementedException();
    }

    public Task DeleteBlogPostAsync(BlogPost item)
    {
      //  var httpClient = _factory.CreateClient("Public");
          throw new System.NotImplementedException();

    }

    public Task DeleteCategoryAsync(Category item)
    {
       // var httpClient = _factory.CreateClient("Public");
       throw new System.NotImplementedException();

    }

    public Task DeleteTagAsync(Tag item)
    {
       // var httpClient = _factory.CreateClient("Public");
       throw new System.NotImplementedException();

    }
}