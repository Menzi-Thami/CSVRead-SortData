using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CSVRead_SortData
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the file path of the CSV file: ");
                string filePath = Console.ReadLine();

                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Error: The specified file was not found. File Path: {filePath}");
                }

                var products = CsvReader.ReadProducts(filePath);
                var sorter = new ProductSorter(products);
                var menu = new Menu(sorter);
                menu.ShowMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}