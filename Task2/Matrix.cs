namespace Task2;

public class Matrix
{
    public readonly int Rows;
    public readonly int Columns;
    private readonly int[,] _matrix;


    public Matrix(int rows, int columns, int minValue=0, int maxValue=100, int? randomSeed = null)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new ArgumentException($"Dimensions [{rows}, {columns}] are not positive numbers!");
        }
        Rows = rows;
        Columns = columns;

        BuildMatrix(minValue, maxValue, randomSeed);
    }

    public int[,] GetMatrix()
    {
        return _matrix.Clone() as int[,];
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
                var elementText = $"{_matrix[i, j]},".PadLeft(3).PadRight(3);
                if (i == j)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(elementText);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Write(elementText);
                }
            }
            Console.Write("]\n");
        }
    }

    public int[] getSnailTrace()
    {
        if (Rows != Columns)
        {
            throw new NotImplementedException("Snail for rectangular matrix is not working \ud83d\ude1e");
        }

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

    private void BuildMatrix(int minValue, int maxValue, int? randomSeed=null)
    {
        var rnd = randomSeed == null ? new Random() : new Random(randomSeed.Value);
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                _matrix[i, j] = rnd.Next(minValue, maxValue);
            }
        }
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