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


namespace DataVisualizationApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{


    [ObservableProperty]
    private UserControl dashboard;




    public MainWindowViewModel()
    {
     
        DragDropViewModel ddViewModel = new();
        Dashboard = new DragDropView { DataContext = ddViewModel };



       
    }
}