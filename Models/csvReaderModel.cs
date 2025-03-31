using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics;


namespace DataVisualizationApp;

public class CsvReaderHelper
{
    string filePath = "global_food_wastage_dataset.csv"; // file has to be added to the project

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
            var records = new List<FoodWasteData>(csv.GetRecords<FoodWasteData>());
        
            // Print the number of records loaded
            Debug.WriteLine($"Loaded {records.Count} records from CSV.");
            
            return records;
        }
    }
}