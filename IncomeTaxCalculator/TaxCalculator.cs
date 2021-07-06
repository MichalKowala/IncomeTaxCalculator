using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculator
{
    public class TaxCalculator
    {
        public decimal CalculateIncomeTax(decimal untaxedAmount, List<Tax> taxThresholds)
        {
            taxThresholds = taxThresholds.OrderBy(x => x.Amount).ToList();
            decimal paidTax = 0;
            decimal taxedAmountTotal = 0;

            for (int i = 0; i < taxThresholds.Count; i++)
            {
                decimal upperBoundary = taxThresholds[i].Amount;
                decimal lowerBoundary;
                if (i == 0)
                    lowerBoundary = 0;
                else
                    lowerBoundary = taxThresholds[i - 1].Amount;
                decimal rate = taxThresholds[i].TaxRate;

                if (untaxedAmount >= upperBoundary)
                {
                    paidTax = paidTax + ((upperBoundary - lowerBoundary) * rate);
                    taxedAmountTotal = taxedAmountTotal + (upperBoundary - lowerBoundary);
                    untaxedAmount = untaxedAmount - (upperBoundary - lowerBoundary);
                }
                else
                {
                    paidTax = paidTax + (untaxedAmount * rate);
                    break;
                }
            }
            return Math.Floor(paidTax);
        }
    }
}