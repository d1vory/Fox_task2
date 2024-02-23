using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace TestTask2
{
    [TestClass]
    public class UnitTest1
    {
        const int RandomSeed = 1;
        Matrix squareMatrix;
        Matrix rectMatrix1;
        Matrix rectMatrix2;

        [TestInitialize]
        public void TestInitialize()
        {
            squareMatrix = new Matrix(5, 5, randomSeed: RandomSeed);
            rectMatrix1 = new Matrix(5, 2, randomSeed: RandomSeed);
            rectMatrix2 = new Matrix(2, 5, randomSeed: RandomSeed);
        }


        [TestMethod]
        public void TestMatrixBuild()
        {
            int[,] preBuildSquareMatrix =
            {
                { 24, 11, 46, 77, 65 },
                { 43, 35, 94, 10, 64, },
                { 2, 24, 32, 98, 68, },
                { 65, 28, 61, 70, 70, },
                { 94, 9, 16, 38, 79, }
            };

            int[,] preBuildRectMatrix1 =
            {
                { 24, 11, },
                { 46, 77, },
                { 65, 43, },
                { 35, 94, },
                { 10, 64, }
            };

            int[,] preBuildRectMatrix2 =
            {
                { 24, 11, 46, 77, 65, },
                { 43, 35, 94, 10, 64, }
            };

            Assert.IsTrue(IsMatricesEqual(squareMatrix.GetMatrix(), preBuildSquareMatrix));
            Assert.IsTrue(IsMatricesEqual(rectMatrix1.GetMatrix(), preBuildRectMatrix1));
            Assert.IsTrue(IsMatricesEqual(rectMatrix2.GetMatrix(), preBuildRectMatrix2));

            Assert.ThrowsException<ArgumentException>(() => new Matrix(-5,-4));
            Assert.ThrowsException<ArgumentException>(() => new Matrix(-5,4));
            Assert.ThrowsException<ArgumentException>(() => new Matrix(5,-4));

            Assert.IsTrue(isMatrixElementsInRange(new Matrix(5,5).GetMatrix(), 0, 100));
            Assert.IsTrue(isMatrixElementsInRange(new Matrix(5,5).GetMatrix(), 0, 100));
            Assert.IsTrue(isMatrixElementsInRange(new Matrix(5,5, 10, 50).GetMatrix(), 10, 50));
            Assert.IsTrue(isMatrixElementsInRange(new Matrix(5,5, -100, -10).GetMatrix(), -100, -10));
        }

        [TestMethod]
        public void TestGetTrace()
        {
            Assert.AreEqual(squareMatrix.GetTrace(), 240);
            Assert.AreEqual(rectMatrix1.GetTrace(), 101);
            Assert.AreEqual(rectMatrix2.GetTrace(), 59);
        }

        [TestMethod]
        public void TestGetSnailTrace()
        {
            int[] expectedSnail =
                { 24, 11, 46, 77, 65, 64, 68, 70, 79, 38, 16, 9, 94, 65, 2, 43, 35, 94, 10, 98, 70, 61, 28, 24, 32 };

            Assert.IsTrue(expectedSnail.SequenceEqual(squareMatrix.getSnailTrace()));
        }




        private bool IsMatricesEqual(int[,] fstArr, int[,] scndArr)
        {
            if (
                fstArr.GetLength(0) != scndArr.GetLength(0) ||
                fstArr.GetLength(1) != scndArr.GetLength(1)
            )
            {
                Console.WriteLine("Dimensions");
                return false;
            }

            for (int i = 0; i < fstArr.GetLength(0); i++)
            {
                for (int j = 0; j < fstArr.GetLength(1); j++)
                {
                    if (fstArr[i, j] != scndArr[i, j])
                    {
                        Console.WriteLine($"elements {fstArr[i, j] }  and {scndArr[i, j]}");
                        return false;
                    }
                }
            }
            
            return true;
        }

        private bool isMatrixElementsInRange(int[,] matrix, int minValue, int maxValue)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int el = matrix[i, j];
                    if ((el < minValue) || (el > maxValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }
}