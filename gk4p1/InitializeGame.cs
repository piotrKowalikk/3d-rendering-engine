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
        static public void Initialize(PictureBox Workspace, GlobalObject global, Camera camera, ViewMatrix viewMatrix, ProjectionMatrix projectionMatrix, ref Mesh cube, ref Mesh cube2, ref Mesh sphere)
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


            //cube2
            Matrix4x4 cube2View = Matrix4x4.Identity;
            //te trzy przesuniecia na mapie globalej -translacja
            cube2View.M14 = -5;
            cube2View.M24 = 6;
            cube2View.M34 = 4;

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
            //sphere
            var vectors = new List<Vector3>();
            var vectors4 = new List<Vector4>();
            var indices = new List<int>();

            GeometryProvider.Icosahedron(vectors, indices);
            List<Triangle> triangles = new List<Triangle>();
            for (var i = 0; i < 1; i++)
                GeometryProvider.Subdivide(vectors, indices, true);

            /// normalize vectors to "inflate" the icosahedron into a sphere.
            foreach (var vector in vectors)
            {
                vectors4.Add(new Vector4(Vector3.Normalize(vector), 1));
            }
            sphere = new Mesh("sphere",vectors4.ToArray(),Matrix4x4.Identity);
            for (int i = 0; i < indices.Count; i += 3)
            {
                triangles.Add(new Triangle()
                {
                    A = vectors4[indices[i]],
                    B = vectors4[indices[i + 1]],
                    C = vectors4[indices[i + 2]]
                });
            }
            sphere.Triangles = triangles;
            sphere.MoveX(-3.5f);
            sphere.MoveY(-6);
            sphere.MoveZ(-6);

            global.Meshes.Add(sphere); 
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
                    m.MoveY(0.3f);
                    break;
                case Keys.L:
                    m.MoveY(-0.3f);
                    break;
                case Keys.K:
                    m.MoveX(0.3f);
                    break;
                case Keys.I:
                    m.MoveX(-0.3f);
                    break;
                case Keys.U:
                    m.MoveZ(-0.3f);
                    break;
                case Keys.O:
                    m.MoveZ(0.3f);
                    break;
            }
        }
    }
}
