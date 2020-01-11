using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Triangle
    {
        public Vector4 A { get; set; }
        public Vector4 B { get; set; }
        public Vector4 C { get; set; }
        public List<Edge> GetEdges()
        {
            List<Edge> result = new List<Edge>();

            result.Add(new Edge(A, B));
            result.Add(new Edge(B, C));
            result.Add(new Edge(A, C));

            return result;
        }

        public List<Vector4> GetVertices()
        {
            List<Vector4> result = new List<Vector4>();
            result.Add(A);
            result.Add(B);
            result.Add(C);

            return result;
        }

        public double Z(int x, int y)
        {
            double denominator = (this.B.Y - this.C.Y) * (this.A.X - this.C.X) + (this.C.X - this.B.X) * (this.A.Y - this.C.Y);
            var w0 = ((this.B.Y - this.C.Y) * (x - this.C.X) + (this.C.X - this.B.X) * (y - this.C.Y)) / denominator;
            var w1 = ((this.C.Y - this.A.Y) * (x - this.C.X) + (this.A.X - this.C.X) * (y - this.C.Y)) / denominator;
            var w2 = 1 - w1 - w0;

            return (w0 * this.A.Z + w1 * this.B.Z + w2 * this.C.Z);
        }

        public Color InterpolatedColor(int x, int y, Color a, Color b, Color c)
        {
            double denominator = (this.B.Y - this.C.Y) * (this.A.X - this.C.X) + (this.C.X - this.B.X) * (this.A.Y - this.C.Y);
            var w0 = ((this.B.Y - this.C.Y) * (x - this.C.X) + (this.C.X - this.B.X) * (y - this.C.Y)) / denominator;
            var w1 = ((this.C.Y - this.A.Y) * (x - this.C.X) + (this.A.X - this.C.X) * (y - this.C.Y)) / denominator;
            var w2 = 1 - w1 - w0;

            int R = (int)(w0 * a.R + w1 * b.R + w2 * c.R);
            int G = (int)(w0 * a.G + w1 * b.G + w2 * c.G);
            int B = (int)(w0 * a.B + w1 * b.B + w2 * c.B);
            R = R < 0 ? 0 : R > 255 ? 255 : R;
            G = G < 0 ? 0 : G > 255 ? 255 : G;
            B = B < 0 ? 0 : B > 255 ? 255 : B;
            return Color.FromArgb(R, G, B);
        }

        //public static double Dist(Vector4 v, int x, int y)
        //{
        //    return Math.Sqrt((v.X - x) * (v.X - x) + (v.Y - y) * (v.Y - y));
        //}
    }
}
