using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace IncomeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Taxes.json");
            TaxesConfigurationAssistant assistant = new TaxesConfigurationAssistant();
            assistant.EnsureConfigurationFileExists(filePath);
            TaxValidator validator = new TaxValidator();
            List<Tax> taxes = assistant.ReadTaxesConfiguration(filePath);
            List<ValidationFailure> results = new List<ValidationFailure>();
            foreach (Tax tax in taxes)
            {
                ValidationResult result = validator.Validate(tax);
                if (!result.IsValid)
                    results.AddRange(result.Errors);
            }
            if (results.Any())
            {
                Console.WriteLine("Wykryto błędy w podatkach:");
                foreach (var error in results)
                    Console.WriteLine(error.ErrorMessage);
            }
            TaxCalculator calculator = new TaxCalculator();
            var kwota = calculator.CalculateIncomeTax(50000, taxes);
            Console.WriteLine(kwota);
        }
    }
}
