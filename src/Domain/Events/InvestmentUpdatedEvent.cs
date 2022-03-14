// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Domain.Events;


    public class InvestmentUpdatedEvent : DomainEvent
    {
        public InvestmentUpdatedEvent(Investment item)
        {
            Item = item;
        }

        public Investment Item { get; }
    }

