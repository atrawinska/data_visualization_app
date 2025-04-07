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

public partial class CategoryQueryViewModel : GraphViewModel
{

    public CategoryQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        WasteByCategoryQueryRunner baseQuery = new();
        baseQuery.Run();
        

    Series = new ISeries[]
    {
        new ColumnSeries<double>
        {
            Values = baseQuery.wastePerCategory,
            Name = "Total Waste",
            Stroke = null,
            Fill = new SolidColorPaint(SKColors.LightGreen),
            
        }
    };


      XAxes = new Axis[]
        {
            new Axis
            {
                Name = "Total Waste (tons)",
                Labeler = value => value.ToString("N0")
            }
            
        };

        YAxes = new Axis[]
        {
            new Axis
            {
                Name = "Food Category",
                Labels = baseQuery.categories // <-- Set categories as X-Axis labels
            }
        };


       
    }



}
