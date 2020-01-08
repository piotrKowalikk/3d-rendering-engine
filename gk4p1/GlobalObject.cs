using Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace gk4p1
{
    public class GlobalObject
    {
        private int width;
        public int Width { get { return width; } set { width = value; ClearBuffer(); } }
        private int height;
        public int Height { get { return height; } set { height= value; ClearBuffer(); } }

        public List<Mesh> Meshes { get; set; } = new List<Mesh>();
        public double[,] ZBuffor { get; private set; }
        private ProjectionMatrix projMatrix;
        public ProjectionMatrix ProjMatrix { get { return projMatrix; } set { projMatrix = value; CalculateProjViewMatrix(); } }
        private ViewMatrix viewMatrix;
        public ViewMatrix ViewMatrix { get { return viewMatrix; } set { viewMatrix = value; CalculateProjViewMatrix(); } }

        private Matrix4x4 ProjViewMatrix { get; set; }

        public GlobalObject()
        {
            ClearBuffer();
        }

        public void ClearBuffer()
        {
            ZBuffor = new double[Width , Height];
            for (int i = 0; i < ZBuffor.GetLength(0); i++)
                for (int j = 0; j < ZBuffor.GetLength(1); j++)
                    ZBuffor[i, j] = double.MaxValue;
        }

        public void CalculateProjViewMatrix()
        {
            ProjViewMatrix = Matrix4x4.Multiply(ProjMatrix.Matrix, ViewMatrix.Matrix);
        }

        //zwraca punkty na bitmapie
        public List<(List<Triangle>,Mesh)> GetViewTraingle()
        {
            List<(List<Triangle>,Mesh)> rsl = new List<(List<Triangle>,Mesh)>();
            for (int i = 0; i < Meshes.Count; i++)
            {
                List<Triangle> meshMapped = new List<Triangle>();
                Matrix4x4 TransformMatrix = Matrix4x4.Multiply(ProjViewMatrix, Meshes[i].ModelMatrix);
                foreach (Triangle t in Meshes[i].Triangles)
                {
                    meshMapped.Add(new Triangle()
                    {
                        A = AdjustToWindow(VectorNormalize(TransformMatrix.Multiply(t.A))),
                        B = AdjustToWindow(VectorNormalize(TransformMatrix.Multiply(t.B))),
                        C = AdjustToWindow(VectorNormalize(TransformMatrix.Multiply(t.C)))
                    });
                }
                rsl.Add((meshMapped,Meshes[i]));
            }
            return rsl;
        }
        private Vector4 AdjustToWindow(Vector4 p)
        {
            return new Vector4((int)((p.X + 1) * (Width / 2)),(int)( (p.Y + 1) * (Height / 2)),( p.Z),( p.W));
        }

        private Vector4 VectorNormalize(Vector4 vector)
        {
            return new Vector4(vector.X / vector.W, vector.Y / vector.W, vector.Z / vector.W, vector.W / vector.W);
        }
    }
}
