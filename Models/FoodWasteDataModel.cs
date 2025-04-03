using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataVisualizationApp.Models;
public class FoodWasteData
{
    [Name("Country")]
    public string Country { get; set; } = String.Empty;
    // This line declares a public property named 'Country' of type 'string'.
    // The '[Name("Country")]' attribute indicates that this property corresponds to the "Country" column in the CSV file.
    // 'get' and 'set' allow reading and writing the value of 'Country'.

    [Name("Year")]
    public int Year { get; set; }

    [Name("Food Category")]
    public string FoodCategory { get; set; } = String.Empty;

    [Name("Total Waste (Tons)")]
    public double TotalWaste { get; set; }
    
    [Name("Economic Loss (Million $)")]
    public double EconomicLoss { get; set; }

    [Name("Avg Waste per Capita (Kg)")]
    public double AvgWastePerCapita { get; set; }

    [Name("Population (Million)")]
    public double Population { get; set; }

    [Name("Household Waste (%)")]
    public double HouseholdWaste { get; set; }
}