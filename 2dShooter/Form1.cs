using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dShooter
{
    public partial class Form1 : Form
    {
        public Entity player;

        public View view = new View();
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            //KeyUp += new KeyEventHandler(OnKeyUp);
            Init();
        }

        private void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.A:
                    
                    break;
                case Keys.D:

                    break;
                case Keys.W:

                    break;
                case Keys.S:

                    break;
            }
        }

        //private void OnKeyUp(object sender, KeyEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Update(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Init()
        {
            var playerPath = new Bitmap(Properties.Resources.player1 as Bitmap);
            player = new Entity(310, 310, playerPath);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            var playerImage = view.CurrentFrame(player.entityImage, new Rectangle(0, 0, player.width, player.height));

            g.DrawImage(playerImage, new PointF(player.posX, player.posY));
        }
    }
}
