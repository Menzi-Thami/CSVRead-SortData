CSV Sorting Solution
Overview
This solution provides a C# program to read data from a CSV file, process it, and perform sorting and grouping operations based on specific criteria. The program includes functionality to sort products by price, quantity, and name, as well as group products by name and sort each group by price.

Files:

Program.cs: Contains the main entry point of the application.
CsvReader.cs: Defines a class for reading products from a CSV file and validating the data.
ProductSorter.cs: Implements methods to sort products based on price, quantity, and name, and group products by name and sort within groups by price.
Menu.cs: Handles user input and displays menu options for sorting and displaying products.
This is to adhere to SOLID principles when writing code.
How to Use

Run the Program:

The program prompts the user to enter the file path of a CSV file.
The CSV file should have the following format: ProductName, Price, Quantity.
Example: Laptop, 799.99, 10

Menu Options:

1: Sort products by price (ascending).
2: Sort products by quantity (ascending).
3: Sort products alphabetically by name (ascending).
4: Group products by name and sort each group by price (ascending).
5: Exit the program.

Dependencies
This solution uses C# and .NET framework. Ensure you have a compatible .NET environment set up to run the program.

Notes
Invalid data in the CSV file will be displayed with an error message.
If no valid products are found in the CSV file, an error message will be displayed.

![Proof of concept2](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/8f642694-12d5-4648-9562-b0c301b4da90)
![Proof of concept](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/6ce574fd-87a9-4c51-877a-766c0d86cd8c)
![Proof of concept5](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/cb0c3f06-61b7-43eb-96dd-540289ebfb0f)
![Proof of concept4](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/02244d0c-a3a2-44bc-9949-9068a1b409a3)
![Proof of concept3](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/2783e986-ea7d-4f5b-9c63-c87429d135aa)

