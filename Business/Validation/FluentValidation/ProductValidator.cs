using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(3).WithMessage("minimum uzunlug 3 olmalidir").NotNull().WithMessage("bosh gondrile bilmez");
            RuleFor(p=>p.Price).GreaterThan(0).WithMessage("qiymet 0-dan boyuk olmalidir").NotNull();
        }
    }
}
