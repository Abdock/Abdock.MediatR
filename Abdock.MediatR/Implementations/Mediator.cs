using Abdock.MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Abdock.MediatR.Implementations;

internal sealed class Mediator : IMediator
{
    private readonly IServiceProvider _services;

    public Mediator(IServiceProvider services)
    {
        _services = services;
    }

    public ValueTask<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>
    {
        var handler = _services.GetRequiredService<IRequestHandler<TRequest, TResponse>>();
        return handler.HandleAsync(request, cancellationToken);
    }
}