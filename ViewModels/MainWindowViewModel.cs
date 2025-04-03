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

namespace DataVisualizationApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // Observable property that can be bound to the UI to display output
    [ObservableProperty]
    private string output = String.Empty;

    private List<double> totalWastePerCountry = new();
    private List<string> countryNames = new();
    
    // Property to hold the series data for the chart, initialized as an empty array
    public ISeries[] Series { get; set; } = [];

    // Property to hold the Y-axis data for the chart, initialized as an empty array
    public Axis[] YAxes { get; set; } = [];

    public MainWindowViewModel()
    {
        // Create an instance of TotalWasteByCountryQueryRunner to fetch total waste data
        WasteByCountryQueryRunner runner = new();

        // Run the query to get the top 1000 movie genres
        runner.Run(10);

        // Assign the fetched total waste to the counts list
        totalWastePerCountry = runner.totalWastePerCountry;
        // same for the country names
        countryNames = runner.countryNames;

        // Initialize the Series property with the counts data for the chart
        Series = [
            new RowSeries<double>
            {
                // Set the Values property of the RowSeries to the counts list
                Values = totalWastePerCountry,
            }
        ];

        // Initialize the YAxes property with the genres data for the chart
        YAxes = [
            new Axis
            {
                // Set the Labels property of the Axis to the genres list
                Labels = countryNames,
            }
        ];
    }
}