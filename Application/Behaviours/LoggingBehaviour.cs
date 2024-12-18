﻿using Application.Identity;
using Application.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
        where TRequest : class
    {
        private readonly ILogger logger;
        private readonly ICurrentUser currentUser;
        private readonly IIdentity identity;

        public LoggingBehaviour(
            ILogger<TRequest> logger,
            ICurrentUser currentUserService,
            IIdentity identityService)
        {
            this.logger = logger;
            currentUser = currentUserService;
            this.identity = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = currentUser.Id ?? string.Empty;
            string userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                userName = await identity.GetUserName(userId);
            }

            logger.LogInformation($"Request: {requestName},\n request: {request},\n UserId: {userId},\n User name: {userName}");
        }
    }
}
