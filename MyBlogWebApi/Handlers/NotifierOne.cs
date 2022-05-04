using System.Diagnostics;
using MediatR;

namespace MyBlogWebApi.Handlers;

public class NotifierOne : INotificationHandler<NotificationMessage>
{
    public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
    {
        Debug.WriteLine($"Notification 1: Id: {notification.Id}, Text: {notification.NotifyText}");
        return Task.CompletedTask;
    }
}