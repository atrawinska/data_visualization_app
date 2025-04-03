using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace DataVisualizationApp.Models;

public class DataLoader<T> where T : class
{
    public List<T> data = new List<T>();

    public void LoadData(string path)
    {
        using (var reader = new StreamReader(path))

        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            data = csv.GetRecords<T>().ToList();
        }
    }
}