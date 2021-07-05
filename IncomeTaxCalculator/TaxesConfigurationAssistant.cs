﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncomeTaxCalculator
{
    class TaxesConfigurationAssistant
    {
        public void EnsureConfigurationFileExists(string filePath)
        {
            if (!File.Exists(filePath))
                ApplyDefaultConfiguration(filePath);
        }
        public void ApplyDefaultConfiguration(string filePath)
        {
            List<Tax> taxes = GetDefaultTaxConfiguration();
            string json = JsonConvert.SerializeObject(taxes, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        private List<Tax> GetDefaultTaxConfiguration()
        {
            List<Tax> defaultTaxesConfiguration = new List<Tax>() { };
            defaultTaxesConfiguration.Add(new Tax { Amount = 10000, TaxRate = 0 });
            defaultTaxesConfiguration.Add(new Tax { Amount = 30000, TaxRate = 0.10 });
            defaultTaxesConfiguration.Add(new Tax { Amount = 100000, TaxRate = 0.25 });
            defaultTaxesConfiguration.Add(new Tax { Amount = 1000000, TaxRate = 0.40 });
            return defaultTaxesConfiguration;
        }
        public List<Tax> ReadConfiguration()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Taxes.json");
            string text = File.ReadAllText(filePath);
            List<Tax> taxes = JsonConvert.DeserializeObject<List<Tax>>(text);
            return taxes;
        }
    }
}