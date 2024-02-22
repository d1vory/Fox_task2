using Task2;

Matrix mtr = new Matrix(5,5, randomSeed:1);



mtr.Print();

// int[,]? kek = mtr.GetMatrix();
// if (kek != null) kek[0, 0] = 228;
//
// mtr.Print();


 int[] snail = mtr.getSnailTrace();

 Console.Write("[");
 foreach (int k in snail)
 {
     Console.Write("{0}, ", k);
 }
 Console.Write("]\n");

//Console.WriteLine($"Trace is {mtr.GetTrace()}");