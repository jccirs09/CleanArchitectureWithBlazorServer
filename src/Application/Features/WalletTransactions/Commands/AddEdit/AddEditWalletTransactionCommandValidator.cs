// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletTransactions.Commands.AddEdit;

    public class AddEditWalletTransactionCommandValidator : AbstractValidator<AddEditWalletTransactionCommand>
    {
    public AddEditWalletTransactionCommandValidator()
    {
        RuleFor(v => v.UserId)
               .NotEmpty();
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AddEditWalletTransactionCommand>.CreateWithOptions((AddEditWalletTransactionCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

