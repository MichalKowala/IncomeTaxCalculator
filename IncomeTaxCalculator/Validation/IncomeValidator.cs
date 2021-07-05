using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculator.Validation
{
    public class IncomeValidator : AbstractValidator<decimal>
    {
        public IncomeValidator()
        {
            RuleFor(x => x).LessThanOrEqualTo(1000000).WithMessage("Kalkulator ten przystosowany jest do kwot nie większych niż 100000000");
            RuleFor(x => x).GreaterThan(0).WithMessage("Kwota musi być większa niż 0");
        }
    }
}
