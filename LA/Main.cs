using LA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LA
{
    public class Main
    {
        private List<Vector> vectorList = new List<Vector>();
        private MainWindow c;

        public Main(MainWindow cMain)
        {
            this.c = cMain;
            Vector[] t = new Vector[] { new Vector(0, 1 ), new Vector(2, 3 ), new Vector(-2, 5 ), new Vector(3, 1 )};
            Matrix m = new Matrix(t);
            Matrix ma = new Matrix(8, 10);
            string ls = ma.ToString();
            string s = m.ToString();
        }

        public void AddVector(double x, double y)
        {
            Vector v = new Vector(x, y);
            //vectorList.Add(v);
            c.DrawVector(v);
        }
    }
}
