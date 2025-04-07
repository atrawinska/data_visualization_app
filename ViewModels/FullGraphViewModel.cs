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
        private GraphViewModel clickedChart;

public FullGraphViewModel(MainWindowViewModel _mwvc, GraphViewModel chart){
        mwvc = _mwvc;
        ClickedChart = chart;
        Debug.WriteLine("Entered the FullGraphMode");
 
  

    }


    [RelayCommand]
    private void DeleteGraph(){
        
         mwvc.BoardView();
         mwvc.Graphs.Remove(ClickedChart);
         Debug.WriteLine("Chart removed");

    }

    
    [RelayCommand]
    private void Close(){
         mwvc.BoardView();
    }

}