using FluentValidation;
using Services.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Application.Validators
{
    public class SpecializationUpdateRequestValidator : AbstractValidator<SpecializationUpdateRequest>
    {
        public SpecializationUpdateRequestValidator()
        {
            
        }
    }
}
