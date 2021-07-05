using FluentValidation.Results;
using IncomeTaxCalculator.Validation;
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
            //Plik z podatkami znajdzie się w folderze Moje Dokumenty
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Taxes.json");
            TaxesConfigurationAssistant assistant = new ();
            TaxesCollectionValidator taxesCollectionValidator = new ();
            TaxesCollection taxesCollection = new () { Taxes = assistant.ReadTaxesConfiguration(filePath) };
            ValidationResult taxesValidationResult = taxesCollectionValidator.Validate(taxesCollection);
            ValidationAssistant validationAssistant = new();
            if (taxesValidationResult.Errors.Count() != 0)
            {
                validationAssistant.PrintAllErrors(taxesValidationResult.Errors);
            }
            else
            {
                Console.WriteLine("Podaj kwotę z której z której chcesz obliczyć wysokość podatku dochodowego");
                var income = Convert.ToDecimal(Console.ReadLine());
                IncomeValidator incomeValidator = new();
                ValidationResult incomeValidationResult = incomeValidator.Validate(income);
                if (incomeValidationResult.Errors.Count != 0)
                {
                    validationAssistant.PrintAllErrors(incomeValidationResult.Errors);
                }
                else
                {
                    TaxCalculator calculator = new();
                    Console.WriteLine($"Z kwoty {income} będziesz musiał(a) odprowadzić {calculator.CalculateIncomeTax(income, taxesCollection.Taxes)}pln podatku");
                }
            }
            
        }
    }
}
