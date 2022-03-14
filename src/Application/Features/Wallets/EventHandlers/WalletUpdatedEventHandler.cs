// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Wallets.EventHandlers;

    public class WalletUpdatedEventHandler : INotificationHandler<DomainEventNotification<WalletUpdatedEvent>>
    {
        private readonly ILogger<WalletUpdatedEventHandler> _logger;

        public WalletUpdatedEventHandler(
            ILogger<WalletUpdatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<WalletUpdatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
