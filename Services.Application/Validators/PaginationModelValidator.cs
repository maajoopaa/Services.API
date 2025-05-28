using FluentValidation;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Validators
{
    public class PaginationModelValidator : AbstractValidator<PaginationModel>
    {
        public PaginationModelValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(1).WithMessage("page cannot be less than 1");
            RuleFor(x => x.PageSize).GreaterThanOrEqualTo(1).WithMessage("pagesize cannot be less than 1");
        }
    }
}
