using System;

namespace MyBlog.Data.Models;

public class Chat
{
    public int Id { get; set; }
    public string User { get; set; }
    public string Message { get; set; }
    public DateTime Created { get; set; }
}