using Task2;


Console.WriteLine("Hello, to start, enter the dimensions of the matrix.");

int rows;
int columns;

var isRowValid = false;
var isColumnValid = false;


do
{
    Console.WriteLine("Rows: ");
    isRowValid = int.TryParse(Console.ReadLine(), out rows) && rows > 0;
    if (!isRowValid)
    {
        Console.WriteLine("Enter a valid positive number");
    }
} while (!isRowValid);


do
{
    Console.WriteLine("Columns: ");
    isColumnValid = int.TryParse(Console.ReadLine(), out columns) && columns > 0;
    if (!isColumnValid)
    {
        Console.WriteLine("Enter a valid positive number");
    }
} while (!isColumnValid);


var mtr = new Matrix(rows, columns);

mtr.Print();

Console.WriteLine($"Matrix trace is {mtr.GetTrace()}");