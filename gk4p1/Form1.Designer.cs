namespace gk4p1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Workspace = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cube2Radio = new System.Windows.Forms.RadioButton();
            this.cubeRadio = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.constantCameraButton = new System.Windows.Forms.Button();
            this.ZCameraTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.YCameraTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.XCameraTextBox = new System.Windows.Forms.TextBox();
            this.onCubeCameraRadio = new System.Windows.Forms.RadioButton();
            this.followsCubeCamraRadio = new System.Windows.Forms.RadioButton();
            this.constantCameraRadio = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Controls.Add(this.Workspace, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 366);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Workspace
            // 
            this.Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Workspace.Location = new System.Drawing.Point(2, 2);
            this.Workspace.Margin = new System.Windows.Forms.Padding(2);
            this.Workspace.Name = "Workspace";
            this.Workspace.Size = new System.Drawing.Size(446, 342);
            this.Workspace.TabIndex = 0;
            this.Workspace.TabStop = false;
            this.Workspace.Click += new System.EventHandler(this.Workspace_Click);
            this.Workspace.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Workspace.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Workspace_PreviewKeyDown);
            this.Workspace.Resize += new System.EventHandler(this.Workspace_Resize);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(452, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(146, 342);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cube2Radio);
            this.groupBox1.Controls.Add(this.cubeRadio);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cube2Radio
            // 
            this.cube2Radio.AutoSize = true;
            this.cube2Radio.Location = new System.Drawing.Point(3, 39);
            this.cube2Radio.Name = "cube2Radio";
            this.cube2Radio.Size = new System.Drawing.Size(55, 17);
            this.cube2Radio.TabIndex = 1;
            this.cube2Radio.Text = "cube2";
            this.cube2Radio.UseVisualStyleBackColor = true;
            this.cube2Radio.CheckedChanged += new System.EventHandler(this.cube2Radio_CheckedChanged);
            this.cube2Radio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cubeRadio_KeyDown);
            this.cube2Radio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cubeRadio_KeyDown);
            // 
            // cubeRadio
            // 
            this.cubeRadio.AutoSize = true;
            this.cubeRadio.Checked = true;
            this.cubeRadio.Location = new System.Drawing.Point(3, 16);
            this.cubeRadio.Name = "cubeRadio";
            this.cubeRadio.Size = new System.Drawing.Size(85, 17);
            this.cubeRadio.TabIndex = 0;
            this.cubeRadio.TabStop = true;
            this.cubeRadio.Text = "radioButton1";
            this.cubeRadio.UseVisualStyleBackColor = true;
            this.cubeRadio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.cubeRadio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cubeRadio_KeyDown);
            this.cubeRadio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cubeRadio_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.constantCameraButton);
            this.groupBox2.Controls.Add(this.ZCameraTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.YCameraTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.XCameraTextBox);
            this.groupBox2.Controls.Add(this.onCubeCameraRadio);
            this.groupBox2.Controls.Add(this.followsCubeCamraRadio);
            this.groupBox2.Controls.Add(this.constantCameraRadio);
            this.groupBox2.Location = new System.Drawing.Point(2, 84);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(150, 121);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // constantCameraButton
            // 
            this.constantCameraButton.Location = new System.Drawing.Point(74, 49);
            this.constantCameraButton.Margin = new System.Windows.Forms.Padding(2);
            this.constantCameraButton.Name = "constantCameraButton";
            this.constantCameraButton.Size = new System.Drawing.Size(56, 19);
            this.constantCameraButton.TabIndex = 9;
            this.constantCameraButton.Text = "submit";
            this.constantCameraButton.UseVisualStyleBackColor = true;
            this.constantCameraButton.Click += new System.EventHandler(this.constantCameraButton_Click);
            // 
            // ZCameraTextBox
            // 
            this.ZCameraTextBox.Location = new System.Drawing.Point(108, 26);
            this.ZCameraTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ZCameraTextBox.Name = "ZCameraTextBox";
            this.ZCameraTextBox.Size = new System.Drawing.Size(23, 20);
            this.ZCameraTextBox.TabIndex = 8;
            this.ZCameraTextBox.Text = "0,5";
            this.ZCameraTextBox.TextChanged += new System.EventHandler(this.ZCameraTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Z";
            // 
            // YCameraTextBox
            // 
            this.YCameraTextBox.Location = new System.Drawing.Point(64, 26);
            this.YCameraTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.YCameraTextBox.Name = "YCameraTextBox";
            this.YCameraTextBox.Size = new System.Drawing.Size(23, 20);
            this.YCameraTextBox.TabIndex = 6;
            this.YCameraTextBox.Text = "0,5";
            this.YCameraTextBox.TextChanged += new System.EventHandler(this.YCameraTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // XCameraTextBox
            // 
            this.XCameraTextBox.Location = new System.Drawing.Point(18, 26);
            this.XCameraTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.XCameraTextBox.Name = "XCameraTextBox";
            this.XCameraTextBox.Size = new System.Drawing.Size(23, 20);
            this.XCameraTextBox.TabIndex = 3;
            this.XCameraTextBox.Text = "3";
            this.XCameraTextBox.TextChanged += new System.EventHandler(this.XCameraTextBox_TextChanged);
            // 
            // onCubeCameraRadio
            // 
            this.onCubeCameraRadio.AutoSize = true;
            this.onCubeCameraRadio.Location = new System.Drawing.Point(4, 93);
            this.onCubeCameraRadio.Margin = new System.Windows.Forms.Padding(2);
            this.onCubeCameraRadio.Name = "onCubeCameraRadio";
            this.onCubeCameraRadio.Size = new System.Drawing.Size(64, 17);
            this.onCubeCameraRadio.TabIndex = 2;
            this.onCubeCameraRadio.Text = "on cube";
            this.onCubeCameraRadio.UseVisualStyleBackColor = true;
            // 
            // followsCubeCamraRadio
            // 
            this.followsCubeCamraRadio.AutoSize = true;
            this.followsCubeCamraRadio.Location = new System.Drawing.Point(4, 71);
            this.followsCubeCamraRadio.Margin = new System.Windows.Forms.Padding(2);
            this.followsCubeCamraRadio.Name = "followsCubeCamraRadio";
            this.followsCubeCamraRadio.Size = new System.Drawing.Size(84, 17);
            this.followsCubeCamraRadio.TabIndex = 1;
            this.followsCubeCamraRadio.Text = "follows cube";
            this.followsCubeCamraRadio.UseVisualStyleBackColor = true;
            this.followsCubeCamraRadio.CheckedChanged += new System.EventHandler(this.followsCubeCamraRadio_CheckedChanged);
            // 
            // constantCameraRadio
            // 
            this.constantCameraRadio.AutoSize = true;
            this.constantCameraRadio.Checked = true;
            this.constantCameraRadio.Location = new System.Drawing.Point(4, 49);
            this.constantCameraRadio.Margin = new System.Windows.Forms.Padding(2);
            this.constantCameraRadio.Name = "constantCameraRadio";
            this.constantCameraRadio.Size = new System.Drawing.Size(66, 17);
            this.constantCameraRadio.TabIndex = 0;
            this.constantCameraRadio.TabStop = true;
            this.constantCameraRadio.Text = "constant";
            this.constantCameraRadio.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Workspace;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cube2Radio;
        private System.Windows.Forms.RadioButton cubeRadio;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox XCameraTextBox;
        private System.Windows.Forms.RadioButton onCubeCameraRadio;
        private System.Windows.Forms.RadioButton followsCubeCamraRadio;
        private System.Windows.Forms.RadioButton constantCameraRadio;
        private System.Windows.Forms.TextBox ZCameraTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox YCameraTextBox;
        private System.Windows.Forms.Button constantCameraButton;
    }
}

