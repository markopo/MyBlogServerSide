using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;

namespace MyBlogWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MyBlogApiController : ControllerBase
{
    private readonly IMyBlogApi _myBlogApi;

    public MyBlogApiController(IMyBlogApi myBlogApi)
    {
        _myBlogApi = myBlogApi;
    }

    [HttpGet]
    [Route("BlogPosts")]
    public async Task<List<BlogPost>> GetBlogPostAsync(int numberOfPosts, int startIndex)
    {
        return await _myBlogApi.GetBlogPostsAsync(numberOfPosts, startIndex);
    }

    [HttpGet]
    [Route("BlogPostCount")]
    public async Task<int> GetBlogPostAsync()
    {
        return await _myBlogApi.GetBlogPostCountAsync();
    }

    [HttpGet]
    [Route("BlogPosts/{id}")]
    public async Task<BlogPost> GetBlogPostAsync(int id)
    {
        return await _myBlogApi.GetBlogPostAsync(id);
    }

    [Authorize]
    [HttpPut]
    [Route("BlogPosts")]
    public async Task<BlogPost> SaveBlogPostAsync([FromBody] BlogPost item)
    {
        return await _myBlogApi.SaveBlogPostAsync(item);
    }
    
    [Authorize]
    [HttpDelete]
    [Route("BlogPosts")]
    public async Task DeleteBlogPostAsync([FromBody] BlogPost item)
    {
        await _myBlogApi.DeleteBlogPostAsync(item);
    }

    [HttpGet]
    [Route("Categories")]
    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _myBlogApi.GetCategoriesAsync();
    }

    [HttpGet]
    [Route("Categories/{id}")]
    public async Task<Category> GetCategoriesAsync(int id)
    {
        return await _myBlogApi.GetCategoryAsync(id);
    }

    [Authorize]
    [HttpPut]
    [Route("Categories")]
    public async Task<Category> SaveCategoryAsync([FromBody] Category item)
    {
        return await _myBlogApi.SaveCategoryAsync(item);
    }

    [Authorize]
    [HttpDelete]
    [Route("Categories")]
    public async Task DeleteCategoryAsync([FromBody] Category item)
    {
        await _myBlogApi.DeleteCategoryAsync(item);
    }

    [HttpGet]
    [Route("Tags")]
    public async Task<List<Tag>> GetTagsAsync()
    {
        return await _myBlogApi.GetTagsAsync();
    }

    [HttpGet]
    [Route("Tags/{id}")]
    public async Task<Tag> GetTagsAsync(int id)
    {
        return await _myBlogApi.GetTagAsync(id);
    }

    [Authorize]
    [HttpPut]
    [Route("Tags")]
    public async Task<Tag> SaveTagAsync([FromBody] Tag item)
    {
        return await _myBlogApi.SaveTagAsync(item);
    }

    [Authorize]
    [HttpDelete]
    [Route("Tags")]
    public async Task DeleteTagsAsync([FromBody] Tag tag)
    {
        await _myBlogApi.DeleteTagAsync(tag);
    }



}