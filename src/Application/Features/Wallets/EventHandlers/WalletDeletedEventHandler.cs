// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Wallets.EventHandlers;

public class WalletDeletedEventHandler : INotificationHandler<DomainEventNotification<WalletDeletedEvent>>
{
    private readonly ILogger<WalletDeletedEventHandler> _logger;

    public WalletDeletedEventHandler(
        ILogger<WalletDeletedEventHandler> logger
        )
    {
        _logger = logger;
    }
    public Task Handle(DomainEventNotification<WalletDeletedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
