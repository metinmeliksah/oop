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
        int Target_Y_Location = 800;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void FlappyBirdpictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Flying_timer1_Tick(object sender, EventArgs e)
        {
            if (Fly_Boolean)
            {
                FlappyBirdpictureBox1.Image=Properties.Resources.Flappy_Bird_1;
                Fly_Boolean = false;
            }
            else
            {
                FlappyBirdpictureBox1.Image = Properties.Resources.Flappy_Bird_2;
                Fly_Boolean = true;
            }
        }
    }
}
