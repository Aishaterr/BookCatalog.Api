using MediatR;

namespace BookCatalog.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}
