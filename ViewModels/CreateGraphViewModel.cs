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

namespace DataVisualizationApp.ViewModels;

public partial class CreateGraphViewModel : ObservableObject
{
    public Border AddGraph(CartesianChart graph){

        Border graphContainer = new Border
            {
                Width = 300,
                Height = 200,
                Background = Brushes.LightGray,
                BorderBrush = Brushes.Black,
                
                

            };
            graphContainer.Child = graph;
            return graphContainer;
    }








}