using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Models;

namespace MyBlog.Data;

public class ChatService
{
    private readonly IDbContextFactory<MyBlogDbContext> _factory;

    public ChatService(IDbContextFactory<MyBlogDbContext> factory)
    {
        _factory = factory;
    }

    public async Task<List<Chat>> GetChats()
    {
        await using var context = await _factory.CreateDbContextAsync();
        return await context.Chats.ToListAsync();
    }

    public async Task<Chat> SaveChatAsync(Chat chat)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Add(chat);
        await context.SaveChangesAsync();
        return chat;
    }
    
    
}