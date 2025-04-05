
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView.Avalonia;
using Avalonia.Controls;

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
        mwvm.Graphs.Remove(clickedButton);
        mwvm.FullGraphView(chart);
        Debug.WriteLine("Graph clicked");
  
        
    }

}









}