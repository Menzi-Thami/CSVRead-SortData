using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVRead_SortData
{
    class Menu
    {
        private ProductSorter _productSorter;

        public Menu(ProductSorter productSorter)
        {
            _productSorter = productSorter;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Sort by Price (ascending)");
                Console.WriteLine("2. Sort by Quantity (ascending)");
                Console.WriteLine("3. Sort alphabetically by Product Name (ascending)");
                Console.WriteLine("4. Group by Product Name and sort each group by Price (ascending)");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayProducts(_productSorter.SortByPriceAscending());
                            break;
                        case 2:
                            DisplayProducts(_productSorter.SortByQuantityAscending());
                            break;
                        case 3:
                            DisplayProducts(_productSorter.SortByNameAscending());
                            break;
                        case 4:
                            DisplayGroupedProducts(_productSorter.GroupByNameAndSort());
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("Sorted Products:");
            Console.WriteLine("Product Name\tPrice (ZAR)\tQuantity");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductName}\t\t{product.Price}\t\t{product.Quantity}");
            }
        }

        private void DisplayGroupedProducts(Dictionary<string, List<Product>> groupedProducts)
        {
            Console.WriteLine("Grouped and Sorted Products:");
            Console.WriteLine("Product Name\tPrice (ZAR)\tQuantity");

            foreach (var group in groupedProducts)
            {
                Console.WriteLine($"--- {group.Key} ---");

                foreach (var product in group.Value)
                {
                    Console.WriteLine($"{product.ProductName}\t\t{product.Price}\t\t{product.Quantity}");
                }

                Console.WriteLine();
            }
        }
    }
}