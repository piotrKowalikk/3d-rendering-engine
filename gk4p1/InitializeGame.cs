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
        static public void Initialize(PictureBox Workspace, GlobalObject global, Camera camera, ViewMatrix viewMatrix, ProjectionMatrix projectionMatrix,ref Mesh cube )
        {
            global.Width = Workspace.Width;
            global.Height = Workspace.Height;

            //cube
            camera.Initialize();
            viewMatrix.Camera = camera;
            projectionMatrix.Initilize();
            cube = new Mesh("cube", new Vector4[] {
                                                    new Vector4(0, 0, 0, 1),
                                                    new Vector4(1, 0, 0, 1),
                                                    new Vector4(1, 1, 0, 1),
                                                    new Vector4(0, 1, 0, 1),
                                                    new Vector4(0, 0, 1, 1),
                                                    new Vector4(1, 0, 1, 1),
                                                    new Vector4(1, 1, 1, 1),
                                                    new Vector4(0, 1, 1, 1)
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
            global.Meshes.Add(cube);
            global.ProjMatrix = projectionMatrix;
            global.ViewMatrix = viewMatrix;

        }
    }
}
