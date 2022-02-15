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
}