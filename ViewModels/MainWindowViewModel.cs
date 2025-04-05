using CommunityToolkit.Mvvm.ComponentModel;
using DataVisualizationApp.Models;
using Avalonia.Controls;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Diagnostics;
using LiveChartsCore.SkiaSharpView.Avalonia;
using DataVisualizationApp.Views;
using LiveChartsCore;



namespace DataVisualizationApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{


    [ObservableProperty]
    private UserControl dashboard;
    private CreateGraphViewModel graph;

    [ObservableProperty]
    private UserControl currentView;

    public ObservableCollection<Button> Graphs { get; set; } = new ObservableCollection<Button>();


    WasteByCategoryQueryRunner wasteByCategoryQueryRunner = new();
    WasteByCountryQueryRunner wasteByCountryQueryRunner = new();
    WasteOverTimeQueryRunner  wasteOverTimeQueryRunner = new();
    WasteVsGDPQueryRunner wasteVsGDPQueryRunner = new();









    public MainWindowViewModel()
    {
     
        // DragDropViewModel ddViewModel = new();
        // Dashboard = new DragDropView { DataContext = ddViewModel };
       graph = new(this);
       BoardView();



       
    }

    public void FullGraphView(CartesianChart chart)
    {
        if(chart==null)return; 

      // fullView = FullViewView();
       CurrentView = new FullGraphView{ DataContext = new FullGraphViewModel(this, chart)};
      


    }
    public void BoardView(){
         CurrentView = new DashboardView { DataContext = new DashboardViewModel(this) };
      
    }

   [RelayCommand]
    private void GDPClick(){
       // CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteVsGDPQueryRunner.CreateGraph()));

    }
[RelayCommand]
public void TimeClick()
{
    CartesianChart chart = wasteOverTimeQueryRunner.CreateGraph(); 
    Graphs.Add(graph.AddGraph(chart)); 
}

    
       [RelayCommand]
    private void CountryClick(){
       // CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteByCountryQueryRunner.CreateGraph()));

    }
    
       [RelayCommand]
    private void CapitaClick(){
       // CreateGraphViewModel graph = new(this);
        Graphs.Add(graph.AddGraph(wasteByCategoryQueryRunner.CreateGraph()));

    }

}