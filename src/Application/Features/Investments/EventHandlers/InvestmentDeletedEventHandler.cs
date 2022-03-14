// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Investments.EventHandlers;

    public class InvestmentDeletedEventHandler : INotificationHandler<DomainEventNotification<InvestmentDeletedEvent>>
    {
        private readonly ILogger<InvestmentDeletedEventHandler> _logger;

        public InvestmentDeletedEventHandler(
            ILogger<InvestmentDeletedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<InvestmentDeletedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
