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

public partial class GDPQueryViewModel : GraphViewModel
{

    public GDPQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        WasteVsGDPQueryRunner baseQuery = new();
        baseQuery.Run();
        Title = "GDP vs Waste";

        Series = new ISeries[]
        {
            new LineSeries<double> { Values = baseQuery.wastePerCapita },
            new ColumnSeries<double> { Values = baseQuery.economicLoss }
        };

        XAxes = new Axis[]
        {
            new Axis { Name = "Waste Per Capita", Labeler = val => val.ToString("N1") }
        };

        YAxes = new Axis[]
        {
            new Axis { Name = "Economic Loss", Labeler = val => val.ToString("N1") }
        };

        Debug.WriteLine("WPC: " + string.Join(",", baseQuery.wastePerCapita));
Debug.WriteLine("EL : " + string.Join(",", baseQuery.economicLoss));

    }



}
