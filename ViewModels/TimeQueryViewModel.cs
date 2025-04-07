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

    private bool _buttonsInitialized = false;



    partial void OnUserInputChanged(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            CountryButtons.Clear();

            GenerateCountryButtons();
        }
        else
        {
            CountryButtons.Clear();
            FilterButtons(value);
        }

    }

    CountryProvider countryProvider = new();

    public ObservableCollection<SelectableButtonViewModel> CountryButtons { get; } = new();


    public TimeQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        CountryButtons.Clear();
        MakeChart();
        GenerateCountryButtons();




    }

    public void GenerateCountryButtons()
    {
        CountryButtons.Clear();
        foreach (var country in countryProvider.GetFiveAvailableCountries())
        {
            CountryButtons.Add(new SelectableButtonViewModel(country, MakeChart));
        }
    }

    private void MakeChart(String country = "USA")
    {
        SelectedCountry = country;

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
            CountryButtons.Add(new SelectableButtonViewModel(country, MakeChart));
        }

    }


    [RelayCommand]
    private void SelectCountry(string country)
    {
        SelectedCountry = country;
        MakeChart(country);
        Debug.WriteLine($"Country changed to: {country}");
    }





}
