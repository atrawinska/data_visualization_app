using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace DataVisualizationApp.Models;

public class CountryProvider
{
    public List<string> GetAllAvailableCountries(string datasetPath = "global_food_wastage_dataset.csv")
        {
            var loader = new DataLoader<FoodWasteData>();
            loader.LoadData(datasetPath);

            return loader.data
                .Select(d => d.Country)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .OrderBy(c => c)
                .ToList();
        }

        public List<string> GetFiveAvailableCountries(string datasetPath = "global_food_wastage_dataset.csv")
        {
            var loader = new DataLoader<FoodWasteData>();
            loader.LoadData(datasetPath);

            return loader.data
                .Select(d => d.Country)
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Distinct()
                .Take(10) 
                .OrderBy(c => c)
                .ToList();
        }
  
  
}


