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
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.Workspace = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cube2Radio = new System.Windows.Forms.RadioButton();
            this.cubeRadio = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Workspace, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(4, 429);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Workspace
            // 
            this.Workspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Workspace.Location = new System.Drawing.Point(3, 2);
            this.Workspace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Workspace.Name = "Workspace";
            this.Workspace.Size = new System.Drawing.Size(594, 421);
            this.Workspace.TabIndex = 0;
            this.Workspace.TabStop = false;
            this.Workspace.Click += new System.EventHandler(this.Workspace_Click);
            this.Workspace.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.Workspace.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Workspace_PreviewKeyDown);
            this.Workspace.Resize += new System.EventHandler(this.Workspace_Resize);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cube2Radio);
            this.groupBox1.Controls.Add(this.cubeRadio);
            this.groupBox1.Location = new System.Drawing.Point(604, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(192, 123);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // cube2Radio
            // 
            this.cube2Radio.AutoSize = true;
            this.cube2Radio.Location = new System.Drawing.Point(4, 48);
            this.cube2Radio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cube2Radio.Name = "cube2Radio";
            this.cube2Radio.Size = new System.Drawing.Size(68, 21);
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
            this.cubeRadio.Location = new System.Drawing.Point(4, 20);
            this.cubeRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cubeRadio.Name = "cubeRadio";
            this.cubeRadio.Size = new System.Drawing.Size(110, 21);
            this.cubeRadio.TabIndex = 0;
            this.cubeRadio.TabStop = true;
            this.cubeRadio.Text = "radioButton1";
            this.cubeRadio.UseVisualStyleBackColor = true;
            this.cubeRadio.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            this.cubeRadio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cubeRadio_KeyDown);
            this.cubeRadio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cubeRadio_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Workspace)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox Workspace;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cube2Radio;
        private System.Windows.Forms.RadioButton cubeRadio;
    }
}

