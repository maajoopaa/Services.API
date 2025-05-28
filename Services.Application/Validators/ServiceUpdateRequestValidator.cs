using FluentValidation;
using Services.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Validators
{
    public class ServiceUpdateRequestValidator : AbstractValidator<ServiceCreateRequest>
    {
        public ServiceUpdateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name cannot be empty");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("category cannot be empty");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("price cannot be less than 0");
        }
    }
}
