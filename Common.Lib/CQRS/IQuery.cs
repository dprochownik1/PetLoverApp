using MediatR;

namespace Common.Lib.CQRS;

public interface IQuery<out TResult> : IRequest<TResult>
    where TResult : notnull
{
}