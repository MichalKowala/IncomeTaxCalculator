using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeTaxCalculator.Validation
{
    public class ValidationAssistant
    {
        public void PrintAllErrors(List<ValidationFailure> result)
        {
            Console.WriteLine("Znaleziono błędy:");
            foreach (var e in result)
                Console.WriteLine(e.ErrorMessage);

        }
    }
}
