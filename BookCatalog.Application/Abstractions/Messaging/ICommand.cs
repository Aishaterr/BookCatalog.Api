using BookCatalog.SharedKernel;
using MediatR;

namespace BookCatalog.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
