using System;
using System.Collections.Generic;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using DataVisualizationApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia;





namespace DataVisualizationApp.ViewModels;

public partial class TimeQueryViewModel : GraphViewModel
{
  

    public ObservableCollection<Button> CountryButtons { get; } = new();

    public TimeQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        MakeChart();
        GenerateCountryButtons();
       

       
    }


    public void GenerateCountryButtons()
{
     CountryProvider countryProvider = new();
    CountryButtons.Clear();

    var random = new Random();
    var countries = countryProvider.GetFiveAvailableCountries();

   foreach (var country in countries)
    {
        var button = new Button
        {
            Content = country,
             Foreground = Brushes.White,
    Background = Brushes.SteelBlue,
    CornerRadius = new CornerRadius(6),
     Margin = new Thickness(5),
            
        };

        // Inline event handler
        button.Click += (_, _) =>
        {
            MakeChart(country);
            Debug.WriteLine($"Country changed to: {country}");
            
        };

        CountryButtons.Add(button);
    }
}

private void MakeChart(String country = "USA"){

     WasteOverTimeQueryRunner baseQuery = new();
        baseQuery.Run(country);
        Title = "Waste in a country";
    var waste = baseQuery.wasteOverTime[country];
    var yearLabels = baseQuery.years.Select(y => y.ToString()).ToArray();

    Series = new ISeries[]
{
    new LineSeries<double>
    {
        Values = waste,
        Fill = null,
        GeometrySize = 8
    }
};


        XAxes = new Axis[]
        {
            new Axis { Name = "Year",  Labels = baseQuery.years.Select(y => y.ToString()).ToArray() }
        };

        YAxes = new Axis[]
        {
            new Axis { Name = "Total Waste (tons)", Labeler = val => val.ToString("N1") }
        };


}





}
