using CSVRead_SortData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

try
{
    Console.Write("Enter the file path of the CSV file: ");
    string filePath = Console.ReadLine();

    if (File.Exists(filePath))
    {
        var products = CsvReader.ReadProducts(filePath);
        var sorter = new ProductSorter(products);
        var menu = new Menu(sorter);
        menu.ShowMenu();
    }
    else
    {
        Console.WriteLine("File not found. Please provide a valid file path.");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
