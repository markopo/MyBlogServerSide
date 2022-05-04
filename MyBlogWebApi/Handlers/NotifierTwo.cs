using System.Diagnostics;
using MediatR;

namespace MyBlogWebApi.Handlers;

public class NotifierTwo : INotificationHandler<NotificationMessage>
{
    public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
    {
        Debug.WriteLine($"Notification 2: Id: {notification.Id}, Text: {notification.NotifyText}");
        return Task.CompletedTask;
    }
}