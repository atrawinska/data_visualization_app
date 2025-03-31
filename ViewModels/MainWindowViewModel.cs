using System.Collections.Generic;
using System.Collections.ObjectModel;
using LiveChartsCore;
using charts_app.Services;
using LiveChartsCore.SkiaSharpView;

namespace charts_app.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private readonly ChartService _chartService;
    private ObservableCollection<ISeries> _series;

    public MainWindowViewModel(ChartService chartService)
    {
        _chartService = chartService;
        Series = _chartService.GetColumnSeries(); // Set the initial chart type
    }

    public ObservableCollection<ISeries> Series
    {
        get => _series;
        set => SetProperty(ref _series, value);
    }
}