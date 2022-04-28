// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.EventHandlers;

public class WalletTransactionCreatedEventHandler : INotificationHandler<DomainEventNotification<WalletTransactionCreatedEvent>>
{
    private readonly ILogger<WalletTransactionCreatedEventHandler> _logger;

    public WalletTransactionCreatedEventHandler(
        ILogger<WalletTransactionCreatedEventHandler> logger
        )
    {
        _logger = logger;
    }
    public Task Handle(DomainEventNotification<WalletTransactionCreatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
