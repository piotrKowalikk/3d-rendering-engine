using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gk4p1
{
    public partial class Form1 : Form
    {
        double N = 1;
        double R = 100;
        double FOV = 120;
        double a;
        double e;
        static double alfa = 0;
        static double move = 0.1;
        static double move2 = 0.3;
        Color[,] newPhoto;
        double[,] zBufor;
        Color[] colors;

        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            zBufor = new double[Workspace.Width, Workspace.Height];
            for (int i = 0; i < zBufor.GetLength(0); i++)
            {
                for (int j = 0; j < zBufor.GetLength(1); j++)
                {
                    zBufor[i, j] = double.MinValue;
                }
            }

            myTimer.Tick += new EventHandler(TimerEventProcessor);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 100;
            myTimer.Start();
            timer1.Start();
            a = ((double)Workspace.Height) / Workspace.Width;

            colors = new Color[] { Color.Black, Color.Yellow, Color.Green, Color.Red, Color.Blue, Color.Pink, Color.DarkViolet, Color.Silver, Color.Cyan, Color.Crimson };


            Workspace.Invalidate();
        }

        Vector4[] cube = new Vector4[] {
            new Vector4(0, 0, 0, 1),
            new Vector4(1, 0, 0, 1),
            new Vector4(1, 1, 0, 1),
            new Vector4(0, 1, 0, 1),
            new Vector4(0, 0, 1, 1),
            new Vector4(1, 0, 1, 1),
            new Vector4(1, 1, 1, 1),
            new Vector4(0, 1, 1, 1)
        };

        private static void TimerEventProcessor(Object myObject,
                                        EventArgs myEventArgs)
        {

            move += 0.1;
            move2 += (float)(0.1);
            ModelMatrix = new Matrix4x4((float)Math.Cos(move), (-1) * (float)Math.Sin(move), 0, 1 / 2, (float)Math.Sin(move), (float)Math.Cos(move), 0, 4 / 10, 0, 0, 1, 3 / 10, 0, 0, 0, 1);
            ModelMatrix2  //new Matrix4x4((float)Math.Cos(move), (-1) * (float)Math.Sin(move), 0, 1 / 2, (float)Math.Sin(move), (float)Math.Cos(move), 0, 4 / 10, 0, 0, 1, 3 / 10, 0, 0, 0, 1);
                        = new Matrix4x4(1, 0, 0, 1.0F / 2, 0, (float)Math.Cos(move2), (float)Math.Sin(move2), (float)0.9, 0, (float)(-1) * ((float)Math.Sin(move2)), (float)Math.Cos(move2), 0.3F, 0, 0, 0, 1);
            Console.WriteLine(move);
        }

        static Matrix4x4 ModelMatrix = new Matrix4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        static Matrix4x4 ModelMatrix2 = new Matrix4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);
        Matrix4x4 ViewMatrix = new Matrix4x4(0, 1, 0, (float)-0.5, 0, 0, 1, (float)-0.5, 1, 0, 0, -3, 0, 0, 0, 1);

        private Matrix4x4 LookAt()
        {
            double radians = (FOV / 2) * Math.PI / 180;
            e = 1 / Math.Tan(radians);

            float m11 = (float)e;
            float m22 = (float)e / (float)a;
            float m33 = -(float)(R + N) / (float)(R - N);
            float m34 = -(float)(2 * R * N) / (float)(R - N);

            return new Matrix4x4(m11, 0, 0, 0, 0, m22, 0, 0, 0, 0, m33, m34, 0, 0, -1, 0);
        }

        private Vector4 MultiplyByVector(Matrix4x4 matrix, Vector4 vector)
        {
            float a = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W;
            float b = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W;
            float c = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W;
            float d = matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W;

            return new Vector4(a, b, c, d);
        }

        private Vector4 CalculatePPrim(Matrix4x4 Matrixproj, Matrix4x4 ModelMatrix, Vector4 v)
        {
            return MultiplyByVector(Matrixproj, MultiplyByVector(ViewMatrix, MultiplyByVector(ModelMatrix, v)));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            newPhoto = new Color[Workspace.Width, Workspace.Height];
            this.e = 1 / Math.Tan(FOV * Math.PI / 180);

            Matrix4x4 projMatrix = LookAt();

            List<Vector4> Vertices = new List<Vector4>();
            List<Vector4> Vertices2 = new List<Vector4>();

            foreach (var vector in cube)
            {
                Vector4 p = CalculatePPrim(projMatrix, ModelMatrix, vector);
                Vector4 p2 = CalculatePPrim(projMatrix, ModelMatrix2, vector);
                p = VectorNormalize(p);
                Vertices.Add(p);
                p2 = VectorNormalize(p2);
                Vertices2.Add(p2);
            }

            List<(Point, float)> points = new List<(Point, float)>();
            List<(Point, float)> points2 = new List<(Point, float)>();


            e.Graphics.Clear(Color.White);
            Graphics gp = e.Graphics;


            int k = 0;
            foreach (var p in Vertices)
            {
                Point point = AdjustToWindow(p);
                points.Add((point, p.Z));
                gp.FillEllipse(new SolidBrush(colors[k]), point.X - 5, point.Y - 5, 10, 10);
            }
            foreach (var p in Vertices2)
            {

                Point point = AdjustToWindow(p);
                points2.Add((point, p.Z));
                gp.FillEllipse(new SolidBrush(colors[k]), point.X - 5, point.Y - 5, 10, 10);
            }
            //point [0] <- lewy bliski górny,
            //point [1] <- lewy daleki górny,
            //point [2] <- prawy daleki górny,
            //point [3] <- prawy bliski górny,
            //point [4] <- lewy bliski dolny,
            //point [5] <- lewy daleki dolny,
            //point [6] <- prawy daleki doly,
            //point [7] <- prawy bliski dolny,
            //List<Triangle> triangles = new List<Triangle>()
            //{
            //    new Triangle(){A =points[0],B=points[1],C=points[2]  },
            //    new Triangle(){A =points[3],B=points[1],C=points[2]  },//gora
            //    new Triangle(){A =points[0],B=points[1],C=points[5]  },
            //    new Triangle(){A =points[4],B=points[1],C=points[5]  },//lewa
            //    new Triangle(){A =points[3],B=points[2],C=points[7]  },
            //    new Triangle(){A =points[6],B=points[2],C=points[7]  },//prawa
            //    new Triangle(){A =points[3],B=points[0],C=points[7]  },
            //    new Triangle(){A =points[4],B=points[0],C=points[7]  },//przod
            //    new Triangle(){A =points[5],B=points[1],C=points[6]  },
            //    new Triangle(){A =points[2],B=points[1],C=points[6]  }//tyl
            //};

            //List<Brush> br = new List<Brush>() {
            //    Brushes.Green,
            //    Brushes.HotPink,
            //    Brushes.IndianRed,
            //    Brushes.Lavender,
            //    Brushes.LightBlue,
            //    Brushes.LemonChiffon,
            //};
            //int i = 0;
            //foreach (var v in triangles)
            //{
            //    gp.FillPolygon(br[i / 2], new PointF[] { v.A, v.B, v.C });
            //    i++;
            //}
            int i = 0;
            var triangles2 = GetTrainglesFromCube(points2);
            foreach (var triangle in triangles2)
            {
                if ((triangle.A.X > 0 && triangle.A.Y > 0 && triangle.B.X > 0 && triangle.B.Y > 0 && triangle.C.X > 0 && triangle.C.Y > 0) && (triangle.A.X < Workspace.Width && triangle.A.Y < Workspace.Height && triangle.B.X < Workspace.Width && triangle.B.Y < Workspace.Height && triangle.C.X < Workspace.Width && triangle.C.Y < Workspace.Height))
                    FillPolygonNormal(triangle, colors[i /2]);
                i++;
            }

            var triangles1 = GetTrainglesFromCube(points);
            foreach (var triangle in triangles1)
            {
                FillPolygonNormal(triangle, colors[i /2]);
                i++;
            }

            using (Bitmap processedBitmap = new Bitmap(Workspace.Width, Workspace.Height))
            {
                unsafe
                {
                    BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

                    int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = bitmapData.Width * bytesPerPixel;
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                    Parallel.For(0, heightInPixels, y =>
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            currentLine[x] = newPhoto[x / 4, y].B;
                            currentLine[x + 1] = newPhoto[x / 4, y].G;
                            currentLine[x + 2] = newPhoto[x / 4, y].R;
                            currentLine[x + 3] = newPhoto[x / 4, y].A;
                        }
                    });
                    processedBitmap.UnlockBits(bitmapData);
                }

                e.Graphics.DrawImage(processedBitmap, 0, 0);
            }

            //gp.DrawLine(new Pen(Brushes.Black), points2[0], points2[1]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[0], points2[3]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[0], points2[4]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[1], points2[2]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[1], points2[5]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[2], points2[3]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[2], points2[6]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[3], points2[7]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[4], points2[5]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[4], points2[7]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[6], points2[5]);
            //gp.DrawLine(new Pen(Brushes.Black), points2[6], points2[7]);

            ////na trojkatne sciany                                
            //gp.DrawLine(new Pen(Brushes.Black), points2[0], points2[2]);//trojkat gorna
            //gp.DrawLine(new Pen(Brushes.Black), points2[0], points2[5]);//trojkat lewa
            //gp.DrawLine(new Pen(Brushes.Black), points2[0], points2[7]);//trojkat bliska
            //gp.DrawLine(new Pen(Brushes.Black), points2[2], points2[5]);//trojkat daleka
            //gp.DrawLine(new Pen(Brushes.Black), points2[7], points2[2]);//trojkat prawa
            //gp.DrawLine(new Pen(Brushes.Black), points2[4], points2[6]);//trojkat dolna


            ////pierwszy
            //gp.DrawLine(new Pen(Brushes.Black), points[0], points[1]);
            //gp.DrawLine(new Pen(Brushes.Black), points[0], points[3]);
            //gp.DrawLine(new Pen(Brushes.Black), points[0], points[4]);
            //gp.DrawLine(new Pen(Brushes.Black), points[1], points[2]);
            //gp.DrawLine(new Pen(Brushes.Black), points[1], points[5]);
            //gp.DrawLine(new Pen(Brushes.Black), points[2], points[3]);
            //gp.DrawLine(new Pen(Brushes.Black), points[2], points[6]);
            //gp.DrawLine(new Pen(Brushes.Black), points[3], points[7]);
            //gp.DrawLine(new Pen(Brushes.Black), points[4], points[5]);
            //gp.DrawLine(new Pen(Brushes.Black), points[4], points[7]);
            //gp.DrawLine(new Pen(Brushes.Black), points[6], points[5]);
            //gp.DrawLine(new Pen(Brushes.Black), points[6], points[7]);

            ////na trojkatne sciany
            //gp.DrawLine(new Pen(Brushes.Black), points[0], points[2]);//trojkat gorna
            //gp.DrawLine(new Pen(Brushes.Black), points[0], points[5]);//trojkat lewa
            //gp.DrawLine(new Pen(Brushes.Black), points[0], points[7]);//trojkat bliska
            //gp.DrawLine(new Pen(Brushes.Black), points[2], points[5]);//trojkat daleka
            //gp.DrawLine(new Pen(Brushes.Black), points[7], points[2]);//trojkat prawa
            //gp.DrawLine(new Pen(Brushes.Black), points[4], points[6]);//trojkat dolna
        }

        private Point AdjustToWindow(Vector4 p)
        {
            return new Point((int)((p.X + 1) * (Workspace.Width / 2)), (int)((p.Y + 1) * (Workspace.Height / 2)));
        }

        private Vector4 VectorNormalize(Vector4 vector)
        {
            return new Vector4(vector.X / vector.W, vector.Y / vector.W, vector.Z / vector.W, vector.W / vector.W);
        }

        private void Workspace_Resize(object sender, EventArgs e)
        {
            a = ((double)Workspace.Height) / Workspace.Width;
            Console.Write("ttata");
            Workspace.Invalidate();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Workspace.Invalidate();
        }

        private void FillPolygonNormal(Triangle t, Color color)
        {
            List<Edge> edges = t.GetEdges();
            List<Edge>[] ET = EdgeBucketSort(edges);
            int edgesCounter = edges.Count;
            int y = 0;
            while (ET[y] == null)
                y++;

            List<(double yMax, double xMin, double m)> AET = new List<(double, double, double)>();

            while (edgesCounter != 0 || AET.Any())
            {
                AET.RemoveAll(x => x.yMax == y);

                if (ET[y] != null)
                {
                    foreach (Edge edge in ET[y])
                    {
                        double mx = ((double)edge.p2.X - (double)edge.p1.X) / ((double)edge.p2.Y - (double)edge.p1.Y);

                        if (edge.p1.Y != edge.p2.Y)
                            AET.Add((edge.p2.Y, edge.p1.X, mx));

                        edgesCounter--;
                    }
                }

                AET.Sort((a, b) => a.xMin.CompareTo(b.xMin));

                for (int i = 0; i < AET.Count; i += 2)
                {
                    for (int j = (int)(AET[i].xMin); j < (int)(AET[i + 1].xMin); j++)
                    {
                        //Color newColor = Color.Red;

                        newPhoto[j, y] = color;
                    }
                }

                y++;

                for (int i = 0; i < AET.Count; i++)
                {
                    AET[i] = (AET[i].yMax, AET[i].xMin + AET[i].m, AET[i].m);
                }
            }
        }

        private List<Edge>[] EdgeBucketSort(List<Edge> edges)
        {
            List<Edge>[] result = new List<Edge>[Workspace.Height];

            foreach (Edge edge in edges)
            {
                int index = edge.p1.Y < edge.p2.Y ? edge.p1.Y : edge.p2.Y;

                if (result[index] == null)
                    result[index] = new List<Edge>();

                result[index].Add(edge);
            }

            return result;
        }


        private List<Triangle> GetTrainglesFromCube(List<(Point, float)> points)
        {
            List<Triangle> triangles = new List<Triangle>()
        {
        new Triangle() { A=points[0].Item1,B= points[1].Item1,C= points[3].Item1,Az=points[0].Item2, Bz=points[1].Item2,Cz= points[3].Item2, },
        new Triangle() { A=points[1].Item1, B=points[2].Item1,C= points[3].Item1,Az=points[1].Item2, Bz=points[2].Item2,Cz= points[3].Item2,},
        new Triangle() { A=points[2].Item1, B=points[3].Item1,C= points[6].Item1,Az=points[2].Item2, Bz=points[3].Item2,Cz= points[6].Item2,},
        new Triangle() { A=points[3].Item1, B=points[6].Item1,C= points[7].Item1,Az=points[3].Item2, Bz=points[6].Item2,Cz= points[7].Item2,},
        new Triangle() { A=points[4].Item1, B=points[6].Item1,C= points[7].Item1,Az=points[4].Item2, Bz=points[6].Item2,Cz= points[7].Item2,},
        new Triangle() { A=points[4].Item1, B=points[5].Item1,C= points[6].Item1,Az=points[4].Item2, Bz=points[5].Item2,Cz= points[6].Item2,},
        new Triangle() { A=points[0].Item1, B=points[1].Item1,C= points[4].Item1,Az=points[0].Item2, Bz=points[1].Item2,Cz= points[4].Item2,},
        new Triangle() { A=points[1].Item1, B=points[4].Item1,C= points[5].Item1,Az=points[1].Item2, Bz=points[4].Item2,Cz= points[5].Item2,},
        new Triangle() { A=points[3].Item1, B=points[4].Item1,C= points[7].Item1,Az=points[3].Item2, Bz=points[4].Item2,Cz= points[7].Item2,},
        new Triangle() { A=points[0].Item1, B=points[3].Item1,C= points[4].Item1,Az=points[0].Item2, Bz=points[3].Item2,Cz= points[4].Item2,}
};
            //triangles = triangles.Where(x => x.p1.X > 0 && x.p1.Y > 0 && x.p2.X > 0 && x.p2.Y > 0 && x.p3.X > 0 && x.p3.Y > 0).ToList();
            //triangles = triangles.Where(x => x.p1.X < Workspace.Width && x.p1.Y < Workspace.Height && x.p2.X < Workspace.Width && x.p2.Y < Workspace.Height && x.p3.X < Workspace.Width && x.p3.Y < Workspace.Height).ToList();

            return triangles;
        }

        private void Workspace_Click(object sender, EventArgs e)
        {

        }
    }
}
