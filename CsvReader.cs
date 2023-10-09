using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CSVRead_SortData
{
    // CsvReader class to read product data from a CSV file
    class CsvReader
    {
        public static List<Product> ReadProducts(string filePath)
        {
            if (File.Exists(filePath))
            {
                throw new FileNotFoundException("Error: The specified file was not found.", filePath);
            }

            var products = new List<Product>();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    // Skip the header row if present
                    reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if (values.Length >= 3 &&
                            decimal.TryParse(values[1], NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal price) &&
                            int.TryParse(values[2], out int quantity))
                        {
                            var product = new Product
                            {
                                ProductName = values[0],
                                Price = price,
                                Quantity = quantity
                            };
                            products.Add(product);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid data in CSV: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidDataException($"Error reading CSV file: {ex.Message}");
            }

            if (products.Count == 0)
            {
                throw new InvalidDataException("No valid products found in the CSV file.");
            }

            return products;
        }
    }
}
