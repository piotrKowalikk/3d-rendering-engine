using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Camera
    {
        private Vector3 position;
        public Vector3 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                CalculateAxis();
            }
        }

        private Vector3 target;
        public Vector3 Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
                CalculateAxis();
            }
        }

        private Vector3 upVector;
        private Vector3 upVectorVersor;
        public Vector3 UpVector
        {
            get
            {
                return upVector;
            }
            set
            {
                upVector = value;
                upVectorVersor = new Vector3() { X = value.X / value.Length(), Y = value.Y / value.Length(), Z = value.Z / value.Length() };
                CalculateAxis();
            }
        }

        public Vector3 ZAxisVersor { get; private set; }
        public Vector3 XAxisVersor { get; private set; }
        public Vector3 YAxisVersor { get; private set; }

        public void Initialize()
        {
            Position = new Vector3() {X=3,Y=0.5f,Z=0.5f };
            Target = new Vector3() { X = 0, Y = 0.5f, Z = 0.5f };
            UpVector = new Vector3() { X = 0, Y = 0, Z = 1 };
        }

        private void CalculateAxis()
        {
            //zAxis
            Vector3 zAxis = new Vector3() { X = position.X - target.X, Y = position.Y - target.Y, Z = position.Z - target.Z };
            float ZAxisLength = zAxis.Length();
            ZAxisVersor = new Vector3()
            {
                X = zAxis.X / ZAxisLength,
                Y = zAxis.Y / ZAxisLength,//wg excela tu zawsze 0
                Z = zAxis.Z / ZAxisLength//wg excela tu zawsze 1
            };
            //xAxis
            // czemu takie dziwne mnożenie?
            Vector3 xAxis = new Vector3() { X = upVectorVersor.Y * ZAxisVersor.Z - upVectorVersor.Z * ZAxisVersor.Y, Y = upVectorVersor.X * ZAxisVersor.Z - upVectorVersor.Z * ZAxisVersor.X, Z = upVectorVersor.X * ZAxisVersor.Y - upVectorVersor.Y * ZAxisVersor.X };
            XAxisVersor = new Vector3()
            {
                X = xAxis.X / xAxis.Length(),
                Y = xAxis.Y / xAxis.Length(),
                Z = xAxis.Z / xAxis.Length(),
            };

            //yAxis
            YAxisVersor = new Vector3()
            {
                X = ZAxisVersor.Y * XAxisVersor.Z - ZAxisVersor.Z * XAxisVersor.Y,
                Y = -ZAxisVersor.X * XAxisVersor.Z + ZAxisVersor.Z * XAxisVersor.Y,
                Z = ZAxisVersor.X * XAxisVersor.Y - ZAxisVersor.Y * XAxisVersor.X
            };
        }

        public void UpdateCamera(Vector3 position)
        {
            Position = position;
        }
    }
}
