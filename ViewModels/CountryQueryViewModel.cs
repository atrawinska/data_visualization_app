using System;
using System.Collections.Generic;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using DataVisualizationApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.Painting;




namespace DataVisualizationApp.ViewModels;

public partial class CountryQueryViewModel : GraphViewModel
{

    public CountryQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        WasteByCountryQueryRunner baseQuery = new();
        baseQuery.Run(5);
        

    Series = new ISeries[]
    {
        new ColumnSeries<double>
        {
            Values = baseQuery.totalWastePerCountry,
            Name = "Total Waste",
            Stroke = null,
            Fill = new SolidColorPaint(SKColors.Blue),
            
        }
    };


       YAxes = new Axis[]
        {
            new Axis
            {
                Name = "Total Waste (tons)",
                Labeler = value => value.ToString("N0")
            }
        };

        XAxes = new Axis[]
        {
            new Axis
            {
                Name = "Country",
                Labels = baseQuery.countryNames // <-- Set country names as X-Axis labels
            }
        };


       
    }



}
