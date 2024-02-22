using Task2;


Console.WriteLine("Hello, to start, enter the dimensions of the matrix.");

int rows;
int columns;

do
{
    try
    {
        Console.WriteLine("Rows: ");
        rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Columns: ");
        columns = int.Parse(Console.ReadLine());

        if ((rows <= 0) || (columns <= 0))
        {
            Console.WriteLine("Enter a positive number");
        }
        else
        {
            break;

        }
    }
    catch (SystemException)
    {
        Console.WriteLine("Enter a valid number");
    }

} while (true);


Matrix mtr = new Matrix(rows,columns );

mtr.Print();

Console.WriteLine($"Matrix trace is {mtr.GetTrace()}");

