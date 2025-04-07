using System;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Themes;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Avalonia;
using System.Collections.Generic;


namespace DataVisualizationApp.Models;
public class WasteByCategoryQueryRunner
{
    public List<double> wastePerCategory = new();
    public List<string> categories = new();

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

