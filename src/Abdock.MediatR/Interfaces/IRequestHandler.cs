namespace Abdock.MediatR.Interfaces;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    ValueTask<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}

public interface IRequestHandler<in TRequest> where TRequest : IRequest
{
    ValueTask HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}