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
    }
}
