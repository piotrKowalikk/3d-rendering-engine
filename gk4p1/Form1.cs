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
        Mesh cube2;
        GlobalObject global = new GlobalObject();
        Camera camera = new Camera();
        Keys pressedKey = Keys.End;

        // x     z
        //       ^
        // y <--\|

        public Form1()
        {
            InitializeComponent();
            InitializeGame.Initialize(Workspace, global, camera, viewMatrix1, projectionMatrix, ref cube, ref cube2);

            timer1.Start();

            Workspace.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            newPhoto = new Color[Workspace.Width, Workspace.Height];
            e.Graphics.Clear(Color.White);
            Graphics gp = e.Graphics;

            var triangles2 = global.GetViewTraingle();
            using (Bitmap b = ScanLine.GetBitmap(newPhoto, triangles2))
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

            if (cubeRadio.Checked)
                InitializeGame.KeysHandler(cube2, pressedKey);
            Workspace.Invalidate();
        }

        private void Workspace_Click(object sender, EventArgs e)
        {

        }

        private void Workspace_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            pressedKey = e.KeyCode;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            pressedKey = keyData;
            return base.ProcessCmdKey(ref msg, keyData);

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKey = e.KeyCode;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKey = Keys.End;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
