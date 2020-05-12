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
        public Entity player;       //Сущность игрока
        public Entity enemy;        //Сущность врага

        public Map map = new Map();     //Карта

        public View view = new View();      

        public Model model = new Model();

        Gun gun = new Gun();        //Оружие
        Gun enemygun = new Gun();

        public static Image bullet;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 30;
            timer1.Tick += new EventHandler(Update);        //Передача метода обновления карты через каждое значение timer1.Interval

            KeyDown += new KeyEventHandler(OnPress);        //Обработка метода нажатия на кнопку
            KeyUp += new KeyEventHandler(OnKeyUp);      //Обработка метода отпускания кнопки
            Init();     //Инициализация формы
        }

        /// <summary>
        /// Обработка нажатий на каждую из кнопок управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPress(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.A:
                    player.isPressA = true;
                    player.isMoving = true;
                    player.flip = 1;
                    player.idleFlip = 1;
                    break;
                case Keys.D:
                    player.isPressD = true;
                    player.isMoving = true;
                    player.flip = 0;
                    player.idleFlip = 0;
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
        /// <summary>
        /// Обработка отпускания кнопки управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.isPressW = false;
            player.isPressD = false;
            player.isPressA = false;
            player.isMoving = false;
            
        }
        /// <summary>
        /// Обновление формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Update(object sender, EventArgs e)
        {
            model.Falling(player, 5, map, this);
            model.Falling(enemy, 5, map, this);
            model.EnemyTracking(player,enemy,this, map);
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
            }
            label1.Text = player.health.ToString();
            Invalidate();
        }
        /// <summary>
        /// Инициализация формы
        /// </summary>
        private void Init()
        {
            map.Init();     //Инициализация карты
            gun.Init();     //Инициализация оружия
            enemygun.Init();
            bullet = gun.bulletImage;       //Получение изображения выстрела
            var playerPath = new Bitmap(Properties.Resources.finPlayer1 as Bitmap);     //Получение картинки спрайтов с игроком
            player = new Entity(150, 100, playerPath);      //Инициализация экземпляра класса Entity - игрока
            enemy = new Entity(750, 100, playerPath);       //Инициализация экземпляра класса Entity - врага
            timer1.Start();
        }
        /// <summary>
        /// Отрисовка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            map.DrawMap(g);     //Отрисовка карты
            view.PlayAnimation(g, player, map);     //Отрисовка анимации игрока
            view.PlayAnimation(g, enemy, map);      //Отрисовка анимации врага
            //view.ShootInit(g, gun, player);         //Отрисовка оружия
            //view.ShootInit(g, enemygun, enemy);
        }
        /// <summary>
        /// Обработчик прохождения таймером промежутка timer1.Interval. Обработчик нажатий на кнопки управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            if (player.isPressA)        //Нажатие на кнопку А
            {
                if (player.posX > this.Width / 2 && player.posX < 32 * 34 - this.Width / 2)
                {
                    map.delta.X += 6;
                }
                model.MovingA(player, -6, 0, map);
                model.Moving(player, 0, 0);
            }
            if (player.isPressD)        //Нажатие на кнопку D
            {
                if (player.posX > this.Width / 2 && player.posX < 32 * 34 - this.Width / 2)
                {
                    map.delta.X -= 6;
                }
                model.MovingD(player, 6, 0, map);
                model.Moving(player, 0, 0);
            }
            if (player.isPressW)        //Нажатие на кнопку W
            {
                model.MovingW(player, -13, map, this);
                model.Moving(player, 0, 0);
            }
            if (player.isShooting)      //Отрисовка выстрела
            {
                this.Paint += new PaintEventHandler(Shoot);
                model.ShootInEnnemy(player, enemy, this);
            }
            if (enemy.isShooting)      //Отрисовка выстрела
            {
                this.Paint += new PaintEventHandler(ShootEnemy);
            }

        }
        /// <summary>
        /// Воспроизведение анимации выстрела.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shoot(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, gun, player);
        }

        private void ShootEnemy(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemygun, enemy);
        }

    }
}
