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
        Mesh sphere;
        GlobalObject global = new GlobalObject();
        Camera camera = new Camera();
        Keys pressedKey = Keys.End;
        CameraEnum cameraEnum;
        LightMode lightMode= LightMode.None;
        // x     z
        //       ^
        // y <--\|

        public Form1()
        {
            InitializeComponent();
            InitializeGame.Initialize(Workspace, global, camera, viewMatrix1, projectionMatrix, ref cube, ref cube2,ref sphere);
            cameraEnum = CameraEnum.Constant;
            timer1.Start();
            timer1.Interval = 10;

            Workspace.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            newPhoto = new Color[Workspace.Width, Workspace.Height];
            e.Graphics.Clear(Color.White);
            Graphics gp = e.Graphics;

            List<(List<Triangle>,Mesh)> triangles2 = global.GetViewTraingle();
            global.ClearBuffer();
            try
            {
                using (Bitmap b = ScanLine.GetBitmap(newPhoto, triangles2, global.ZBuffor, lightMode))
                {
                    gp.DrawImage(b, new PointF(0, 0));
                }
            }
            catch (IndexOutOfRangeException error)
            {
                if (cubeRadio.Checked)
                    cube.OutOfBitmap();
                if (cube2Radio.Checked)
                    cube2.OutOfBitmap();
                if (sphereRadio.Checked)
                    sphere.OutOfBitmap();
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
            global.ClearBuffer();
            //cube.RotateZ(0.1f);
            //cube2.RotateX(-0.1f);
            if (cubeRadio.Checked)
            {
                InitializeGame.KeysHandler(cube, pressedKey);
                if (cameraEnum == CameraEnum.Following)
                    CameraUIHandlers.UpdateCameraTarget(global, cube, camera, ref viewMatrix1);
            }
            if (cube2Radio.Checked)
                InitializeGame.KeysHandler(cube2, pressedKey);
            if(sphereRadio.Checked)
                InitializeGame.KeysHandler(sphere, pressedKey);

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

        private void cube2Radio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cubeRadio_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void XCameraTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void YCameraTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ZCameraTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void constantCameraButton_Click(object sender, EventArgs e)
        {
            if (cameraEnum == CameraEnum.Constant || cameraEnum == CameraEnum.Following)
            {
                CameraUIHandlers.ConstantCameraHandler(global, camera, ref viewMatrix1, XCameraTextBox.Text, YCameraTextBox.Text, ZCameraTextBox.Text);
            }
        }

        private void followsCubeCamraRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (followsCubeCamraRadio.Checked)
                cameraEnum = CameraEnum.Following;
            else if (constantCameraRadio.Checked)
            {
                if (cameraEnum == CameraEnum.Following)
                    CameraUIHandlers.ClearTarget(global, camera, ref viewMatrix1);
                cameraEnum = CameraEnum.Constant;

            }

        }

        private void noneShaderRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (noneShaderRadio.Checked)
                lightMode = LightMode.None;
        }

        private void phongShaderRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (phongShaderRadio.Checked)
                lightMode = LightMode.Phong;
        }

        private void gouraudShaderRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (gouraudShaderRadio.Checked)
                lightMode = LightMode.Gouraud;
        }

        private void flatShaderRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (flatShaderRadio.Checked)
                lightMode = LightMode.Flat;
        }

        private void sphereRadio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
