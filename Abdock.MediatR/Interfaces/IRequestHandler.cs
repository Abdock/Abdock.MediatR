namespace Abdock.MediatR.Interfaces;

public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public ValueTask<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}