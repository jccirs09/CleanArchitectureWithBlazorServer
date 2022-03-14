// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace CleanArchitecture.Blazor.Application.Features.Investments.Commands.AddEdit;

    public class AddEditInvestmentCommandValidator : AbstractValidator<AddEditInvestmentCommand>
    {
        public AddEditInvestmentCommandValidator()
        {        
        RuleFor(v => v.ProofType)
           .MaximumLength(30)
           .NotEmpty();
        RuleFor(v => v.Amount)
               .GreaterThanOrEqualTo(50);
        RuleFor(v => v.Amount)
               .LessThanOrEqualTo(10000);
        RuleFor(v => v.ImageDateUrl)
            .NotEmpty();
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<AddEditInvestmentCommand>.CreateWithOptions((AddEditInvestmentCommand)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
}

