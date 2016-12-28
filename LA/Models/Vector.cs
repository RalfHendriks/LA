using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LA.Models
{
    public class Vector
    {
        public double x  { get; set; }
        public double y { get; set; }

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double GetVectorEnd()
        {
            return Math.Sqrt((x * x) + (y * y));
        }

        public void IncreaseByFactor(double f)
        {
            x = x * f;
            y = y * f;
        }

        public Vector SumVector()
        {
            return null;
        }
    }
}
