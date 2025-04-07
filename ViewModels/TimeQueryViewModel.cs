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

    [ObservableProperty]
    private string userInput = string.Empty;

    [ObservableProperty]
    private string selectedCountry;


    partial void OnUserInputChanged(string value)
    {
        FilterButtons(value);
        if(string.IsNullOrEmpty(userInput)){
            GenerateCountryButtons();
        }
    }

    CountryProvider countryProvider = new();

    public ObservableCollection<Button> CountryButtons { get; } = new();

    public TimeQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        MakeChart();
        GenerateCountryButtons();



    }


    public void GenerateCountryButtons()
    {

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

    private void MakeChart(String country = "USA")
    {

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


    private void FilterButtons(string input)
    {
        CountryButtons.Clear();

        var matching = countryProvider
            .GetAllAvailableCountries()
            .Where(c => c.StartsWith(input, StringComparison.OrdinalIgnoreCase))
            ; 

        foreach (var country in matching)
        {
            var button = new Button
            {
                Content = country,
                Foreground = Brushes.White,
                Background = Brushes.SteelBlue,
                CornerRadius = new CornerRadius(6),
                Margin = new Thickness(5),
            };

            button.Click += (_, _) =>
            {
                SelectedCountry = country;
                MakeChart(country);
            };

            CountryButtons.Add(button);
        }
    }






}
