using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA.Models
{
    public class Matrix
    {
        public int rows { get; set;}
        public int cols { get; set; }
        public double[,] mat { get; set; }

        public Matrix(int iRows, int iCols)
        {
            rows = iRows;
            cols = iCols;
            mat = new double[rows, cols];
        }

        public Matrix(Vector[] vectors)
        {
            rows = 2;
            cols = vectors.Count();
            mat = new double[rows,cols];
            for (int i = 0; i < cols; i++)
            {
                mat[0, i] = vectors[i].x;
                mat[1, i] = vectors[i].y;
            }
        }

        public override string ToString()                           
        {
            string s = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++) s += String.Format("{0,5:0.00}", mat[i, j]) + " ";
                s += "\r\n";
            }
            return s;
        }
    }
}
