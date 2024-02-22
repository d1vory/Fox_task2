namespace Task2;

public class Matrix
{
    public readonly int Rows;
    public readonly int Columns;
    private readonly int[,] _matrix;

    private readonly int _maxValue;
    private readonly int _minValue;


    public Matrix(int rows, int columns, int minValue=0, int maxValue=100, int? randomSeed = null)
    {
        Rows = rows;
        Columns = columns;
        _minValue = minValue;
        _maxValue = maxValue;

        _matrix = BuildMatrix(Rows, Columns, _minValue, _maxValue, randomSeed);
    }



    public int GetTrace()
    {
        int[] diagonal = GetMainDiagonal();
        return diagonal.Sum();
    }
    
    public void Print()
    {
        for (int i = 0; i < Rows; i++)
        {
            Console.Write("[");
            for (int j = 0; j < Columns; j++)
            {
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.Write($"{_matrix[i, j]}, ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("]\n");
        }
    }

    public int[] getSnailTrace()
    {
        int leftBorder = 0;
        int rightBorder = Columns - 1;
        int topBorder = 0;
        int bottomBorder = Rows - 1;
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
                    trail.Add(_matrix[i, rightBorder]);
                }

                return trail.ToArray();
            }

            for (int i = leftBorder; i < rightBorder; i++)
            {
                trail.Add(_matrix[topBorder, i]);
            }

            for (int i = topBorder; i < bottomBorder; i++)
            {
                trail.Add(_matrix[i, rightBorder]);
            }

            for (int i = rightBorder; i > leftBorder; i--)
            {
                trail.Add(_matrix[bottomBorder, i]);
            }

            for (int i = bottomBorder; i > topBorder; i--)
            {
                trail.Add(_matrix[i, leftBorder]);
            }

            leftBorder++;
            rightBorder--;
            topBorder++;
            bottomBorder--;
        }
    }

    private static int[,] BuildMatrix(int rows, int columns, int minValue, int maxValue, int? randomSeed=null)
    {
        Random rnd = randomSeed == null ? new Random() : new Random(randomSeed.Value);
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
        int minDimension = Math.Min(Columns, Rows);
        int[] trace = new int[minDimension];
        
        for (int i = 0; i < minDimension; i++)
        {
            trace[i] = _matrix[i, i];
        }
        return trace;
    }
    
    
}