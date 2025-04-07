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

using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace DataVisualizationApp.ViewModels;

public partial class CapitaQueryViewModel : GraphViewModel
{
    [ObservableProperty]
    private string selectedCountry = "USA";

    [ObservableProperty]
    private string selectedYear = "2024";

    CountryProvider countryProvider = new();

    public ObservableCollection<SelectableButtonViewModel> CountryButtons { get; } = new();
    public ObservableCollection<SelectableButtonViewModel> YearButtons { get; } = new();

    public CapitaQueryViewModel(MainWindowViewModel parent) : base(parent)
    {
        GenerateCountryButtons();
        GenerateYearButtons();
        MakeChart();
    }

    public void GenerateCountryButtons()
    {
        CountryButtons.Clear();
        foreach (var country in countryProvider.GetFiveAvailableCountries())
        {
            CountryButtons.Add(new SelectableButtonViewModel(country, SelectCountry));
        }
    }

    public void GenerateYearButtons()
    {
        YearButtons.Clear();
        foreach (var year in new[] { "2022", "2023", "2024" })
        {
            YearButtons.Add(new SelectableButtonViewModel(year, SelectYear));
        }
    }

private void MakeChart()
{
    if (string.IsNullOrEmpty(SelectedCountry) || string.IsNullOrEmpty(SelectedYear))
        return;

    if (!int.TryParse(SelectedYear, out int parsedYear))
        return;

    var baseQuery = new CapitaQueryRunner();
    baseQuery.Run(SelectedCountry, parsedYear);

    Title = $"Avg. Waste Per Capita in {SelectedCountry} by Category ({SelectedYear})";

    var ordered = baseQuery.wasteByCategory.OrderBy(kv => kv.Key).ToList();

    Series = new ISeries[]
    {
        new RowSeries<double>
        {
            Values = ordered.Select(kv => kv.Value).ToArray(),
            Name = "Waste Per Capita",
            Fill = new SolidColorPaint(SKColors.Pink)
        }
    };

XAxes = new Axis[]
{
    new Axis { Name = "Waste (kg)", Labeler = val => val.ToString("N1") }
};

YAxes = new Axis[]
{
    new Axis { Labels = ordered.Select(kv => kv.Key).ToArray(), Name = "Category" }
};
}

    [RelayCommand]
    private void SelectCountry(string country)
    {
        SelectedCountry = country;
        MakeChart();
        Debug.WriteLine($"Country changed to: {country}");
    }

    [RelayCommand]
    private void SelectYear(string year)
    {
        SelectedYear = year;
        MakeChart();
        Debug.WriteLine($"Year changed to: {year}");
    }
}