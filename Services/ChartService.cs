using System.Collections.Generic;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.Painting.Effects;
using SkiaSharp; 

namespace charts_app.Services;

public class ChartService
{
    public ObservableCollection<ISeries> GetColumnSeries()
    {
        return new ObservableCollection<ISeries>
        {
            new ColumnSeries<ChartDataModel>
            {
                Values = new ObservableCollection<ChartDataModel>
                {
                    new ChartDataModel { Category = "A", Value = 10 },
                    new ChartDataModel { Category = "B", Value = 20 }
                }
            }
        };
    }

    public ObservableCollection<ISeries> GetLineSeries()
    {
        return new ObservableCollection<ISeries>
        {
            new LineSeries<ChartDataModel>
            {
                Values = new ObservableCollection<ChartDataModel>
                {
                    new ChartDataModel { Category = "A", Value = 15 },
                    new ChartDataModel { Category = "B", Value = 25 }
                }
            }
        };
    }
}
