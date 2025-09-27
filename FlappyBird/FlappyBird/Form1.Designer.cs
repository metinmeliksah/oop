namespace FlappyBird
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
            this.FlappyBirdpictureBox1 = new System.Windows.Forms.PictureBox();
            this.Flying_timer1 = new System.Windows.Forms.Timer(this.components);
            this.Fall_down_timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FlappyBirdpictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FlappyBirdpictureBox1
            // 
            this.FlappyBirdpictureBox1.BackgroundImage = global::FlappyBird.Properties.Resources.Flappy_Bird_1;
            this.FlappyBirdpictureBox1.Location = new System.Drawing.Point(120, 280);
            this.FlappyBirdpictureBox1.Name = "FlappyBirdpictureBox1";
            this.FlappyBirdpictureBox1.Size = new System.Drawing.Size(170, 120);
            this.FlappyBirdpictureBox1.TabIndex = 0;
            this.FlappyBirdpictureBox1.TabStop = false;
            this.FlappyBirdpictureBox1.Click += new System.EventHandler(this.FlappyBirdpictureBox1_Click);
            // 
            // Flying_timer1
            // 
            this.Flying_timer1.Enabled = true;
            this.Flying_timer1.Tick += new System.EventHandler(this.Flying_timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(217)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(999, 761);
            this.Controls.Add(this.FlappyBirdpictureBox1);
            this.Name = "Form1";
            this.Text = "Flappy Bird";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlappyBirdpictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FlappyBirdpictureBox1;
        private System.Windows.Forms.Timer Flying_timer1;
        private System.Windows.Forms.Timer Fall_down_timer1;
    }
}

