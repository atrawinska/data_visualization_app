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


    

}





