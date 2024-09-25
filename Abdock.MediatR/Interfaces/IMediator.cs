namespace Abdock.MediatR.Interfaces;

public interface IMediator
{
    ValueTask<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest<TResponse>;
}