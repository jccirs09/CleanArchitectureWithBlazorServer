// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Investments.EventHandlers;

    public class InvestmentCreatedEventHandler : INotificationHandler<DomainEventNotification<InvestmentCreatedEvent>>
    {
        private readonly ILogger<InvestmentCreatedEventHandler> _logger;

        public InvestmentCreatedEventHandler(
            ILogger<InvestmentCreatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<InvestmentCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
