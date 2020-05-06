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
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 30;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
            Init();



        }

        //private void ShowBullet(Entity entity, Gun gun, Map map)
        //{
        //    PictureBox bullet = new PictureBox();
        //    bullet.Location = new Point(entity.posX + 40, entity.posY + 17);
        //    bullet.Image = 
        //    bullet.Size = new Size(gun.width, gun.height);

        //    var mapArr = map.map;
        //    var mapY = Math.Abs(entity.posY) / map.linkSize;
        //    var mapX = Math.Abs(entity.posX) / map.linkSize;
        //    var bulletX = entity.posX + 40;
        //    var bulletY = entity.posY + 17;
        //    while (mapArr[mapY, mapX] == 1 || mapArr[mapY, mapX] == 6)
        //    {
        //        bullet.Location = new Point(bulletX, bulletY);
        //        bulletX++;
        //        mapY++;
        //    }
        //}

        private void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.A:
                    player.isPressA = true;
                    player.isMoving = true;
                    player.flip = 1;
                    break;
                case Keys.D:
                    player.isPressD = true;
                    player.isMoving = true;
                    player.flip = 0;
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
            model.Falling(player, 5, map);
            Invalidate();
        }

        private void Init()
        {
            map.Init();
            gun.Init();
            var playerPath = new Bitmap(Properties.Resources.finPlayer1 as Bitmap);
            player = new Entity(310, 100, playerPath);
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            map.DrawMap(g);
            view.PlayAnimation(g, player);
            view.ShootAnimation(g, gun, map, player);
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            if (player.isPressA)
            {
                model.MovingA(player, -5, 0, map);
                model.Moving(player, 0, 0);
            }
            if (player.isPressD)
            {
                model.MovingD(player, 5, 0, map);
                model.Moving(player, 0, 0);
            }
            if (player.isPressW)
            {
                model.MovingW(player, -13, map);
                model.Moving(player, 0, 0);
            }
        }
    }
}
