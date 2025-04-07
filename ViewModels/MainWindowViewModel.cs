using CommunityToolkit.Mvvm.ComponentModel;
using DataVisualizationApp.Models;
using Avalonia.Controls;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Diagnostics;
using LiveChartsCore.SkiaSharpView.Avalonia;
using DataVisualizationApp.Views;
using LiveChartsCore;
using System.Diagnostics;
using System.Linq;



namespace DataVisualizationApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{


    [ObservableProperty]
    private UserControl dashboard;
    private CreateGraphViewModel graph;

    [ObservableProperty]
    private UserControl currentView;

    public ObservableCollection<GraphViewModel> Graphs { get; set; } = new ObservableCollection<GraphViewModel>();


    WasteByCategoryQueryRunner wasteByCategoryQueryRunner = new();
    WasteByCountryQueryRunner wasteByCountryQueryRunner = new();
    //WasteOverTimeQueryRunner wasteOverTimeQueryRunner = new();
    //GDPQueryViewModel wasteVsGDPQueryRunner = new();









    public MainWindowViewModel()
    {

        // DragDropViewModel ddViewModel = new();
        // Dashboard = new DragDropView { DataContext = ddViewModel };
        graph = new(this);
        BoardView();




    }

    public void FullGraphView(GraphViewModel chart)
    {
        if (chart == null) return;

        CurrentView = new FullGraphView
        {
            DataContext = new FullGraphViewModel(this, chart)
        };


    }
    public void BoardView()
    {
        Debug.WriteLine("BoardView() called!");
        CurrentView = new DashboardView { DataContext = new DashboardViewModel(this) };

    }

    [RelayCommand]
    private void GDPClick()
    {
        GraphViewModel graph = new GDPQueryViewModel(this);
        Graphs.Add(graph);
        Debug.WriteLine("Graph added to the list");
        Debug.WriteLine("XAxes: " + string.Join(", ", graph.XAxes.Select(x => x.Name)));
        Debug.WriteLine("YAxes: " + string.Join(", ", graph.YAxes.Select(y => y.Name)));
        Debug.WriteLine("Series: " + string.Join(", ", graph.Series.Select(s => s.GetType().Name)));
        foreach (var k in Graphs)
        {
            Debug.WriteLine(k.Title);

        }

        Debug.WriteLine($"Graph {graph.Title} added. Series count: {graph.Series?.Length}, XAxes: {graph.XAxes?.Length}, YAxes: {graph.YAxes?.Length}");


        BoardView();



    }
    [RelayCommand]
    public void TimeClick()
    {
        GraphViewModel graph = new TimeQueryViewModel(this);
        Graphs.Add(graph);
        BoardView();
    }


    [RelayCommand]
    private void CountryClick()
    {
        GraphViewModel graph = new CountryQueryViewModel(this);
        Graphs.Add(graph);
        BoardView();
    }

    [RelayCommand]
    private void CapitaClick()
    {
        GraphViewModel graph = new CategoryQueryViewModel(this);
        Graphs.Add(graph);
        BoardView();
    }

}