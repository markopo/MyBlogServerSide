using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Data.Interfaces;
using MyBlog.Data.Models;

namespace MyBlog.Data;

public class MyBlogApiServerSide : IMyBlogApi
{
    private readonly IDbContextFactory<MyBlogDbContext> _factory;

    public MyBlogApiServerSide(IDbContextFactory<MyBlogDbContext> factory)
    {
        _factory = factory;
    }
    public async Task<int> GetBlogPostCountAsync()
    { 
        await using var context = await _factory.CreateDbContextAsync();
        return await context.BlogPosts.CountAsync();
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.BlogPosts
            .OrderByDescending(p => p.PublishDate)
            .Skip(startindex)
            .Take(numberofposts)
            .ToListAsync();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Categories.ToListAsync();
    }

    public async Task<List<Tag>> GetTagsAsync()
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Tags.ToListAsync();
    }

    public async Task<BlogPost> GetBlogPostAsync(int id)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.BlogPosts
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Category> GetCategoryAsync(int id)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Tag> GetTagAsync(int id)
    {
        await using var context = await _factory.CreateDbContextAsync();

        return await context.Tags.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BlogPost> SaveBlogPostAsync(BlogPost item)
    {
        return (await SaveItem(item)) as BlogPost;
    }

    public async Task<Category> SaveCategoryAsync(Category item)
    {
        return (await SaveItem(item)) as Category;
    }

    public async Task<Tag> SaveTagAsync(Tag item)
    {
        return (await SaveItem(item)) as Tag;
    }

    public async Task DeleteBlogPostAsync(BlogPost item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Remove(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(Category item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Remove(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTagAsync(Tag item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        context.Remove(item);
        await context.SaveChangesAsync();
    }

    private async Task<IMyBlogItem> SaveItem(IMyBlogItem item)
    {
        await using var context = await _factory.CreateDbContextAsync();
        if (item.Id == 0)
        {
            context.Add(item);
        }
        else
        {
            if (item is BlogPost post)
            {
                var currentpost = await context.BlogPosts
                    .Include(p => p.Category)
                    .Include(p =>p.Tags)
                    .FirstOrDefaultAsync(p => p.Id == post.Id);

                if (currentpost != null)
                {
                    currentpost.PublishDate = post.PublishDate;
                    currentpost.Title = post.Title;
                    currentpost.Text = post.Text;
                    var ids = post.Tags.Select(t => t.Id);
                    currentpost.Tags = context.Tags.Where(t => ids.Contains(t.Id)).ToList();
                    currentpost.Category = await context.Categories.FirstOrDefaultAsync(c => c.Id == post.Category.Id);
                    await context.SaveChangesAsync();
                }
                
            }
            else
            {
               context.Entry(item).State = EntityState.Modified;
            }
        }

        await context.SaveChangesAsync();
        return item;
    }
}