using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class Matrix
    {
        [TestCategory("Matrix")]
        [TestMethod]
        public void MatrixMultiply()
        {
            LA.Models.Matrix matrix1 = new LA.Models.Matrix(2, 2);
            matrix1[0, 0] = 4;
            matrix1[0, 1] = 1;
            matrix1[1, 0] = 2;
            matrix1[1, 1] = 3;

            LA.Models.Matrix matrix2 = new LA.Models.Matrix(2, 3);
            matrix2[0, 0] = 3;
            matrix2[0, 1] = 0;
            matrix2[0, 2] = 4;
            matrix2[1, 0] = 2;
            matrix2[1, 1] = 5;
            matrix2[1, 2] = 1;



            LA.Models.Matrix x = LA.Models.Matrix.Multiply(matrix1, matrix2);
            Assert.AreEqual(14, x[0, 0]);
            Assert.AreEqual(5 , x[0, 1]);
            Assert.AreEqual(17, x[0, 2]);
            Assert.AreEqual(12, x[1, 0]);
            Assert.AreEqual(15, x[1, 1]);
            Assert.AreEqual(11, x[1, 2]);
        }

        [TestCategory("Matrix")]
        [TestMethod]
        public void MatrixMultiplyRandom()
        {
            Random r = new Random();
            LA.Models.Matrix m1 = new LA.Models.Matrix(40, 30);
            LA.Models.Matrix m2 = new LA.Models.Matrix(30, 20);

            for (int i = 0; i < m1.Height; i++)
            {
                for (int j = 0; j < m1.Width; j++)
                {
                    m1[i, j] = r.Next(-100, 100);
                }
            }

            for (int i = 0; i < m2.Height; i++)
            {
                for (int j = 0; j < m2.Width; j++)
                {
                    m2[i, j] = r.Next(-100, 100);
                }
            }
            LA.Models.Matrix x = LA.Models.Matrix.Multiply(m1, m2);
            double total = 0;

            //calculate total of matrix m1 and m2 
            for (int i = 0; i < m1.Width; i++)
            {
                //get the current column from matrix m1 and the current row from m2 and multiply
                total += m1[0, i] * m2[i, 0];
            }
            Assert.AreEqual(x[0, 0], total);
        }

        [TestCategory("Matrix")]
        [TestMethod]
        public void MatrixTranslation()
        {
            /*
            define custom matrix 
                [10,14,8]
                [12,6,10]
                [1 ,1 ,1] 
            */
            LA.Models.Matrix matrix = new LA.Models.Matrix(3, 3);
            matrix[0, 0] = 10;
            matrix[0, 1] = 14;
            matrix[0, 2] = 8;
            matrix[1, 0] = 12;
            matrix[1, 1] = 6;
            matrix[1, 2] = 10;
            matrix[2, 0] = 1;
            matrix[2, 1] = 1;
            matrix[2, 2] = 1;

            matrix = LA.Models.Matrix.Translate(new double[] { -6, 3 },matrix);
            Assert.AreEqual(4, matrix[0, 0]);
            Assert.AreEqual(8, matrix[0, 1]);
            Assert.AreEqual(2, matrix[0, 2]);
            Assert.AreEqual(15, matrix[1, 0]);
            Assert.AreEqual(9, matrix[1, 1]);
            Assert.AreEqual(13, matrix[1, 2]);
        }
    }
}
