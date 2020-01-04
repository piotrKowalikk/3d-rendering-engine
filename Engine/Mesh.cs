using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Mesh
    {
        public string Name { get; private set; }
        public Vector4[] Vertices { get; private set; }
        public List<Triangle> Triangles { get; set; }
        public Matrix4x4 ModelMatrix { get; private set; }
        public List<Color> Colors { get; set; }

        public Mesh(string name, Vector4[] vertices, Matrix4x4 vm)
        {
            this.Name = name;
            this.Vertices = vertices;
            this.ModelMatrix = vm;
        }

        public void RotateX(float angle )
        {
            ModelMatrix = ModelMatrix.RotateX(angle);
        }

        public void RotateY(float angle)
        {
            ModelMatrix = ModelMatrix.RotateY(angle);
        }

        public void RotateZ(float angle)
        {
            ModelMatrix = ModelMatrix.RotateZ(angle);
        }

    }
}
