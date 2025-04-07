
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVisualizationApp.Models;
public class CapitaQueryRunner : IGraph
{
   // public List<double> capitaWaste = new();
  //  public List<string> countries = new();
            public Dictionary<string, double> wasteByCategory { get; private set; } = new();
    public void Run(string country = "USA", int year = 2024)
    {

        DataLoader<FoodWasteData> loader = new DataLoader<FoodWasteData>();
        loader.LoadData("global_food_wastage_dataset.csv");


        var records = loader.data
            .Where(record => record.Country == country && record.Year == year)
            .GroupBy(r => r.FoodCategory)
            .Select(group => new
            {
                Category = group.Key,
                WastePerCapita = group.Average(r => r.AvgWastePerCapita)
            })
            .Where(g => g.WastePerCapita > 0)
            .ToList();


       // capitaWaste = records.Select(r => r.WastePerCapita).ToList();
        wasteByCategory = records.ToDictionary(r => r.Category, r => r.WastePerCapita);







    }




}