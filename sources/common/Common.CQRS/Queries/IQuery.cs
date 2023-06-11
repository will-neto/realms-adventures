using MediatR;

namespace Common.CQRS.Queries;
public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }

