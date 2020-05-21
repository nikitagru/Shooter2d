using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dShooter
{
    public partial class MainMenu : Form
    {
        private SoundPlayer mainMenu;

        public MainMenu()
        {
            InitializeComponent();
            this.Size = new Size(700, 700);
            PlayMusic();
        }

        public void PlayMusic()
        {
            mainMenu = new SoundPlayer(Properties.Resources.Eternal1);
            mainMenu.Play();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            form1.Show();
            mainMenu.Stop();
            this.Hide();
        }
    }
}
