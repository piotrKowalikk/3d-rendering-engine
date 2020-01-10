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

        private Matrix4x4 modelMatrix;
        public Matrix4x4 ModelMatrix { get { return modelMatrix; } private set { modelMatrix = value; } }
        private Vector3 position;
        public Vector3 Position { get { return new Vector3() {X=modelMatrix.M14,Y=modelMatrix.M24,Z=modelMatrix.M34 }; } set {} }
        public List<Color> Colors { get; set; }

        private Matrix4x4 translationMatrix;
        private Matrix4x4 translationNegateMatrix;


        public Mesh(string name, Vector4[] vertices, Matrix4x4 vm)
        {
            this.Name = name;
            this.Vertices = vertices;
            this.ModelMatrix = vm;
        }

        public void MoveX(float f)
        {
            // if(6- Math.Abs(modelMatrix.M24) >0.05 && 6 - Math.Abs(modelMatrix.M34) > 0.05)
            modelMatrix.M14 = modelMatrix.M14 + f;
        }
        public void MoveY(float f)
        {
        //    if (Math.Abs(modelMatrix.M24 + f) < 6 - 0.05)
                modelMatrix.M24 = modelMatrix.M24 + f;
        }
        public void MoveZ(float f)
        {
        //    if (Math.Abs(modelMatrix.M24 + f) < 6 - 0.05)
                modelMatrix.M34 = modelMatrix.M34 + f;
        }

        public void RotateX(float angle)
        {
            ModelMatrix = SubstractPosition(new Vector3() { X = Position.X }).RotateX(angle);
            AddPosition(new Vector3() { X = Position.X });
        }

        public void RotateY(float angle)
        {
            ModelMatrix = SubstractPosition(new Vector3() { Y = Position.Y }).RotateY(angle);
            AddPosition(new Vector3() { X = Position.Y });
        }

        public void RotateZ(float angle)
        {
            ModelMatrix = SubstractPosition(new Vector3() { Z = Position.Z }).RotateZ(angle);
            AddPosition(new Vector3() { X = Position.Z });
        }

        public void CalculateTranlationMatrix()
        {
            translationMatrix = Matrix4x4.Identity;
            translationNegateMatrix = Matrix4x4.Identity;
            translationMatrix.M14 = position.X;
            translationMatrix.M24 = position.Y;
            translationMatrix.M34 = position.Z;

            translationNegateMatrix.M14 = -position.X;
            translationNegateMatrix.M24 = -position.Y;
            translationNegateMatrix.M34 = -position.Z;
        }
        public void OutOfBitmap()
        {

            if (ModelMatrix.M24 < -6)
            {
                modelMatrix.M24 += 0.5f;
            }
            else if (ModelMatrix.M34 < -6)
            {
                modelMatrix.M34 += 0.5f;
            }
            else if (ModelMatrix.M24 >6)
            {
                modelMatrix.M24 -= 0.5f;
            }
            else if (ModelMatrix.M34 > 6)
            {
                modelMatrix.M34 -= 0.5f;
            }
            else
            {
                modelMatrix.M14 -= 0.5f;
            }
        }
        public void AddPosition(Vector3 Position)
        {
            Matrix4x4 rsl = ModelMatrix;
            //rsl.M11 += Position.X;
            //rsl.M12 += Position.Y;
            //rsl.M13 += Position.Z;

            //rsl.M21 += Position.X;
            //rsl.M22 += Position.Y;
            //rsl.M23 += Position.Z;

            //rsl.M31 += Position.X;
            //rsl.M32 += Position.Y;
            //rsl.M33 += Position.Z;
            ModelMatrix = rsl;
        }

        public Matrix4x4 SubstractPosition(Vector3 Position)
        {
            Matrix4x4 rsl = ModelMatrix;
            //rsl.M11 -= Position.X;
            //rsl.M12 -= Position.X;
            //rsl.M13 -= Position.Z;

            //rsl.M21 -= Position.X;
            //rsl.M22 -= Position.Y;
            //rsl.M23 -= Position.Z;

            //rsl.M31 -= Position.X;
            //rsl.M32 -= Position.Y;
            //rsl.M33 -= Position.Z;

            return rsl;
        }
    }
}
