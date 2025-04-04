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
using DataVisualizationApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;


namespace DataVisualizationApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{


    [ObservableProperty]
    private UserControl dashboard;

    public ObservableCollection<Button> Graphs { get; set; } = new ObservableCollection<Button>();


    WasteByCategoryQueryRunner wasteByCategoryQueryRunner = new();
    WasteByCountryQueryRunner wasteByCountryQueryRunner = new();
    WasteOverTimeQueryRunner  wasteOverTimeQueryRunner = new();
    WasteVsGDPQueryRunner wasteVsGDPQueryRunner = new();









    public MainWindowViewModel()
    {
     
        // DragDropViewModel ddViewModel = new();
        // Dashboard = new DragDropView { DataContext = ddViewModel };



       
    }

   [RelayCommand]
    private void GDPClick(){
        CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteVsGDPQueryRunner.CreateGraph()));

    }

       [RelayCommand]
    private void TimeClick(){
        CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteOverTimeQueryRunner.CreateGraph()));

    }

    
       [RelayCommand]
    private void CountryClick(){
        CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteByCountryQueryRunner.CreateGraph()));

    }
    
       [RelayCommand]
    private void CapitaClick(){
        CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteByCategoryQueryRunner.CreateGraph()));

    }

}