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

![Proof of concept5](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/bb1bdc0d-3bf3-42c6-97a5-e40261864638)
![Proof of concept4](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/f367ed0b-d7a9-416b-80da-5320a66a4286)
![Proof of concept3](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/bb123a61-c133-4071-a22c-03a17f393b45)
![Proof of concept2](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/6e541961-80c3-4627-a125-5338a7912b86)
![Proof of concept](https://github.com/Menzi-Thami/CSVRead-SortData/assets/43884343/dec32e66-7374-4731-94cf-4e0ea7281e61)

