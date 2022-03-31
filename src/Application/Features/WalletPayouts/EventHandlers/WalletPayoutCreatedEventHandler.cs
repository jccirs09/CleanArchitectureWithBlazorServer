// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.EventHandlers;

    public class WalletPayoutCreatedEventHandler : INotificationHandler<DomainEventNotification<WalletPayoutCreatedEvent>>
    {
        private readonly ILogger<WalletPayoutCreatedEventHandler> _logger;

        public WalletPayoutCreatedEventHandler(
            ILogger<WalletPayoutCreatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<WalletPayoutCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
