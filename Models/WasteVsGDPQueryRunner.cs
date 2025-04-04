using System;
using System.Collections.Generic;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.Kernel.Events;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Themes;
using LiveChartsCore.SkiaSharpView.Avalonia;

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
using System.Collections.Generic;
using DataVisualizationApp.Models;
using Avalonia.Controls;
using DataVisualizationApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;


namespace DataVisualizationApp.Models;

public class WasteVsGDPQueryRunner : IGraph
{
    public List<double> wastePerCapita = new();
    public List<double> economicLoss = new();

    public void Run()
    {
        DataLoader<FoodWasteData> loader = new DataLoader<FoodWasteData>();
        loader.LoadData("global_food_wastage_dataset.csv");

        var wasteVsGDP = loader.data.GroupBy(record => record.Country)
                                    .Select(group => new
                                    {
                                        WastePerCapita = group.Average(record => record.AvgWastePerCapita),
                                        EconomicLoss = group.Average(record => record.EconomicLoss)
                                    })
                                    .ToList();

        wastePerCapita = wasteVsGDP.Select(r => r.WastePerCapita).ToList();
        economicLoss = wasteVsGDP.Select(r => r.EconomicLoss).ToList();
    }


   public  CartesianChart CreateGraph()
        {
            Run();
            ISeries[] series= new ISeries[]
            {
                new LineSeries<double>
                {
                    Values=wastePerCapita
                },
                new ColumnSeries<double>
                {
                    Values=economicLoss
                }
            };
                        var chart = new CartesianChart
            {
                Series = series,
                XAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Waste Per Capita",
                        Labeler = value => value.ToString("N1")
                    }
                },
                YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Economic Loss",
                        Labeler = value => value.ToString("N1")
                    }
                }
            };

            return chart;
        }
}
