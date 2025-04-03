/*
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.Themes;
using LiveChartsCore.Kernel.Events;
using LiveChartsCore.Measure;
using SkiaSharp;
using System.Collections.Generic;
using DataVisualizationApp.Models;

namespace DataVisualizationApp.ViewModels;

public partial class ChartViewModel : ObservableObject
{
    private List<double> totalWastePerCountry = new();
    private List<string> countryNames = new();

    public ISeries[] Series { get; set; } = [];
    public Axis[] YAxes { get; set; } = [];

    public ChartViewModel()
    {
        WasteByCountryQueryRunner runner = new();
        runner.Run(10);

        totalWastePerCountry = runner.totalWastePerCountry;
        countryNames = runner.countryNames;

        Series = [
            new RowSeries<double>
            {
                Values = totalWastePerCountry,
            }
        ];

        YAxes = [
            new Axis
            {
                Labels = countryNames,
            }
        ];
    }
}
*/