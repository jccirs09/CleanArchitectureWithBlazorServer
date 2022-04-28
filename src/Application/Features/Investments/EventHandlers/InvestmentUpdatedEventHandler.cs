// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Investments.EventHandlers;

public class InvestmentUpdatedEventHandler : INotificationHandler<DomainEventNotification<InvestmentUpdatedEvent>>
{
    private readonly ILogger<InvestmentUpdatedEventHandler> _logger;

    public InvestmentUpdatedEventHandler(
        ILogger<InvestmentUpdatedEventHandler> logger
        )
    {
        _logger = logger;
    }
    public Task Handle(DomainEventNotification<InvestmentUpdatedEvent> notification, CancellationToken cancellationToken)
    {
        var domainEvent = notification.DomainEvent;

        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

        return Task.CompletedTask;
    }
}
