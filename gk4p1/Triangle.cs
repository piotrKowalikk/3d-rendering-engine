using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gk4p1
{
    class Triangle
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public float Az { get; set; }
        public float Bz { get; set; }
        public float Cz { get; set; }
        public List<Edge> GetEdges()
        {
            List<Edge> result = new List<Edge>();

            result.Add(new Edge(A, B));
            result.Add(new Edge(A, C));
            result.Add(new Edge(B, C));

            return result;
        }

        public List<Point> GetVertex()
        {
            List<Point> result = new List<Point>();

            result.Add(A);
            result.Add(B);
            result.Add(C);

            return result;
        }
    }
}
