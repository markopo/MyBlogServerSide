using Microsoft.AspNetCore.Mvc;
using MyBlogWebApi.Services;

namespace MyBlogWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MessageController : ControllerBase
{
    private readonly INotifierMediatorService _notifierMediatorService;

    public MessageController(INotifierMediatorService notifierMediatorService)
    {
        _notifierMediatorService = notifierMediatorService;
    }

    [HttpGet("message/{text}")]
    public ActionResult SendMessage(string text)
    {
        var id = Guid.NewGuid();
        _notifierMediatorService.Notify(id, text);
        return Ok(new
        {
            Id = id,
            Ok = true,
            Date = DateTime.Now.ToLongDateString()
        });
    }
}