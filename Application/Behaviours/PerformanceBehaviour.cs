using System.Diagnostics;
using Application.Identity;
using Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
    public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch timer;
        private readonly ILogger<TRequest> logger;
        private readonly ICurrentUser currentUser;
        private readonly IIdentity identity;

        public PerformanceBehaviour(
            ILogger<TRequest> logger,
            ICurrentUser currentUserService,
            IIdentity identityService)
        {
            timer = new Stopwatch();

            this.logger = logger;
            currentUser = currentUserService;
            identity = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            timer.Start();

            var response = await next();

            timer.Stop();

            var elapsedMilliseconds = timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 500)
            {
                var requestName = typeof(TRequest).Name;
                var userId = currentUser.Id ?? string.Empty;
                var username = string.Empty;

                if (!string.IsNullOrEmpty(userId))
                {
                    username = await identity.GetUserName(userId);
                }

                logger.LogWarning($"Request name: {requestName},\n Time elapsed: {elapsedMilliseconds},\n User id:  {userId},\n Username: {username}");

                logger.LogWarning("Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}", requestName, elapsedMilliseconds, userId, username, request);
            }

            return response;
        }
    }
}
