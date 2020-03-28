using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // двете входни матрици
            var matrix1 = new double[,] { { 1, 3 }, { 5, 7 } };
            var matrix2 = new double[,] { { 4, 2 }, { 1, 5 } };

            // изпълняваме операция върху тях
            var result = multiplyMatrix(matrix1, matrix2);

            // извеждам резултатната матрица
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        static double[,] multiplyMatrix(double[,] matrix1, double[,] matrix2)
        {
            if (matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                throw new Exception("Matrix sizes do not match!");
            }

            var matrix1RowCount = matrix1.GetLength(1);
            var resultMatrix = new double[matrix1.GetLength(0), matrix2.GetLength(1)];
            for (int cols = 0; cols < resultMatrix.GetLength(0); cols++)
                for (int rows = 0; rows < resultMatrix.GetLength(1); rows++)
                    for (int i = 0; i < matrix1RowCount; i++)
                        resultMatrix[cols, rows] += matrix1[cols, i] * matrix2[i, rows];
            return resultMatrix;
        }
    }
}