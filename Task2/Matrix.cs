namespace Task2;

public class Matrix
{
    public readonly int rows;
    public readonly int columns;
    private int[,] matrix;

    public Matrix(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;

        matrix = BuildMatrix(this.rows, this.columns);
    }

    public int GetTrace()
    {
        int[] diagonal = GetMainDiagonal();
        return diagonal.Sum();
    }
    
    public void Print()
    {
        for (int i = 0; i < rows; i++)
        {
            Console.Write("[");
            for (int j = 0; j < columns; j++)
            {
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{matrix[i, j]}, ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("]\n");
        }
    }

    public int[] getSnailTrace()
    {
        int leftBorder = 0;
        int rightBorder = columns - 1;
        int topBorder = 0;
        int bottomBorder = rows - 1;
        List<int> trail = new List<int>();
        
        while (true)
        {
            if (leftBorder > rightBorder)
            {
                return trail.ToArray();
            }

            if (leftBorder == rightBorder)
            {
                for (int i = topBorder; i <= bottomBorder; i++)
                {
                    trail.Add(matrix[i, rightBorder]);
                }

                return trail.ToArray();
            }

            for (int i = leftBorder; i < rightBorder; i++)
            {
                trail.Add(matrix[topBorder, i]);
            }

            for (int i = topBorder; i < bottomBorder; i++)
            {
                trail.Add(matrix[i, rightBorder]);
            }

            for (int i = rightBorder; i > leftBorder; i--)
            {
                trail.Add(matrix[bottomBorder, i]);
            }

            for (int i = bottomBorder; i > topBorder; i--)
            {
                trail.Add(matrix[i, leftBorder]);
            }

            leftBorder++;
            rightBorder--;
            topBorder++;
            bottomBorder--;
        }
    }

    private static int[,] BuildMatrix(int rows, int columns, int minValue = 0, int maxValue=100)
    {
        Random rnd = new Random();
        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = rnd.Next(minValue, maxValue);
            }
        }

        return matrix;
    }
    
    private int[] GetMainDiagonal()
    {
        int minDimension = Math.Min(columns, rows);
        int[] trace = new int[minDimension];
        
        for (int i = 0; i < minDimension; i++)
        {
            trace[i] = matrix[i, i];
        }

        return trace;
    }
    
    
}