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
using LiveChartsCore.SkiaSharpView.Avalonia;

using System.Collections.Generic;
using DataVisualizationApp.Models;
using Avalonia.Controls;
using Avalonia.Controls;
using Avalonia.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace DataVisualizationApp.ViewModels;

public partial class CreateGraphViewModel : ObservableObject
{
    private readonly MainWindowViewModel mwvm;


    public CreateGraphViewModel(MainWindowViewModel _mwvm){
        mwvm = _mwvm;
    }



    public Button AddGraph(CartesianChart graph){

        var graphContainer = new Button(){

                   Content = graph,
        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Stretch,
        VerticalAlignment = Avalonia.Layout.VerticalAlignment.Stretch,



        };
        graphContainer.Click += Button_Click;
           
    
            return graphContainer;
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
{
    // Code to run when the button is clicked
    
    if (sender is Button clickedButton && clickedButton.Content is CartesianChart chart)
    {

        mwvm.FullGraphView(chart);
        Debug.WriteLine("Graph clicked");
  
        
    }

}









}