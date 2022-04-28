// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.WalletPayouts.Commands.AddEdit;

public class AddEditWalletPayoutCommandValidator : AbstractValidator<AddEditWalletPayoutCommand>
{

    public AddEditWalletPayoutCommandValidator()
    {


        RuleFor(v => v.Amount)
              .GreaterThanOrEqualTo(50);
        RuleFor(v => v.Amount)
               .LessThanOrEqualTo(10000);
    }
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AddEditWalletPayoutCommand>.CreateWithOptions((AddEditWalletPayoutCommand)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };


}

