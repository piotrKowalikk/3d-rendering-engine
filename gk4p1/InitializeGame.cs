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
                        new Triangle() { A=cube.Vertices[0], B=cube.Vertices[3],C= cube.Vertices[4] },
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[5],C= cube.Vertices[6] },
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[2],C= cube.Vertices[6] }

            };
            cube.MoveX(-3);
            global.Meshes.Add(cube);


            //cube
            Matrix4x4 cube2View = Matrix4x4.Identity;
            //te trzy przesuniecia na mapie globalej -translacja
            cube2View.M14 = 0;
            cube2View.M24 = 1;
            cube2View.M34 = 1;

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
                        new Triangle() { A=cube.Vertices[0], B= cube.Vertices[1],C= cube.Vertices[3]},
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[2],C= cube.Vertices[3] },
                        new Triangle() { A=cube.Vertices[2], B=cube.Vertices[3],C= cube.Vertices[6] },
                        new Triangle() { A=cube.Vertices[3], B=cube.Vertices[6],C= cube.Vertices[7] },
                        new Triangle() { A=cube.Vertices[4], B=cube.Vertices[6],C= cube.Vertices[7] },
                        new Triangle() { A=cube.Vertices[4], B=cube.Vertices[5],C= cube.Vertices[6] },
                        new Triangle() { A=cube.Vertices[0], B=cube.Vertices[1],C= cube.Vertices[4] },
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[4],C= cube.Vertices[5] },
                        new Triangle() { A=cube.Vertices[3], B=cube.Vertices[4],C= cube.Vertices[7] },
                        new Triangle() { A=cube.Vertices[0], B=cube.Vertices[3],C= cube.Vertices[4] },
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[5],C= cube.Vertices[6] },
                        new Triangle() { A=cube.Vertices[1], B=cube.Vertices[2],C= cube.Vertices[6] }
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

                case Keys.J:
                        m.MoveY(0.5f);
                    break;
                case Keys.L:
                        m.MoveY(-0.5f);
                    break;
                case Keys.K:
                        m.MoveX(0.5f);
                    break;
                case Keys.I:
                        m.MoveX(-0.5f);
                    break;
                case Keys.U:
                        m.MoveZ(-0.5f);
                    break;
                case Keys.O:
                        m.MoveZ(0.5f);
                    break;
            }
        }
    }
}
