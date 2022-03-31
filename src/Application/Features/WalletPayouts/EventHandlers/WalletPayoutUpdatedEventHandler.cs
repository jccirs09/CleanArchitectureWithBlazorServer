// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.EventHandlers;

    public class WalletPayoutUpdatedEventHandler : INotificationHandler<DomainEventNotification<WalletPayoutUpdatedEvent>>
    {
        private readonly ILogger<WalletPayoutUpdatedEventHandler> _logger;

        public WalletPayoutUpdatedEventHandler(
            ILogger<WalletPayoutUpdatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<WalletPayoutUpdatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
