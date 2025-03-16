namespace Hospital_Management_System
{
    partial class Loading
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.label1);
            this.gunaGradient2Panel1.Controls.Add(this.pictureBox1);
            this.gunaGradient2Panel1.Controls.Add(this.circularProgressBar1);
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(84)))), ((int)(((byte)(174)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.Thistle;
            this.gunaGradient2Panel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(0, -1);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Radius = 10;
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(640, 375);
            this.gunaGradient2Panel1.TabIndex = 0;
            this.gunaGradient2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaGradient2Panel1_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(136, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // circularProgressBar1
            // 
            this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circularProgressBar1.AnimationSpeed = 500;
            this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.Font = new System.Drawing.Font("Book Antiqua", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circularProgressBar1.ForeColor = System.Drawing.Color.Black;
            this.circularProgressBar1.InnerColor = System.Drawing.Color.Transparent;
            this.circularProgressBar1.InnerMargin = 2;
            this.circularProgressBar1.InnerWidth = -1;
            this.circularProgressBar1.Location = new System.Drawing.Point(224, 200);
            this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            this.circularProgressBar1.Name = "circularProgressBar1";
            this.circularProgressBar1.OuterColor = System.Drawing.SystemColors.ControlLight;
            this.circularProgressBar1.OuterMargin = -26;
            this.circularProgressBar1.OuterWidth = 26;
            this.circularProgressBar1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(84)))), ((int)(((byte)(174)))));
            this.circularProgressBar1.ProgressWidth = 15;
            this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circularProgressBar1.Size = new System.Drawing.Size(191, 152);
            this.circularProgressBar1.StartAngle = 270;
            this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circularProgressBar1.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circularProgressBar1.SubscriptText = "";
            this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circularProgressBar1.SuperscriptText = "";
            this.circularProgressBar1.TabIndex = 0;
            this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.circularProgressBar1.Value = 68;
            this.circularProgressBar1.Click += new System.EventHandler(this.circularProgressBar1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(84)))), ((int)(((byte)(174)))));
            this.label1.Location = new System.Drawing.Point(107, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 56);
            this.label1.TabIndex = 2;
            this.label1.Text = "SUN   HOSPITAL";
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(641, 374);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.gunaGradient2Panel1.ResumeLayout(false);
            this.gunaGradient2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
        private System.Windows.Forms.Label label1;
    }
}