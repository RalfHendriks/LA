using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Models
{
    public class Matrix
    {
        private readonly double[,] _matrix;

        public int Height { get { return _matrix.GetLength(0); } }
        public int Width { get { return _matrix.GetLength(1); } }

        public Matrix(int dim1, int dim2)
        {
            _matrix = new double[dim1, dim2];
        }

        public Matrix(Vector[] vectors)
        {
            int objectCat = vectors[0][3] == 0 ? 3 : 4;
            _matrix = new double[objectCat,vectors.Length];
            for (int i = 0; i < vectors.Length; i++)
            {
                for (int j = 0; j < objectCat; j++)
                {
                    double val = vectors[i][j];
                    try
                    {
                        _matrix[j, i] = val;
                    }
                    catch (Exception e)
                    {
                        var exception = e;
                        throw;
                    }

                }
            }
        }

        public double this[int x, int y]
        {
            get { return _matrix[x, y]; }
            set { _matrix[x, y] = value; }
        }

        public Vector this[int row]
        {
            get { return new Vector(_matrix[row, 0], _matrix[row, 1], 1); }
        }

        public static Matrix Multiply(Matrix m1, Matrix m2)
        {
            if(m1.Width == m2.Height)
            {
                Matrix resultMatrix = new Matrix(m1.Height, m2.Width);
                for (int i = 0; i < resultMatrix.Height; i++)
                {
                    for (int j = 0; j < resultMatrix.Width; j++)
                    {
                        for (int k = 0; k < m1.Width; k++)
                        {
                            resultMatrix[i, j] += m1[i, k] * m2[k, j];
                        }
                    }
                }
                return resultMatrix;
            }
            return null;
        }
        private static Matrix CalculateRotationMatrix(double degrees, string axis)
        {
            double angleInRadians = degrees * (Math.PI / 180);
            double cos = Math.Cos(angleInRadians);
            double sin = Math.Sin(angleInRadians);
            // Select rotation matrix based on rotation axis
            switch (axis)
            {
                case "X":
                    return new Matrix(new Vector[] { new Vector(1, 0, 0), new Vector(0, cos, sin), new Vector(0, (-1 * sin), cos) });
                case "Y":
                    return new Matrix(new Vector[] { new Vector(cos, 0, sin), new Vector(0, 1, 0), new Vector((-1 * sin), 0, cos) });
                case "Z":
                default:
                    return new Matrix(new Vector[] { new Vector(cos, sin, 0), new Vector((-1 * sin), cos, 0), new Vector(0, 0, 1) });
            }
        }


        public static Matrix Rotate2D(Matrix matrix, double degrees, double[] point)
        {
            Matrix m = Translate(new double[] { -1* point[0], -1* point[1] }, matrix);
            Matrix mRotation = CalculateRotationMatrix(degrees,null);
            m = Matrix.Multiply(mRotation, m);
            m = Translate(new double[] { point[0], point[1] }, m);
            return m;
        }

        public static Matrix Rotate2D(Matrix matrix,double degrees)
        {
            Matrix m = CalculateRotationMatrix(degrees,null);
            return Matrix.Multiply(m,matrix);
        }

        public static Matrix Rotate3D(Matrix matrix, double degrees)
        {
            return null;
        }

        public static bool CalculateDeterminant(Matrix matrix)
        {

            return false;
        }

        public static Matrix Inverse(Matrix matrix)
        {

            return null;
        }

        public static Matrix Scale(double[] scale,Matrix matrix)
        {
            Vector[] v = scale.Length == 2 ? 
                new Vector[] { new Vector(scale[0], 0, 0), new Vector(0, scale[1], 0), new Vector(0, 0, 1) } : 
                new Vector[] { new Vector(scale[0], 0, 0, 0), new Vector(0, scale[1], 0, 0), new Vector(0, 0, scale[2], 0), new Vector(0, 0, 0, 1) };
            Matrix scaleMatrix = new Matrix(v);
            return Matrix.Multiply(scaleMatrix, matrix);
        }

        public static Matrix Translate(double[] rotationPoint, Matrix m)
        {
            Vector[] v = rotationPoint.Length == 2 ? 
                new Vector[] {new Vector(1,0,0), new Vector(0,1,0), new Vector(rotationPoint[0], rotationPoint[1], 1) } :
                 new Vector[] { new Vector(1, 0, 0, 0), new Vector(0, 1, 0, 0), new Vector(0, 0, 1, 0), new Vector(rotationPoint[0], rotationPoint[1], rotationPoint[2], 1) }; ;
            Matrix t = new Matrix(v);
            return Matrix.Multiply(t,m);
        }

        /*
        public override string ToString()                           
        {
            string s = "";
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++) s += String.Format("{0,5:0.00}", _matrix[i, j]) + " ";
                s += "\r\n";
            }
            return s;
        }*/
    }
}
