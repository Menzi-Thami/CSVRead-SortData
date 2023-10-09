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
                // Prompt user for CSV file path
                Console.Write("Enter the file path of the CSV file: ");
                string filePath = Console.ReadLine();

                // Replace special characters in the file path
                filePath = filePath.Replace("\"", "").Replace("\\", "\\\\");

                // Check if the file exists, throw exception if not found
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Error: The specified file was not found. File Path: {filePath}");
                }

                // Read products from CSV file and perform sorting/grouping operations
                var products = CsvReader.ReadProducts(filePath);
                var sorter = new ProductSorter(products);
                var menu = new Menu(sorter);
                menu.ShowMenu();
            }
            catch (Exception ex)
            {
                // Handle and display any exceptions
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor();
            }
            Console.ReadLine();
        }
    }
}