using Library.Application.Interfaces;
using MediatR;

namespace Library.Application.Behaviors;

public class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest
    : IRequest<TResponse>
{
    private readonly ICurrentUserService _userService;

    public LoggingBehavior(ICurrentUserService currentUserService) =>
        _userService = currentUserService;

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next, CancellationToken token)
    {
        var response = await next();

        return response;
    }
}