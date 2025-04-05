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
using Avalonia.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using DataVisualizationApp.Views;
using LiveChartsCore.SkiaSharpView.Avalonia;
using Avalonia.Media.TextFormatting.Unicode;
using System.Diagnostics;
using Avalonia;
using LiveChartsCore.VisualElements;
namespace DataVisualizationApp.ViewModels;


public partial class FullGraphViewModel : ObservableObject
{
        private MainWindowViewModel mwvc;

        [ObservableProperty]
        private Border clickedChart;

public FullGraphViewModel(MainWindowViewModel _mwvc, CartesianChart chart){
        mwvc = _mwvc;
        ClickedChart = AddGraph(chart);
      //  graph =  clciked graph
  

    }


    [RelayCommand]
    private void DeleteGraph(){
        
         mwvc.BoardView();
       //  CreateGraphViewModel buttonChart = new(mwvc);
        // var removedChart = buttonChart.AddGraph(clickedChart.Child);
       //  mwvc.Graphs.Remove(removedChart);
    }

    
    [RelayCommand]
    private void Close(){
        mwvc.BoardView();
    }


private Border AddGraph(CartesianChart chart){
    if(chart==null){
        Debug.WriteLine("No chart was passed");

        return new();

    } 

    var g = new CartesianChart();
    g.YAxes = chart.YAxes;
    g.XAxes = chart.XAxes;
    g.Series = chart.Series;


    var graphContainer = new Border
    {
        Child = g,  // Correctly assign the chart as the child of the Border
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch
        

    };

    return graphContainer;
}
}