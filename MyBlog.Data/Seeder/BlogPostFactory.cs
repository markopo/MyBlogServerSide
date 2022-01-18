using System;
using Bogus;
using MyBlog.Data.Models;

namespace MyBlog.Data.Seeder;

public class BlogPostFactory
{
    private static Faker _faker = new Faker();
    public static BlogPost Create()
    {
        return new BlogPost
        {
            Title = _faker.Lorem.Text(),
            Text = _faker.Lorem.Paragraphs(),
            PublishDate = DateTime.Now
        };
    }
}