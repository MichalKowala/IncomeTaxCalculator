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
            decimal taxedAmount = 0;
            for (int i = 0; i < taxThresholds.Count; i++)
            {
                if (untaxedAmount != 0)
                {
                    if (untaxedAmount >= taxThresholds[i].Amount)
                    {
                        paidTax = paidTax + ((taxThresholds[i].Amount - taxedAmount) * taxThresholds[i].TaxRate);
                        untaxedAmount = untaxedAmount - taxThresholds[i].Amount;
                        taxedAmount = taxedAmount + taxThresholds[i].Amount;
                    }
                    else
                    {
                        paidTax = paidTax + (untaxedAmount * taxThresholds[i].TaxRate);
                        taxedAmount = taxedAmount + untaxedAmount;
                        untaxedAmount = 0;
                    }
                }
            }
            return paidTax;
        }
    }
}
