using Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;

namespace gk4p1
{
    public partial class Form1 : Form
    {
        ProjectionMatrix projectionMatrix = new ProjectionMatrix();
        ViewMatrix viewMatrix1 = new ViewMatrix();
        Color[,] newPhoto;
        Mesh cube;
        GlobalObject global = new GlobalObject();
        Camera camera= new Camera();

        // x     z
        //       ^
        // y <--\|

        public Form1()
        {
            InitializeComponent();
            InitializeGame.Initialize(Workspace, global, camera, viewMatrix1, projectionMatrix,ref cube);

            timer1.Start();

            Workspace.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            newPhoto = new Color[Workspace.Width, Workspace.Height];
            e.Graphics.Clear(Color.White);
            Graphics gp = e.Graphics;

            var triangles2 = global.GetViewTraingle().First();
            using (Bitmap b = ScanLine.GetBitmap(newPhoto, triangles2.Item1, triangles2.Item2))
            {
                gp.DrawImage(b, new PointF(0, 0));
            }
        }

        private void Workspace_Resize(object sender, EventArgs e)
        {
            global.Width = Workspace.Width;
            global.Height = Workspace.Height;
            Workspace.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cube.RotateX(0.1f);
            Workspace.Invalidate();
        }

    }
}
