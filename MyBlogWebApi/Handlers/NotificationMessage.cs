using MediatR;

namespace MyBlogWebApi.Handlers;

public class NotificationMessage : INotification    
{
    public Guid Id { get; init; }
    public string NotifyText { get; init; }
}