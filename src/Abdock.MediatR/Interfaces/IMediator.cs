namespace Abdock.MediatR.Interfaces
{
    public interface IMediator
    {
        ValueTask<TResponse> SendAsync<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default);
    }
}