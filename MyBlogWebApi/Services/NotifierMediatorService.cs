using MediatR;
using MyBlogWebApi.Handlers;

namespace MyBlogWebApi.Services;

public interface INotifierMediatorService
{
    void Notify(Guid id, string notifyText);
}

public class NotifierMediatorService : INotifierMediatorService
{
    private readonly IMediator _mediator;

    public NotifierMediatorService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Notify(Guid id, string notifyText)
    {
        _mediator.Publish(new NotificationMessage
        {
            Id = id,
            NotifyText = notifyText
        });
    }
    
}