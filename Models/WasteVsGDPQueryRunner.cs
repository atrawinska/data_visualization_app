using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVisualizationApp.Models;

public class WasteVsGDPQueryRunner
{
    public List<double> wastePerCapita = [];
    public List<double> economicLoss = [];

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
