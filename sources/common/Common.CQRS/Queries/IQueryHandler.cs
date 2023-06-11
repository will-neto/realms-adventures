﻿using MediatR;

namespace Common.CQRS.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>
{ }

