using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public struct ProjectionMatrix
    {
        public Matrix4x4 Matrix { get; private set; }

        private float n;
        public float N
        {
            get
            {
                return n;
            }
            set
            {
                n = value;
                CalculateMatrix();
            }
        }

        private float f;
        public float F
        {
            get
            {
                return f;
            }
            set
            {
                f = value;
                CalculateMatrix();
            }
        }

        private float fov;
        public float FOV
        {
            get
            {
                return fov;
            }
            set
            {
                fov = value;
                CalculateMatrix();
            }
        }

        private float a;
        public float A
        {
            get
            {
                return a;
            }
            set
            {
                a = value;
                CalculateMatrix();
            }
        }


        public void Initilize()
        {
            n = 1;
            f = 100;
            a = 1;
            fov = 100;
            CalculateMatrix();
        }

        private void CalculateMatrix()
        {
            double e = 1.0f / Math.Tan(fov * Math.PI / 180 / 2);
            double m33 = -1 * (n + f) / (f - n);
            double m34 = -2 * (f * n) / (f - n);
            Matrix = new Matrix4x4()
            {
                M11 = (float)e,
                M22 = (float)e,
                M33 = (float)m33,
                M34 = (float)m34,
                M43 = (float)-1
            };
        }

    }
}
