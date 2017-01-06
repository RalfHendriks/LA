using LA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace LA
{
    public class Main
    {
        private List<Vector> vectorList = new List<Vector>();
        private PerspectiveCamera myCamera;
        private List<ModelVisual3D> Entities = new List<ModelVisual3D>();
        private MainWindow c;
        private Models.Matrix x;

        private const double SPEEDMULTI = 2.5; 

        public Main(MainWindow cMain)
        {
            this.c = cMain;
            myCamera = new PerspectiveCamera();
            myCamera.Position = new Point3D(0, 0, 10);
            myCamera.LookDirection = new Vector3D(0, 0, -1);
            myCamera.FieldOfView = 40;


            Vector[] t = new Vector[] { new Vector(0, 1 ,3), new Vector(2, 3 ,-2), new Vector(-2, 5 ,-6), new Vector(3, 1 ,0)};
            Vector[] ra = new Vector[] { new Vector(400, 350, 1), new Vector(450, 550, 1), new Vector(450, 300, 1) };
            Vector[] cube3D = new Vector[] { new Vector(100, 125,50, 1), new Vector(200, 80,110, 1), new Vector(300, 70,70, 1), new Vector(50, 10,20, 1), new Vector(110, 70,20, 1) };
            Vector[] cube2D = new Vector[] { new Vector(100, 125, 1), new Vector(200, 80, 1), new Vector(300, 70, 1), new Vector(50, 10, 1), new Vector(110, 70, 1) };
            c.viewPort.Camera = myCamera;
            x = new Models.Matrix(cube2D);
            x = Models.Matrix.Scale(new double[] { 2, 1.2 }, x);
            c.Draw(x);
        }

        /*public void AddVector(double x, double y, double z)
        {
            Vector v = new Vector(x, y,z);
            //vectorList.Add(v);
            c.DrawVector(v);
        }*/

        public void RotateScreenRight()
        {
            myCamera.LookDirection = new Vector3D(myCamera.LookDirection.X + 5, myCamera.LookDirection.Y, myCamera.LookDirection.Z);
        }

        public void RotateScreenLeft()
        {
            myCamera.LookDirection = new Vector3D(myCamera.LookDirection.X -5, myCamera.LookDirection.Y, myCamera.LookDirection.Z);
        }


        public void HandleZoom(int Delta)
        {
            myCamera.Position = new Point3D(myCamera.Position.X, myCamera.Position.Y, myCamera.Position.Z - Delta / 250D);
        }


        public void RotateLeft(System.Windows.Point pointToRotate)
        {
            double coordx = (x[0, 0] + x[0, 1] + x[0, 2]) / 3;
            double coordy = (x[1, 0] + x[1, 1] + x[1, 2]) / 3;
            x = Models.Matrix.Rotate2D(x, (-1 * SPEEDMULTI), new double[] { coordx,coordy});
            c.Draw(x);
        }

        public void RotateRight(System.Windows.Point pointToRotate)
        {
            double coordx = (x[0, 0] + x[0, 1] + x[0, 2]) / 3;
            double coordy = (x[1, 0] + x[1, 1] + x[1, 2]) / 3;
            x = Models.Matrix.Rotate2D(x, SPEEDMULTI, new double[] { coordx, coordy });
            c.Draw(x);
        }

        public void MoveUp()
        {
            x = Models.Matrix.Translate(new double[] { 0, (-1 * SPEEDMULTI) }, x);
            c.Draw(x);
        }

        public void MoveDown()
        {
            x = Models.Matrix.Translate(new double[] { 0, SPEEDMULTI }, x);
            c.Draw(x);
        }

        public void MoveLeft()
        {
            x = Models.Matrix.Translate(new double[] { (-1 * SPEEDMULTI), 0 }, x);
            c.Draw(x);
        }

        public void MoveRight()
        {
            x = Models.Matrix.Translate(new double[] { SPEEDMULTI, 0 }, x);
            c.Draw(x);
        }
    }
}
