using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculator
{
    public class TaxValidator : AbstractValidator<Tax>
    {
        public TaxValidator()
        {
            RuleFor(x => x.Amount).LessThanOrEqualTo(1000000)
                .WithMessage("Próg kwoty nie możę być większy niż 1000000 (podano {PropertyValue})");

            RuleFor(x => x.Amount).GreaterThan(0)
                .WithMessage("Próg kwoty musi być większy od zera (podano {PropertyValue})");

            RuleFor(x => x.TaxRate).InclusiveBetween(0,1)
                .WithMessage("Stawka podatku musi sie zawierać w przedziale od 0 do 1 (co odpowiada 0-100%) (podano {PropertyValue})");

            RuleFor(x => x.Amount).ScalePrecision(2, 99).WithMessage("Maksymalna dokładność progu przychodu to 2 miejsca po przecinku (podano {PropertyValue})");
            RuleFor(x => x.TaxRate).ScalePrecision(2, 99).WithMessage("Maksymalna dokładność skali podatkowej to 2 miejsca po przecinku (podano {PropertyValue})");
        }

    }
}
