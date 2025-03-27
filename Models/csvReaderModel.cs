using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DataVisualizationApp;

public static class CsvReaderHelper
{
    string filePath = "global_food_wastage_dataset.csv"; // file has to be added to the project folder

    public static List<FoodWasteData> ReadCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,  // Ensure it reads headers
            Delimiter = ",",         // Default is comma
            TrimOptions = TrimOptions.Trim
        }))
        {
            return new List<FoodWasteData>(csv.GetRecords<FoodWasteData>());
        }
    }
}