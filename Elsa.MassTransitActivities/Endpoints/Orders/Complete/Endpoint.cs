using Elsa.Samples.AspNet.MassTransitActivities.Messages;
using FastEndpoints;
using MassTransit;

namespace Elsa.Samples.AspNet.MassTransitActivities.Endpoints.Orders.Create;

public class Complete : EndpointWithoutRequest
{
    private readonly IBus _bus;

    public Complete(IBus bus)
    {
        _bus = bus;
    }
    
    public override void Configure()
    {
        Post("orderComplete");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        await _bus.Publish(new OrderCompleted("myorder"), cancellationToken);
    }
}