namespace ConsoleApplication1
{
    using System;

    internal class MultiplyMatricesMain
    {
        private static void Main(string[] args)
        {
            var firstMatrix = new double[,] { { 1, 3 }, { 5, 7 } };
            var secondMatrix = new double[,] { { 4, 2 }, { 1, 5 } };
            var multiplied = MultipyMatriises(firstMatrix, secondMatrix);

            for (var row = 0; row < multiplied.GetLength(0); row++)
            {
                for (var col = 0; col < multiplied.GetLength(1); col++)
                {
                    Console.Write(multiplied[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static double[,] MultipyMatriises(double[,] firstMatrix, double[,] secondMatrix)
        {
            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
            {
                throw new ArgumentException(
                    "Number of columns of the first Matrix should be equal to the rows of the second Matrix!");
            }

            var cols = firstMatrix.GetLength(1);
            var multipliedMatrix = new double[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
            for (var row = 0; row < multipliedMatrix.GetLength(0); row++)
            {
                for (var col = 0; col < multipliedMatrix.GetLength(1); col++)
                {
                    for (var i = 0; i < cols; i++)
                    {
                        multipliedMatrix[row, col] += firstMatrix[row, i] * secondMatrix[i, col];
                    }
                }
            }

            return multipliedMatrix;
        }
    }
}