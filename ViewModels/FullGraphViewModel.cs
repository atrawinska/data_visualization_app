using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using DataVisualizationApp.Views;
using LiveChartsCore.SkiaSharpView.Avalonia;
using System.Diagnostics;
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
         ClickedChart.Child = null;        
         mwvc.BoardView();
       //  CreateGraphViewModel buttonChart = new(mwvc);
        // var removedChart = buttonChart.AddGraph(clickedChart.Child);
       //  mwvc.Graphs.Remove(removedChart);
    }

    
    [RelayCommand]
    private void Close(){
         ClickedChart.Child = null;
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