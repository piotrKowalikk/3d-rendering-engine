using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    static public class MatrixExtension
    {
        static public Matrix4x4 RotateX(this Matrix4x4 m, float angleRad)
        {
            Matrix4x4 RX = new Matrix4x4()
            {
                M11 = 1,
                M12 = 0,
                M13 = 0,
                M14 = 0,

                M21 = 0,
                M22 = (float)Math.Cos(angleRad),
                M23 = -(float)Math.Sin(angleRad),
                M24 = 0,

                M31 = 0,
                M32 = (float)Math.Sin(angleRad),
                M33 = (float)Math.Cos(angleRad),
                M34 = 0,

                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1
            };
            return Matrix4x4.Multiply(m, RX);
        }
        static public Matrix4x4 RotateY(this Matrix4x4 m, float angleRad)
        {
            Matrix4x4 RX = new Matrix4x4()
            {
                M11 = (float)Math.Cos(angleRad),
                M12 = 0,
                M13 = (float)Math.Sin(angleRad),
                M14 = 0,

                M21 = 0,
                M22 = 1,
                M23 = 0,
                M24 = 0,

                M31 = -(float)Math.Sin(angleRad),
                M32 = 0,
                M33 = (float)Math.Cos(angleRad),
                M34 = 0,

                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1
            };
            return Matrix4x4.Multiply(m, RX);
        }
        static public Matrix4x4 RotateZ(this Matrix4x4 m, float angleRad)
        {
            Matrix4x4 RX = new Matrix4x4()
            {
                M11 = (float)Math.Cos(angleRad),
                M12 = -(float)Math.Sin(angleRad),
                M13 = 0,
                M14 = 0,

                M21 = (float)Math.Sin(angleRad),
                M22 = (float)Math.Cos(angleRad),
                M23 = 0,
                M24 = 0,

                M31 = 0,
                M32 = 0,
                M33 = 1,
                M34 = 0,

                M41 = 0,
                M42 = 0,
                M43 = 0,
                M44 = 1
            };
            return Matrix4x4.Multiply(m, RX);
        }
        static public Vector4 Multiply(this Matrix4x4 matrix, Vector4 vector)
        {
            float a = matrix.M11 * vector.X + matrix.M12 * vector.Y + matrix.M13 * vector.Z + matrix.M14 * vector.W;
            float b = matrix.M21 * vector.X + matrix.M22 * vector.Y + matrix.M23 * vector.Z + matrix.M24 * vector.W;
            float c = matrix.M31 * vector.X + matrix.M32 * vector.Y + matrix.M33 * vector.Z + matrix.M34 * vector.W;
            float d = matrix.M41 * vector.X + matrix.M42 * vector.Y + matrix.M43 * vector.Z + matrix.M44 * vector.W;
            return new Vector4(a, b, c, d);
        }

    }
}
