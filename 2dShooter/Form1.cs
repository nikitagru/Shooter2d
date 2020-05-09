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

        public Map map = new Map();

        public View view = new View();

        public Model model = new Model();

        Gun gun = new Gun();

        public static Image bullet;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 30;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            Init();
        }


        private void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.A:
                    player.flip = 1;
                    player.isPressA = true;
                    player.isWasPressedA = false;
                    player.isMoving = true;
                    break;
                case Keys.D:
                    player.flip = 0;
                    player.isPressD = true;
                    player.isWasPressedD = false;
                    player.isMoving = true;
                    break;
                case Keys.W:
                    if (player.isFalled)
                    {
                        player.isPressW = true;
                        player.isMoving = true;
                        player.flip = 2;
                    }
                    break;
                case Keys.Space:
                    player.isShooting = true;
                    break;
                default:
                    if (player.isWasPressedA)
                    {
                        player.flip = 3;
                    }
                    if (player.isWasPressedD)
                    {
                        player.flip = 2;
                    }
                    break;
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.isPressW = false;
            player.isPressD = false;
            player.isPressA = false;
            player.isMoving = false;
            
        }

        private void Update(object sender, EventArgs e)
        {
            model.Falling(player, 5, map, this);
            Invalidate();
        }

        private void Init()
        {
            map.Init();
            gun.Init();
            bullet = gun.bulletImage;
            var playerPath = new Bitmap(Properties.Resources.finPlayer1 as Bitmap);
            player = new Entity(310, 100, playerPath);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            map.DrawMap(g);
            view.PlayAnimation(g, player, map);
            view.ShootInit(g, gun, player);
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            if (player.isPressA)
            {
                if (player.posX > this.Width / 2 && player.posX < 32 * 30 - this.Width / 2)
                {
                    map.delta.X += 5;
                }
                model.MovingA(player, -5, 0, map);
                
                player.isWasPressedA = true;
                model.Moving(player, 0, 0);
            }
            if (player.isPressD)
            {
                if (player.posX > this.Width / 2 && player.posX < 32 * 30 - this.Width / 2)
                {
                    map.delta.X -= 5;
                }
                model.MovingD(player, 5, 0, map);
                
                player.isWasPressedD = true;
                model.Moving(player, 0, 0);
            }
            if (player.isPressW)
            {
                model.MovingW(player, -13, map, this);
                model.Moving(player, 0, 0);
            }
            if (player.isShooting)
            {
                this.Paint += new PaintEventHandler(Shoot);
            }
        }
        private void Shoot(object sender, PaintEventArgs e)
        {
            view.ShootAnimation(map);
        }
    }
}
