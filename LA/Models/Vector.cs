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
        public double z { get; set; }
        public double w { get; set; }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public double this[int x]
        {
            get
            {
                double val = 0.0;
                if(!(x > 3 || x < 0))
                {
                    var prop = this.GetType().GetProperties().ElementAt(x);
                    val = (double)prop.GetValue(this, null);
                }
                return val;
            }
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

        public static Vector CalculateCrossProduct(Vector vector1, Vector vector2)
        {
            double x = vector1.y * vector2.z - vector1.z * vector2.y;
            double y = vector1.z * vector2.x - vector1.x * vector2.z;
            double z = vector1.x * vector2.y - vector1.y * vector2.x;
            return new Vector(x,y,z);
        }

        public static Vector SumVector(Vector v1, Vector v2)
        {
            return new Vector((v1.x + v2.x), (v1.y + v2.y), (v1.z + v2.z));
        }

        public static Vector SubstractVector(Vector v1, Vector v2)
        {
            return new Vector((v1.x - v2.x),(v1.y - v2.y),(v1.z - v2.z));
        }
    }
}
