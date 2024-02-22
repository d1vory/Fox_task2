using Task2;

Matrix mtr = new Matrix(4,4, randomSeed:7);
mtr.Print();


int[] snail = mtr.getSnailTrace();

Console.Write("[");
foreach (int k in snail)
{
    Console.Write("{0}, ", k);
}
Console.Write("]\n");

//Console.WriteLine($"Trace is {mtr.GetTrace()}");