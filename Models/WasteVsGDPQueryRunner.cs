using System;
using System.Collections.Generic;
using System.Linq;
using LiveChartsCore;

using LiveChartsCore.SkiaSharpView;

using LiveChartsCore.SkiaSharpView.Avalonia;




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

}
