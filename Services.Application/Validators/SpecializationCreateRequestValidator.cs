using FluentValidation;
using Services.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Validators
{
    public class SpecializationCreateRequestValidator : AbstractValidator<SpecializationCreateRequest>
    {
        public SpecializationCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name cannot be empty");
            RuleFor(x => x.ServiceIds).NotNull().WithMessage("services cannot be empty");
        }
    }
}
