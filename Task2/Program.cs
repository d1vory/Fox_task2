using Task2;


Console.WriteLine("Hello, to start, enter the dimensions of the matrix.");



int rows = GetNumberFromUser("Rows: ");
int columns = GetNumberFromUser("Columns: ");


var mtr = new Matrix(rows, columns);

mtr.Print();

Console.WriteLine($"Matrix trace is {mtr.GetTrace()}");
return;


int GetNumberFromUser(string message)
{
    var isNumberValid = false;
    int number;
    do
    {
        Console.WriteLine(message);
        isNumberValid = int.TryParse(Console.ReadLine(), out number) && number > 0;
        if (!isNumberValid)
        {
            Console.WriteLine("Enter a valid positive number");
        }
    } while (!isNumberValid);
    return number;
}