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

public class WasteByCountryQueryRunner : IGraph
{
    public List<double> totalWastePerCountry = new();
    public List<string> countryNames = new();

    public void Run(int numCountries)
    {
        DataLoader<FoodWasteData> wasteLoader = new DataLoader<FoodWasteData>();
        wasteLoader.LoadData("global_food_wastage_dataset.csv");

        var wasteRecords = wasteLoader.data;

        var totalWasteByCountry = wasteRecords.GroupBy(record => record.Country)
                                            .Select(group => new
                                            {
                                                Country = group.Key,
                                                TotalWaste = group.Sum(record => record.TotalWaste)
                                            })
                                            .OrderByDescending(result => result.TotalWaste)
                                            .ToList();

        // This block groups the food waste records by country and calculates the total waste for each country.
        // It creates a new anonymous object containing the Country name and TotalWaste.
        // The result is ordered by descending total waste and converted to a list.

        totalWastePerCountry = totalWasteByCountry.Select(result => result.TotalWaste).Take(numCountries).ToList();
        // This line selects the total waste values and converts them to a list of doubles.
        // It stores the result in the 'totalWastePerCountry' field.

        countryNames = totalWasteByCountry.Select(result => result.Country).Take(numCountries).ToList();
        // This line selects the country names and converts them to a list of strings.
        // It stores the result in the 'countryNames' field.
    }


    
public CartesianChart CreateGraph()
{
    Run(5);

    var series = new ISeries[]
    {
        new ColumnSeries<double>
        {
            Values = totalWastePerCountry,
            Name = "Total Waste",
            Stroke = null,
            Fill = new SolidColorPaint(SKColors.Blue),
        }
    };

    var chart = new CartesianChart
    {
        Series = series,
        XAxes = new Axis[]
        {
            new Axis
            {
                Name = "Country",
                Labels = countryNames // <-- Set country names as X-Axis labels
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





