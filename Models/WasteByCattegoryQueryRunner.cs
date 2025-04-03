
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVisualizationApp.Models;
public class WasteByCategoryQueryRunner
{
    public List<double> wastePerCategory = [];
    public List<string> categories = [];

    public void Run()
    {
        DataLoader<FoodWasteData> loader = new DataLoader<FoodWasteData>();
        loader.LoadData("global_food_wastage_dataset.csv");

        var categoryWaste = loader.data.GroupBy(record => record.FoodCategory)
                                       .Select(group => new
                                       {
                                           Category = group.Key,
                                           TotalWaste = group.Sum(record => record.TotalWaste)
                                       })
                                       .OrderByDescending(r => r.TotalWaste)
                                       .ToList();

        categories = categoryWaste.Select(r => r.Category).ToList();
        wastePerCategory = categoryWaste.Select(r => r.TotalWaste).ToList();
    }
}
