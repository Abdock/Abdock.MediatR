using Abdock.MediatR.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Abdock.MediatR.Implementations
{
    internal sealed class Mediator : IMediator
    {
        private readonly IServiceProvider _services;

        public Mediator(IServiceProvider services)
        {
            _services = services;
        }

        public ValueTask<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var handler = _services.GetRequiredService<IRequestHandler<IRequest<TResponse>, TResponse>>();
            return handler.HandleAsync(request, cancellationToken);
        }
    }
}