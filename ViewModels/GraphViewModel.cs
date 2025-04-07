using System;
using System.Collections.Generic;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using  DataVisualizationApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace DataVisualizationApp.ViewModels;
public abstract partial class GraphViewModel : ObservableObject
{
    [ObservableProperty]
    public string title = "Untitled";

    [ObservableProperty]
    private ISeries[] series;

    [ObservableProperty]
    private Axis[] xAxes;

    [ObservableProperty]
    private Axis[] yAxes;

    public ICommand ExpandCommand { get; }

    protected GraphViewModel(MainWindowViewModel parent)
    {
        ExpandCommand = new RelayCommand(() => parent.FullGraphView(this));
    }
}
