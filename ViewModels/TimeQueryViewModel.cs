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




namespace DataVisualizationApp.ViewModels;

public partial class TimeQueryViewModel : GraphViewModel
{

    public TimeQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        WasteOverTimeQueryRunner baseQuery = new();
        baseQuery.Run("USA");
        Title = "Waste in a country";
    var waste = baseQuery.wasteOverTime["USA"];
    var yearLabels = baseQuery.years.Select(y => y.ToString()).ToArray();

    Series = new ISeries[]
{
    new LineSeries<double>
    {
        Values = waste,
        Fill = null,
        GeometrySize = 8
    }
};


        XAxes = new Axis[]
        {
            new Axis { Name = "Year",  Labels = baseQuery.years.Select(y => y.ToString()).ToArray() }
        };

        YAxes = new Axis[]
        {
            new Axis { Name = "Total Waste (tons)", Labeler = val => val.ToString("N1") }
        };


       
    }



}
