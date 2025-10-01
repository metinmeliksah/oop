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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FlappyBirdpictureBox1 = new System.Windows.Forms.PictureBox();
            this.Flying_timer1 = new System.Windows.Forms.Timer(this.components);
            this.ground = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.instructionsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.FlappyBirdpictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            this.SuspendLayout();
            // 
            // FlappyBirdpictureBox1
            // 
            this.FlappyBirdpictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.FlappyBirdpictureBox1.Image = global::FlappyBird.Properties.Resources.Flappy_Bird_1;
            this.FlappyBirdpictureBox1.Location = new System.Drawing.Point(100, 300);
            this.FlappyBirdpictureBox1.Name = "FlappyBirdpictureBox1";
            this.FlappyBirdpictureBox1.Size = new System.Drawing.Size(60, 50);
            this.FlappyBirdpictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FlappyBirdpictureBox1.TabIndex = 0;
            this.FlappyBirdpictureBox1.TabStop = false;
            this.FlappyBirdpictureBox1.Click += new System.EventHandler(this.FlappyBirdpictureBox1_Click);
            // 
            // Flying_timer1
            // 
            this.Flying_timer1.Enabled = true;
            this.Flying_timer1.Interval = 200;
            this.Flying_timer1.Tick += new System.EventHandler(this.Flying_timer1_Tick);
            // 
            // ground
            // 
            this.ground.BackColor = System.Drawing.Color.SaddleBrown;
            this.ground.Location = new System.Drawing.Point(-3, 726);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(1020, 50);
            this.ground.TabIndex = 3;
            this.ground.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(12, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(114, 31);
            this.scoreLabel.TabIndex = 4;
            this.scoreLabel.Text = "Puan: 0";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.instructionsLabel.ForeColor = System.Drawing.Color.Yellow;
            this.instructionsLabel.Location = new System.Drawing.Point(12, 50);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(219, 20);
            this.instructionsLabel.TabIndex = 5;
            this.instructionsLabel.Text = "SPACE = Zıpla - Başarılar!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(217)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(999, 761);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.FlappyBirdpictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flappy Bird - Metin Melikşah Dermencioğlu github.com/metinmeliksah";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlappyBirdpictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox FlappyBirdpictureBox1;
        private System.Windows.Forms.Timer Flying_timer1;
        private System.Windows.Forms.PictureBox ground;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label instructionsLabel;
    }
}

