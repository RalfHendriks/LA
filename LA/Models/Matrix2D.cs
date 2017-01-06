using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Models
{
    public class Matrix2D
    {
        private int _rows;
        private int _columns;
        public double[,] Matrix;

        public int GetRows() { return _rows; }
        public int GetColumns() { return _columns; }

        public Matrix2D(int rowCount, int columnCount)
        {
            _rows = rowCount;
            _columns = columnCount;
            Matrix = new double[_rows, _columns];
        }

        public Matrix2D(Vector[] vectors)
        {
            _rows = 2;
            _columns = vectors.Count();
            Matrix = new double[_rows, _columns];
            for (int i = 0; i < _columns; i++)
            {
                Matrix[0, i] = vectors[i].x;
                Matrix[1, i] = vectors[i].y;
            }
        }

        public void Scale(double xFactor, double yFactor)
        {
            for (int i = 0; i < _columns; i++)
            {
                Matrix[0, i] = (Matrix[0, i] * xFactor);
                Matrix[1, i] = (Matrix[1, i] * yFactor);
            }
        }

        public void Rotate(double degrees)
        {
            Matrix2D rotatedObject = new Matrix2D(_rows, _columns);
            double angleInRadians = degrees * (Math.PI / 180);
            double cos = Math.Cos(angleInRadians);
            double sin = Math.Sin(angleInRadians);

            for (int i = 0; i < _columns; i++)
            {
                rotatedObject.Matrix[0, i] = Matrix[0, i] * cos - Matrix[1, i] * sin;
                rotatedObject.Matrix[1, i] = Matrix[0, i] * sin + Matrix[1, i] * cos;
            }
            Matrix = rotatedObject.Matrix;
        }

        public void Rotate(double degrees, System.Windows.Point origin)
        {
            Matrix2D rotatedObject = new Matrix2D(_rows, _columns);
            double angleInRadians = degrees * (Math.PI / 180);
            double cos = Math.Cos(angleInRadians);
            double sin = Math.Sin(angleInRadians);

            for (int i = 0; i < _columns; i++)
            {
                rotatedObject.Matrix[0, i] = Matrix[0, i] - (Matrix[0,i] - origin.X);
                rotatedObject.Matrix[1, i] = Matrix[1, i] - (Matrix[1, i] - origin.Y);

                rotatedObject.Matrix[0, i] = rotatedObject.Matrix[0, i] * cos - rotatedObject.Matrix[1, i] * sin;
                rotatedObject.Matrix[1, i] = rotatedObject.Matrix[0, i] * sin + rotatedObject.Matrix[1, i] * cos;

                rotatedObject.Matrix[0, i] = rotatedObject.Matrix[0, i] + (Matrix[0, i] - origin.X);
                rotatedObject.Matrix[1, i] = rotatedObject.Matrix[1, i] + (Matrix[1, i] - origin.Y);
            }
            Matrix = rotatedObject.Matrix;
        }

        private double CalculateXRotation(double degrees ,double x, double y)
        {
            double angleInRadians = degrees * (Math.PI / 180);
            double cos = Math.Cos(angleInRadians);
            double sin = Math.Sin(angleInRadians);
            double newCoord = (cos * x) + (sin * -1 * y);
            return newCoord;
        }

        private double CalculateYRotation(double degrees, double x, double y)
        {
            double angleInRadians = degrees * (Math.PI / 180);
            double cos = Math.Cos(angleInRadians);
            double sin = Math.Sin(angleInRadians);
            double newCoord = (sin * x) + (cos * y);
            return newCoord;
        }

        public void Transalte(double transalteValue)
        {
            for (int i = 0; i < _columns; i++)
            {
                Matrix[0, i] = (Matrix[0, i] + transalteValue);
                Matrix[1, i] = (Matrix[1, i] + transalteValue);
            }
        }
    }
}
