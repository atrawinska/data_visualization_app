using System;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Kernel.Events;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Themes;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Avalonia;

using System.Collections.Generic;
using DataVisualizationApp.Models;
using Avalonia.Controls;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;

namespace DataVisualizationApp.Models;
public class WasteByCategoryQueryRunner : IGraph
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

    public CartesianChart CreateGraph()
{
    Run();

    var series = new ISeries[]
    {
        new ColumnSeries<double>
        {
            Values = wastePerCategory,
            Name = "Total Waste",
            Stroke = null,
            Fill = new SolidColorPaint(SKColors.Green),
        }
    };

    var chart = new CartesianChart
    {
        Series = series,
        XAxes = new Axis[]
        {
            new Axis
            {
                Name = "Food Category",
                Labels = categories // <-- Set categories as X-Axis labels
            }
        },
        YAxes = new Axis[]
        {
            new Axis
            {
                Name = "Total Waste (tons)",
                Labeler = value => value.ToString("N0")
            }
        }
    };

    return chart;
}

}

