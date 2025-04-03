using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVisualizationApp.Models;
public class WasteOverTimeQueryRunner
{
    public Dictionary<string, List<double>> wasteOverTime = new();
    public List<int> years = [];

    public void Run(string country)
    {
        DataLoader<FoodWasteData> loader = new DataLoader<FoodWasteData>();
        loader.LoadData("global_food_wastage_dataset.csv");

        var wasteRecords = loader.data.Where(record => record.Country == country)
                                      .GroupBy(record => record.Year)
                                      .OrderBy(group => group.Key)
                                      .Select(group => new
                                      {
                                          Year = group.Key,
                                          TotalWaste = group.Sum(record => record.TotalWaste)
                                      })
                                      .ToList();

        years = wasteRecords.Select(r => r.Year).ToList();
        wasteOverTime[country] = wasteRecords.Select(r => r.TotalWaste).ToList();
    }
}
