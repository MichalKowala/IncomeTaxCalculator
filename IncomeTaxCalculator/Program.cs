using System;
using System.Collections.Generic;
using System.IO;

namespace IncomeTaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Taxes.json");
            TaxesConfigurationAssistant assistant = new TaxesConfigurationAssistant();
            assistant.EnsureConfigurationFileExists(filePath);
            List<Tax> taxes = assistant.ReadConfiguration();
            Console.WriteLine();
        }
    }
}
