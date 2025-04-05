
using System;
using System.Collections.Generic;
using System.Linq;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace DataVisualizationApp.Models;
public class Graph
{
    public List<ISeries> Series { get; }
    public List<Axis> XAxes { get; }
    public List<Axis> YAxes { get; }

    public Graph(IEnumerable<ISeries> series, IEnumerable<Axis> xAxes, IEnumerable<Axis> yAxes)
    {
        Series = series.ToList();
        XAxes = xAxes.ToList();
        YAxes = yAxes.ToList();
    }
}