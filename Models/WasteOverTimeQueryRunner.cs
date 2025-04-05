using System;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using System.Collections.Generic;


namespace DataVisualizationApp.Models;
public class WasteOverTimeQueryRunner : IGraph
{
    public Dictionary<string, List<double>> wasteOverTime = new();
    public List<int> years =new();

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


    
public CartesianChart CreateGraph()
{
    Run("USA");

    // Ensure the data is aligned
    var waste = wasteOverTime["USA"];
    var yearLabels = years.Select(y => y.ToString()).ToArray();

    var series = new ISeries[]
    {
        new LineSeries<double>
        {
            Values = waste,
            Fill = null,
            GeometrySize = 8
        }
    };

    var chart = new CartesianChart
    {
        Series = series,
        XAxes = new Axis[]
        {
            new Axis
            {
                Name = "Year",
                Labels = yearLabels
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









