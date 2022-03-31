// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Wallets.Commands.AddEdit;

    public class AddEditWalletCommandValidator : AbstractValidator<AddEditWalletCommand>
    {
    public AddEditWalletCommandValidator()
    {
        RuleFor(v => v.CurrentBalance)
               .GreaterThanOrEqualTo(50);
    }

    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AddEditWalletCommand>.CreateWithOptions((AddEditWalletCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}

