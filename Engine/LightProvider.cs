using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public enum LightMode
    {
        None,
        Phong,
        Gouraud,
        Flat
    }
    enum LightVector4
    {
        Constant,
        Reflektory
    }
    static class LightProvider
    {

        public class Surface
        {
            /// <summary>
            /// Współczynnik odbicia światła kierunkowego
            /// </summary>
            public double Ks { get; set; }
            /// <summary>
            /// Współczynnik odbicia światła rozproszonego
            /// </summary>
            public double Kd { get; set; }
            /// Współczynnik gładkości powierzchni
            /// Im większy współczynnik, tym lepsze właściwości odbicia kierunkowego
            /// Dla N = 100 zbliżamy się do właściwości lustrzanych
            /// </summary>
            public double N { get; set; }
            public Surface()
            {
                Ks = 0.75;
                Kd = 0.25;
                N = 100;
            }
        }
        public static Color GetColor(int x, int y, float z, Color pixelColor, LightMode mode, Triangle t)
        {
            int m = 10;// = Settings.MA;
            float kd = 0.5f;// = Settings.Kd;
            float ks = 0.5f;//= Settings.Ks;
            float cosNL;
            float cosmVR;

            Color LightColor = Color.White;
            Vector4 Constant = new Vector4() { X = 0, Y = 0, Z = 1, W = 1 };


            Vector4 Il = Multiply(((float)1 / 255), LightColor);
            Vector4 Io;
            Vector4 L;
            Vector4 N;
            Vector4 V = new Vector4() { X = 0, Y = 0, Z = 1 };
            Vector4 R;


            //obecny kolor Io
            Io = ((float)1 / 255) * new Vector4(pixelColor.R, pixelColor.G, pixelColor.B, 1);

            //swiatlo
            L = NormalizeSecondWay(new Vector4() { X = 0, Y = 0, Z = 5 });
            N = Constant;

            R = 2 * (N * L) * N + (-1) * L;

            cosNL = Cos(N, L);
            cosmVR = (float)Math.Pow(Cos(V, R), m);

            if (cosmVR < -0.9)
                Console.Write("a");


            Color pColor = CalculateColor(kd, Il, Io, cosNL, ks, cosmVR, x, y);
            if (mode == LightMode.Phong)
                return Phong(x, y, z, pColor);
            if(mode == LightMode.Gouraud)
            {
                Color a = Phong((int)t.A.X, (int)t.A.Y,t.A.Z,pColor);
                Color b = Phong((int)t.B.X, (int)t.B.Y,t.B.Z,pColor);
                Color c = Phong((int)t.C.X, (int)t.C.Y,t.C.Z,pColor);
                Color interpolated = t.InterpolatedColor(x, y, a, b, c);
                return interpolated;
            }
            if(mode == LightMode.Flat)
            {
                Color a = Phong((int)t.A.X, (int)t.A.Y, t.A.Z, pColor);
                Color b = Phong((int)t.B.X, (int)t.B.Y, t.B.Z, pColor);
                Color c = Phong((int)t.C.X, (int)t.C.Y, t.C.Z, pColor);
                Color interpolated = Color.FromArgb((a.R+b.R+c.R)/3, (a.G + b.G + c.G) / 3, (a.B + b.B + c.B) / 3);
                return interpolated;
            }

            return pColor;
        }





        #region phong
        static private Color Phong(int x, int y, float z, Color pColor)
        {
            Surface material = new Surface();
            Vector3 Source = new Vector3(80, 80, 5);
            double Ia = 100;
            double Ip = 50000;
            double Ka = 0.5;
            var l = new Vector3(x, y, z);
            l = Vector3.Normalize(l);
            l.Z = z;
            var point = new Vector3() { X = x, Y = y, Z = z * 500 };
            var n = new Vector3() { X = x - Source.X, Y = y - Source.Y, Z = z - Source.Z };
            n = Vector3.Normalize(n);

            var I = CalculateLightReflection(material, Scalar(n, l),
                        CalculateCosAlpha(ComputeVector(Source, point), l), point, Ia, Ka, Ip, Source);

            var red = Check(pColor.R + I);
            var green = Check(pColor.G + I);
            var blue = Check(pColor.B + I);
            return Color.FromArgb(red, green, blue);
        }
        private static Vector3 ComputeVector(Vector3 start, Vector3 end)
        {
            return new Vector3(end.X - start.X, end.Y - start.Y, end.Z - start.Z);
        }
        private static double Fatt(Vector3 p, Vector3 Source)
        {
            var distance = Math.Pow(p.X - Source.X, 2) + Math.Pow(p.Y - Source.Y, 2) + Math.Pow(p.Z - Source.Z, 2);
            return 1.0 / Math.Sqrt(distance);
        }
        private static double Scalar(Vector3 v, Vector3 b)
        {
            return v.X * b.X + v.Y * b.Y + v.Z * b.Z;
        }

        private static int Check(double i)
        {
            if (i < 0)
            {
                return 0;
            }
            else if (i > 255)
            {
                return 255;
            }
            else
            {
                return (int)i;
            }
        }
        static private double CalculateLightReflection(Surface surface, double scalar, double cosAlpha, Vector3 point, double Ia, double Ka, double Ip, Vector3 source)
        {
            return Ia * Ka
                    + Fatt(point, source) * Ip * surface.Kd * scalar
                    + Fatt(point, source) * Ip * surface.Ks * Math.Pow(cosAlpha, surface.N);
        }
        private static double CalculateCosAlpha(Vector3 v, Vector3 b)
        {
            var distance = Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z) * Math.Sqrt(b.X * b.X + b.Y * b.Y + b.Z * b.Z);
            if (Scalar(v, b) > 0) return 0;
            return Scalar(v, b) / distance;
        }

        static private Color CalculateColor(float kd, Vector4 Il, Vector4 Io, float cosNL, float ks, float cosmVR, float x, float y)
        {
            float Ir = kd * Il.X * Io.X * cosNL + ks * Il.X * Io.X * cosmVR;
            float Ig = kd * Il.Y * Io.Y * cosNL + ks * Il.Y * Io.Y * cosmVR;
            float Ib = kd * Il.Z * Io.Z * cosNL + ks * Il.Z * Io.Z * cosmVR;

            Ir = Ir > 1 ? 1 : Ir < 0 ? 0 : Ir;
            Ig = Ig > 1 ? 1 : Ig < 0 ? 0 : Ig;
            Ib = Ib > 1 ? 1 : Ib < 0 ? 0 : Ib;


            Color c = Color.FromArgb((byte)(Ir * 255), (byte)(Ig * 255), (byte)(Ib * 255));
            return c;
        }
        static private Vector4 Multiply(Vector4 v1, Vector4 v2)
        {
            return new Vector4() { X = v1.X * v2.X, Y = v1.Y * v2.Y, Z = v1.Z * v2.Z };
        }
        static private Vector4 Multiply(float k, Vector4 v2)
        {
            return new Vector4() { X = k * v2.X, Y = k * v2.Y, Z = k * v2.Z };
        }
        static private Vector4 Multiply(float k, Color v2)
        {
            return new Vector4() { X = k * v2.R, Y = k * v2.G, Z = k * v2.B };
        }
        static private Vector4 Add(Vector4 v1, Vector4 v2)
        {
            return new Vector4() { X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z + v2.Z };
        }
        static private Vector4 Normalize(Vector4 v)
        {
            return new Vector4() { X = (float)((v.X - 127) / 128), Y = (float)((v.Y - 127) / 128), Z = (float)((v.Z) / 255) };
        }
        static private Vector4 NormalizeSecondWay(Vector4 v)
        {
            float length = (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
            return new Vector4() { X = v.X / length, Y = v.Y / length, Z = v.Z / length };
        }

        static private float Cos(Vector4 v1, Vector4 v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        static private float Cos(Color v1, Vector4 v2)
        {
            return v1.R * v2.X + v1.G * v2.Y + v1.B * v2.Z;
        }
        #endregion 
    }
}
