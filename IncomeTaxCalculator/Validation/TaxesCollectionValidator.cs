using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculator
{
    public class TaxesCollectionValidator : AbstractValidator<TaxesCollection>
    {
        public TaxesCollectionValidator()
        {
            RuleFor(x => x.Taxes).Must(RatesMustBeUnique).WithMessage("Wartości skal podatkowych nie mogą się powtarzać");
            RuleFor(x => x.Taxes).Must(AmountsMustBeUnique).WithMessage("Progi przychodów nie mogą się powtarzać");
            RuleFor(x => x.Taxes).Must(RatesMustBeIncreasingWithAmounts).WithMessage("Wraz ze wzrostem wartości progowych opodatkowanie musi się zwiększać");
            RuleForEach(x => x.Taxes).SetValidator(new TaxValidator());
        }
        private bool RatesMustBeUnique(List<Tax> taxes)
        {
            List<decimal> rates = new List<decimal>();
            foreach (Tax t in taxes)
            {
                rates.Add(t.TaxRate);
            }
            List<decimal> filteredRates = rates.Distinct().ToList();
            if (rates.Count() == filteredRates.Count())
                return true;
            else
                return false;
        }
        private bool AmountsMustBeUnique(List<Tax> taxes)
        {
            List<decimal> ammounts = new List<decimal>();
            foreach (Tax t in taxes)
            {
                ammounts.Add(t.Amount);
            }
            List<decimal> filteredRates = ammounts.Distinct().ToList();
            if (ammounts.Count() == filteredRates.Count())
                return true;
            else
                return false;
        }
        private bool RatesMustBeIncreasingWithAmounts(List<Tax> taxes)
        {
            taxes = taxes.OrderBy(x => x.Amount).ToList();
            for (int i = 0; i < taxes.Count-1; i++)
            {
                if (taxes[i].TaxRate >= taxes[i + 1].TaxRate)
                    return false;
            }
            return true;
        }

    }
}
