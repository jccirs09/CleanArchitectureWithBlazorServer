// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Wallets.EventHandlers;

    public class WalletCreatedEventHandler : INotificationHandler<DomainEventNotification<WalletCreatedEvent>>
    {
        private readonly ILogger<WalletCreatedEventHandler> _logger;

        public WalletCreatedEventHandler(
            ILogger<WalletCreatedEventHandler> logger
            )
        {
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<WalletCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
