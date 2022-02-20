using Microsoft.AspNetCore.SignalR;
using MyBlog.Data;
using MyBlog.Data.Models;

namespace MyBlogServerSide.Hubs;

public class ChatHub : Hub
{
    private readonly ChatService _chatService;

    public ChatHub(ChatService chatService)
    {
        _chatService = chatService;
    }

    public async Task SendMessage(string user, string message)
    {
        var chat =  await _chatService.SaveChatAsync(new Chat
        {
            User = user,
            Message = message,
            Created = DateTime.Now
        });
        await Clients.All.SendAsync("ReceiveMessage", chat.User, chat.Message);
    }
    
}