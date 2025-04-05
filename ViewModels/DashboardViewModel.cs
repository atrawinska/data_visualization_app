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
using Avalonia.Media.TextFormatting.Unicode;
namespace DataVisualizationApp.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
   // private object graph;
  
    [ObservableProperty]
    public MainWindowViewModel mwvc;
    public DashboardViewModel(MainWindowViewModel _mwvc){

      Mwvc = _mwvc;


    }



    
}

