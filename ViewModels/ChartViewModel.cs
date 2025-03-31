using LiveChartsCore;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using System.Collections.Generic;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp;
using charts_app.Services;

namespace charts_app.ViewModels;

public class ChartViewModel : ViewModelBase
{
    private readonly ChartService _chartService;

    public ObservableCollection<ISeries> Series { get; set; }

    public ChartViewModel(ChartService chartService)
    {
        _chartService = chartService;
        Series = _chartService.GetColumnSeries();
    }
}