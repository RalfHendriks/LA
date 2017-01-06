using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LA.Models;
using System.Windows.Media.Media3D;

namespace LA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Main m;
        private List<Line> lines = new List<Line>();
        private const int WIDTH = 1200;
        private const int HEIGHT = 800;
        private bool _mouseDown = false;
        private Point mLastPos;
        private GeometryModel3D mGeometry;

        public MainWindow()
        {
            InitializeComponent();
            Line l = new Line();
            l.X1 = WIDTH / 2;
            l.Y1 = HEIGHT / 2;
            l.Stroke = System.Windows.Media.Brushes.Red;
            c.Children.Add(l);
            m = new Main(this);

            // Define 3D mesh object
            MeshGeometry3D mesh = new MeshGeometry3D();

            mesh.Positions.Add(new Point3D(-1, -1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, 1));
            mesh.Positions.Add(new Point3D(1, -1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, 1));
            mesh.Positions.Add(new Point3D(1, 1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, 1));
            mesh.Positions.Add(new Point3D(-1, 1, 1));
            //mesh.Normals.Add(new Vector3D(0, 0, 1));

            mesh.Positions.Add(new Point3D(-1, -1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(1, -1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(1, 1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));
            mesh.Positions.Add(new Point3D(-1, 1, -1));
            //mesh.Normals.Add(new Vector3D(0, 0, -1));

            // Front face
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(0);

            // Back face
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(6);

            // Right face
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(2);

            // Top face
            mesh.TriangleIndices.Add(2);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(6);
            mesh.TriangleIndices.Add(7);

            // Bottom face
            mesh.TriangleIndices.Add(5);
            mesh.TriangleIndices.Add(1);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(5);

            // Right face
            mesh.TriangleIndices.Add(4);
            mesh.TriangleIndices.Add(0);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(3);
            mesh.TriangleIndices.Add(7);
            mesh.TriangleIndices.Add(4);

            // Geometry creation
            mGeometry = new GeometryModel3D(mesh, new DiffuseMaterial(Brushes.YellowGreen));
            mGeometry.Transform = new Transform3DGroup();
            group.Children.Add(mGeometry);
        }

        public Point ConvertToCoord(double[] p)
        {
            //width  == 600 == x == 0
            //height == 400 == y == 0


            return new Point(0,0);
        }

        private double ConvertToX(double x)
        {
            return (WIDTH / 2) + x;
        }

        private double ConvertToY(double y)
        {
            return (HEIGHT /2 ) + y;
        }

        public void Draw2D(Matrix2D matrix)
        {
            foreach (Line item in lines)
            {
                c.Children.Remove(item);
            }
            lines.Clear();
            for (int i = 0; i < matrix.GetColumns(); i++)
            {
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                myLine.X1 = matrix.Matrix[0,i];
                myLine.X2 = i == (matrix.GetColumns() -1) ? matrix.Matrix[0, 0] : matrix.Matrix[0, i + 1];
                myLine.Y1 = matrix.Matrix[1, i];
                myLine.Y2 = i == (matrix.GetColumns() - 1) ? matrix.Matrix[1, 0] : matrix.Matrix[1, i + 1];
                lines.Add(myLine);
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
                c.Children.Add(myLine);
            }
        }

        public void Draw(LA.Models.Matrix matrix)
        {
            foreach (Line item in lines)
            {
                c.Children.Remove(item);
            }
            lines.Clear();
            for (int i = 0; i < matrix.Width; i++)
            {
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
                myLine.X1 = ConvertToX(matrix[0, i]);
                myLine.X2 = i == (matrix.Width - 1) ? ConvertToX(matrix[0, 0]) : ConvertToX(matrix[0, i + 1]);
                myLine.Y1 = ConvertToY(matrix[1, i]);
                myLine.Y2 = i == (matrix.Width - 1) ? ConvertToY(matrix[1, 0]) : ConvertToY(matrix[1, i + 1]);
                lines.Add(myLine);
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;
                myLine.StrokeThickness = 2;
                c.Children.Add(myLine);
            }
        }

        public void DrawVector(Models.Vector v)
        {
            Line line = new Line();
            Thickness thickness = new Thickness(101, -11, 362, 250);
            line.Margin = thickness;
            line.Visibility = System.Windows.Visibility.Visible;
            line.StrokeThickness = 4;
            line.Stroke = System.Windows.Media.Brushes.Black;
            double startcoord = 60;
            double lenght = v.GetVectorEnd();
            line.X1 = startcoord;
            line.X2 = Math.Sqrt(v.x * v.x + startcoord * startcoord);
            line.Y1 = startcoord;
            line.Y2 = Math.Sqrt(v.y * v.y + startcoord * startcoord);
            c.Children.Add(line);
            c.UpdateLayout();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            double x = (lines[0].X1 + lines[1].X1 + lines[2].X1) / 3;
            double y = (lines[0].Y1 + lines[1].Y1 + lines[2].Y1) / 3;

            
            switch (e.Key)
            {
                case Key.Left:
                case Key.A:
                    m.MoveLeft();
                    break;
                case Key.Up:
                case Key.W:
                    m.MoveUp();
                    break;
                case Key.Right:
                case Key.D:
                    m.MoveRight();
                    break;
                case Key.Down:
                case Key.S:
                    m.MoveDown();
                    break;
                case Key.E:
                    if (c.Visibility != Visibility.Hidden)
                        m.RotateRight(new Point(x, y));
                    else
                        m.RotateScreenLeft();
                    break;
                case Key.Q:
                    if (c.Visibility != Visibility.Hidden)
                        m.RotateLeft(new Point(x, y));
                    else
                        m.RotateScreenRight();
                    break;
                case Key.Space:
                    break;
                default:
                    break;
            }
        }

        private void viewPort_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            m.HandleZoom(e.Delta);
        }

        private void viewPort_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            _mouseDown = true;
            Point pos = Mouse.GetPosition(viewPort);
            mLastPos = new Point(pos.X - viewPort.ActualWidth / 2, viewPort.ActualHeight / 2 - pos.Y);
        }

        private void viewPort_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                Point pos = Mouse.GetPosition(viewPort);
                Point actualPos = new Point(pos.X - viewPort.ActualWidth / 2, viewPort.ActualHeight / 2 - pos.Y);
                double dx = actualPos.X - mLastPos.X, dy = actualPos.Y - mLastPos.Y;

                double mouseAngle = 0;
                if (dx != 0 && dy != 0)
                {
                    mouseAngle = Math.Asin(Math.Abs(dy) / Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
                    if (dx < 0 && dy > 0) mouseAngle += Math.PI / 2;
                    else if (dx < 0 && dy < 0) mouseAngle += Math.PI;
                    else if (dx > 0 && dy < 0) mouseAngle += Math.PI * 1.5;
                }
                else if (dx == 0 && dy != 0) mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
                else if (dx != 0 && dy == 0) mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;

                double axisAngle = mouseAngle + Math.PI / 2;

                Vector3D axis = new Vector3D(Math.Cos(axisAngle) * 4, Math.Sin(axisAngle) * 4, 0);

                double rotation = 0.01 * Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

                Transform3DGroup group = mGeometry.Transform as Transform3DGroup;
                QuaternionRotation3D r = new QuaternionRotation3D(new Quaternion(axis, rotation * 180 / Math.PI));
                group.Children.Add(new RotateTransform3D(r));

                mLastPos = actualPos;
            }
        }

        private void viewPort_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _mouseDown = false;
        }
    }
}
