using System.Threading;
using System.Threading.Tasks;

namespace Abdock.MediatR.Interfaces
{
    public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        ValueTask<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
    }
}