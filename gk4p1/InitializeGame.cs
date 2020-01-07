using Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gk4p1
{
    static public class InitializeGame
    {
        static public void Initialize(PictureBox Workspace, GlobalObject global, Camera camera, ViewMatrix viewMatrix, ProjectionMatrix projectionMatrix, ref Mesh cube, ref Mesh cube2)
        {
            global.Width = Workspace.Width;
            global.Height = Workspace.Height;

            camera.Initialize();
            viewMatrix.Camera = camera;
            projectionMatrix.Initilize();
            global.ProjMatrix = projectionMatrix;
            global.ViewMatrix = viewMatrix;
            //cube
            cube = new Mesh("cube", new Vector4[] {
                                                    new Vector4(-1, -1, -1, 1),
                                                    new Vector4(1, -1, -1, 1),
                                                    new Vector4(1, 1, -1, 1),
                                                    new Vector4(-1, 1, -1, 1),
                                                    new Vector4(-1, -1, 1, 1),
                                                    new Vector4(1, -1, 1, 1),
                                                    new Vector4(1, 1, 1, 1),
                                                    new Vector4(-1, 1, 1, 1)
                                                }, Matrix4x4.Identity);
            cube.Triangles = new List<Triangle>()
            {
                        new Triangle() { A=cube.Vertices[0], B= cube.Vertices[1],C= cube.Vertices[3]},
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[2],C= cube.Vertices[3] },
                        new Triangle() { A=cube.Vertices[2], B=cube.Vertices[3],C= cube.Vertices[6] },
                        new Triangle() { A=cube.Vertices[3], B=cube.Vertices[6],C= cube.Vertices[7] },
                        new Triangle() { A=cube.Vertices[4], B=cube.Vertices[6],C= cube.Vertices[7] },
                        new Triangle() { A=cube.Vertices[4], B=cube.Vertices[5],C= cube.Vertices[6] },
                        new Triangle() { A=cube.Vertices[0], B=cube.Vertices[1],C= cube.Vertices[4] },
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[4],C= cube.Vertices[5] },
                        new Triangle() { A=cube.Vertices[3], B=cube.Vertices[4],C= cube.Vertices[7] },
                        new Triangle() { A=cube.Vertices[0], B=cube.Vertices[3],C= cube.Vertices[4] }
            };
            cube.Position = new Vector3() { X = 0.50f, Y = 0, Z = 0 };
            //cube.Position = new Vector3() { X = 0.50f, Y = 0.50f, Z = 0.50f };
            ///global.Meshes.Add(cube);


            //cube
            Matrix4x4 cube2View = Matrix4x4.Identity;
            //te trzy przesuniecia na mapie globalej -translacja
            cube2View.M14 = 10;
            cube2View.M24 = 5.5f;
            cube2View.M34 = 5.5f;

            cube2 = new Mesh("cube", new Vector4[] {
                                                    new Vector4(-1, -1, -1, 1),
                                                    new Vector4(1, -1, -1, 1),
                                                    new Vector4(1, 1, -1, 1),
                                                    new Vector4(-1, 1, -1, 1),
                                                    new Vector4(-1, -1, 1, 1),
                                                    new Vector4(1, -1, 1, 1),
                                                    new Vector4(1, 1, 1, 1),
                                                    new Vector4(-1, 1, 1, 1)
                                                }, cube2View);
            cube2.Triangles = new List<Triangle>()
            {
                        new Triangle() { A=cube2.Vertices[1], B=cube2.Vertices[1],C= cube2.Vertices[3]},
                        new Triangle() { A=cube2.Vertices[1], B=cube2.Vertices[2],C= cube2.Vertices[3] },
                        new Triangle() { A=cube2.Vertices[2], B=cube2.Vertices[3],C= cube2.Vertices[6] },
                        new Triangle() { A=cube2.Vertices[3], B=cube2.Vertices[6],C= cube2.Vertices[7] },
                        new Triangle() { A=cube2.Vertices[4], B=cube2.Vertices[6],C= cube2.Vertices[7] },
                        new Triangle() { A=cube2.Vertices[4], B=cube2.Vertices[5],C= cube2.Vertices[6] },
                        new Triangle() { A=cube2.Vertices[0], B=cube2.Vertices[1],C= cube2.Vertices[4] },
                        new Triangle() { A=cube2.Vertices[1], B=cube2.Vertices[4],C= cube2.Vertices[5] },
                        new Triangle() { A=cube2.Vertices[3], B=cube2.Vertices[4],C= cube2.Vertices[7] },
                        new Triangle() { A=cube2.Vertices[0], B=cube2.Vertices[3],C= cube2.Vertices[4] }
            };
            global.Meshes.Add(cube2);
        }
        static public void KeysHandler(Mesh m, Keys k)
        {
            switch (k)
            {
                case Keys.Q:
                        m.RotateX(0.1f);
                    break;
                case Keys.W:
                        m.RotateX(-0.1f);
                    break;
                case Keys.A:
                        m.RotateZ(-0.1f);
                    break;
                case Keys.S:
                        m.RotateZ(0.1f);
                    break;
                case Keys.Z:
                        m.RotateY(0.1f);
                    break;
                case Keys.X:
                        m.RotateY(-0.1f);
                    break;

                case Keys.Right:
                        m.MoveY(0.5f);
                    break;
                case Keys.Left:
                        m.MoveY(-0.5f);
                    break;
                case Keys.Up:
                        m.MoveX(0.5f);
                    break;
                case Keys.Down:
                        m.MoveX(-0.5f);
                    break;
                case Keys.OemPeriod:
                        m.MoveZ(-0.5f);
                    break;
                case Keys.Oemcomma:
                        m.MoveZ(0.5f);
                    break;
            }
        }
    }
}
