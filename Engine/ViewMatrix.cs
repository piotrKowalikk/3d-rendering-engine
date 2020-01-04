using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct ViewMatrix
    {
        private Camera camera;
        public Camera Camera
        {
            get { return camera; }
            set
            {
                camera = value;
                CalculateMatrix();
            }
        }

        public Matrix4x4 Matrix { get; private set; }
        private void CalculateMatrix()
        {
           Matrix4x4 MatrixOdw = new Matrix4x4()
            {
                //axis
                M11 = camera.XAxisVersor.X,
                M12 = camera.YAxisVersor.X,
                M13 = camera.ZAxisVersor.X,
                M21 = camera.XAxisVersor.Y,
                M22 = camera.YAxisVersor.Y,
                M23 = camera.ZAxisVersor.Y,
                M31 = camera.XAxisVersor.Z,
                M32 = camera.YAxisVersor.Z,
                M33 = camera.ZAxisVersor.Z,
                //camera
                M14 = camera.Position.X,
                M24 = camera.Position.Y,
                M34 = camera.Position.Z,
                //dont know
                M44= 1
            };

            Matrix4x4.Invert(MatrixOdw, out Matrix4x4 rsl);
            Matrix = rsl;
        }
    }
}
