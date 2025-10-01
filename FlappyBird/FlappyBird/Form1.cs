using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{

    public partial class Form1 : Form
    {

        bool Fly_Boolean = false;
        int pipeSpeed = 4; // Daha yavaş başlangıç
        int gravity = 6; // Daha yumuşak gravity
        int score = 0;
        bool gameOver = false;
        Random rand = new Random();
        
        // Birden fazla boru çifti için listeler
        List<PictureBox> pipes;
        
        // Çarpışma efekti için değişkenler
        bool crashEffect = false;
        int crashEffectTimer = 0;
        Point originalBirdPosition;
        
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            
            // Pencere boyutunu sabitle - yeniden boyutlandırmayı engelle
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            
            setupPipes();
            resetGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setupPipes()
        {
            pipes = new List<PictureBox>();
            
            // 3 çift boru oluştur (daha iyi aralık için)
            for (int i = 0; i < 6; i++)
            {
                PictureBox pipe = new PictureBox();
                pipe.Size = new Size(80, 400);
                pipe.SizeMode = PictureBoxSizeMode.StretchImage;
                pipe.BackColor = Color.Transparent;
                
                if (i % 2 == 0) // Üst borular
                {
                    pipe.Image = Properties.Resources.PipeHead;
                    pipe.Top = -350;
                }
                else // Alt borular
                {
                    pipe.Image = Properties.Resources.PipeHead;
                    pipe.Top = 450;
                }
                
                pipe.Left = 1200 + (i / 2) * 400; // Her çift 400 pixel arayla (daha geniş)
                this.Controls.Add(pipe);
                pipes.Add(pipe);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (gameOver)
                {
                    resetGame(); // Oyun bittiyse yeniden başlat
                }
                else
                {
                    jump(); // Oyun devam ediyorsa zıpla
                }
            }
        }

        private void jump()
        {
            if (!gameOver)
            {
                gravity = -10; // Daha yumuşak zıplama
            }
        }

        private void resetGame()
        {
            FlappyBirdpictureBox1.Location = new Point(100, 300);
            originalBirdPosition = FlappyBirdpictureBox1.Location;
            
            // Kuşu normal rengine döndür
            FlappyBirdpictureBox1.Image = Properties.Resources.Flappy_Bird_1;
            crashEffect = false;
            crashEffectTimer = 0;
            
            // Tüm boruları resetle
            for (int i = 0; i < pipes.Count; i++)
            {
                pipes[i].Left = 1200 + (i / 2) * 400;
                
                // Minimum ve maksimum yükseklik sınırları - her zaman geçilebilir
                int minHeight = 180; // En az bu kadar üstte olsun
                int maxHeight = 350; // En fazla bu kadar üstte olsun
                int pipeHeight = rand.Next(minHeight, maxHeight);
                
                if (i % 2 == 0) // Üst boru
                {
                    pipes[i].Top = pipeHeight - 400;
                }
                else // Alt boru
                {
                    pipes[i].Top = pipeHeight + 220; // 220 pixel geçiş aralığı (daha geniş)
                }
            }
            
            score = 0;
            pipeSpeed = 4;
            gravity = 4; // Daha yumuşak başlangıç gravity
            gameOver = false;
            scoreLabel.Text = "Puan: " + score.ToString();
            instructionsLabel.Text = "SPACE = Zıpla - Başarılar!";
            gameTimer.Start();
        }

        private void FlappyBirdpictureBox1_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                resetGame(); // Oyun bittiyse yeniden başlat
            }
            else
            {
                jump(); // Oyun devam ediyorsa zıpla
            }
        }

        private void Flying_timer1_Tick(object sender, EventArgs e)
        {
            if (!gameOver && !crashEffect)
            {
                if (Fly_Boolean)
                {
                    FlappyBirdpictureBox1.Image = Properties.Resources.Flappy_Bird_1;
                    Fly_Boolean = false;
                }
                else
                {
                    FlappyBirdpictureBox1.Image = Properties.Resources.Flappy_Bird_2;
                    Fly_Boolean = true;
                }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Çarpışma efekti kontrolü
            if (crashEffect)
            {
                crashEffectTimer++;
                
                // Titreme efekti
                if (crashEffectTimer % 2 == 0)
                {
                    FlappyBirdpictureBox1.Left = originalBirdPosition.X + rand.Next(-3, 4);
                    FlappyBirdpictureBox1.Top = originalBirdPosition.Y + rand.Next(-3, 4);
                }
                else
                {
                    FlappyBirdpictureBox1.Left = originalBirdPosition.X;
                    FlappyBirdpictureBox1.Top = originalBirdPosition.Y;
                }
                
                // Renk değişimi efekti
                if (crashEffectTimer % 4 < 2)
                {
                    // Kırmızı renk efekti için image'i manipüle et
                    FlappyBirdpictureBox1.BackColor = Color.Red;
                }
                else
                {
                    FlappyBirdpictureBox1.BackColor = Color.Transparent;
                }
                
                // Efekt 30 frame sürsün (yaklaşık 0.6 saniye)
                if (crashEffectTimer >= 30)
                {
                    finalizeGameOver();
                }
                return;
            }
            
            if (gameOver) return;
            
            FlappyBirdpictureBox1.Top += gravity;
            
            // Tüm boruları hareket ettir
            for (int i = 0; i < pipes.Count; i++)
            {
                pipes[i].Left -= pipeSpeed;
                
                // Boru ekranın sol tarafından çıktığında sağ tarafa taşı
                if (pipes[i].Left < -100)
                {
                    pipes[i].Left = 1200;
                    
                    // Yeni random yükseklik - sınırlar içinde ve her zaman geçilebilir
                    int minHeight = 180;
                    int maxHeight = 350;
                    int pipeHeight = rand.Next(minHeight, maxHeight);
                    
                    if (i % 2 == 0) // Üst boru
                    {
                        pipes[i].Top = pipeHeight - 400;
                    }
                    else // Alt boru
                    {
                        pipes[i].Top = pipeHeight + 220;
                        score++; // Alt boru geçildiğinde puan arttır
                    }
                }
                
                // Çarpışma kontrolü - biraz daha toleranslı
                Rectangle birdRect = new Rectangle(FlappyBirdpictureBox1.Left + 5, 
                                                 FlappyBirdpictureBox1.Top + 5, 
                                                 FlappyBirdpictureBox1.Width - 10, 
                                                 FlappyBirdpictureBox1.Height - 10);
                if (birdRect.IntersectsWith(pipes[i].Bounds))
                {
                    startCrashEffect();
                    return;
                }
            }
            
            scoreLabel.Text = "Puan: " + score.ToString();
            
            // Zemin ve tavan kontrolü
            if (FlappyBirdpictureBox1.Top < 0 || FlappyBirdpictureBox1.Top > 680)
            {
                startCrashEffect();
                return;
            }

            // Gravity artışı (daha yumuşak)
            if (gravity < 10)
            {
                gravity += 1;
            }
            
            // Zorluk artışı (her 15 puanda)
            if (score > 0 && score % 15 == 0 && pipeSpeed < 7)
            {
                pipeSpeed = 4 + (score / 15);
            }
        }

        private void startCrashEffect()
        {
            crashEffect = true;
            crashEffectTimer = 0;
            originalBirdPosition = FlappyBirdpictureBox1.Location;
            
            // Ses efekti (sistem ses)
            try
            {
                System.Media.SystemSounds.Hand.Play();
            }
            catch
            {
                // Ses çıkmazsa devam et
            }
        }

        private void finalizeGameOver()
        {
            gameTimer.Stop();
            gameOver = true;
            crashEffect = false;
            
            // Kuşu normale döndür
            FlappyBirdpictureBox1.BackColor = Color.Transparent;
            FlappyBirdpictureBox1.Location = originalBirdPosition;
            FlappyBirdpictureBox1.Image = Properties.Resources.Flappy_Bird_1;
            
            scoreLabel.Text = "Puan: " + score.ToString() + " - OYUN BİTTİ!!!";
            instructionsLabel.Text = "Yeniden başlamak için SPACE tuşuna basın";
        }
    }
}
