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

        private bool isOpenDead = false;

        #region дичь, которую надо переделать
        public Entity enemy2;
        public Entity enemy3;
        public Entity enemy4;
        public Entity enemy5;
        public Entity enemy6;
        public Entity enemy7;
        public Entity enemy8;
        #endregion

        public Map map = new Map();     //Карта

        public View view = new View();      

        public Model model = new Model();

        Gun gun = new Gun();        //Оружие
        Gun enemygun = new Gun();
        #region дичь, которую надо переделать
        Gun enemy2gun = new Gun();
        Gun enemy3gun = new Gun();
        Gun enemy4gun = new Gun();
        Gun enemy5gun = new Gun();
        Gun enemy6gun = new Gun();
        Gun enemy7gun = new Gun();
        Gun enemy8gun = new Gun();
        #endregion

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

        private void Dead()
        {
            var deadForm = new Dead();
            deadForm.Show();
            this.Hide();
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
            model.EnemyTracking(player, enemy, this, map);
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
            }
            #region дичь, которую надо переделать
            model.Falling(enemy2, 5, map, this);
            model.EnemyTracking(player, enemy2, this, map);
            if (enemy2.health <= 0)
            {
                enemy2.isAlive = false;
            }

            model.Falling(enemy3, 5, map, this);
            model.EnemyTracking(player, enemy3, this, map);
            if (enemy3.health <= 0)
            {
                enemy3.isAlive = false;
            }

            model.Falling(enemy4, 5, map, this);
            model.EnemyTracking(player, enemy4, this, map);
            if (enemy4.health <= 0)
            {
                enemy4.isAlive = false;
            }

            model.Falling(enemy5, 5, map, this);
            model.EnemyTracking(player, enemy5, this, map);
            if (enemy5.health <= 0)
            {
                enemy5.isAlive = false;
            }

            model.Falling(enemy6, 5, map, this);
            model.EnemyTracking(player, enemy6, this, map);
            if (enemy6.health <= 0)
            {
                enemy6.isAlive = false;
            }

            model.Falling(enemy7, 5, map, this);
            model.EnemyTracking(player, enemy7, this, map);
            if (enemy7.health <= 0)
            {
                enemy7.isAlive = false;
            }

            //model.Falling(enemy8, 5, map, this);
            //model.EnemyTracking(player, enemy8, this, map);
            //if (enemy8.health <= 0)
            //{
            //    enemy8.isAlive = false;
            //}
            #endregion
            label1.Text = player.health.ToString();
            label2.Text = player.posX.ToString();
            label3.Text = player.posY.ToString();
            if (player.health < 1)
            {
                player.isAlive = false;
                if (!isOpenDead)
                {
                    Dead();
                    isOpenDead = true;
                }
            }
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

            #region дичь, которую надо переделать
            enemy2gun.Init();
            enemy3gun.Init();
            enemy4gun.Init();
            enemy5gun.Init();
            enemy6gun.Init();
            enemy7gun.Init();
            //enemy8gun.Init();
            #endregion

            bullet = gun.bulletImage;       //Получение изображения выстрела
            var playerPath = new Bitmap(Properties.Resources.finPlayer1 as Bitmap);     //Получение картинки спрайтов с игроком
            player = new Entity(150, 100, playerPath);      //Инициализация экземпляра класса Entity - игрока
            player.isEnemy = false;
            enemy = new Entity(750, 100, playerPath);       //Инициализация экземпляра класса Entity - врага

            enemy2 = new Entity(636, 310, playerPath);
            enemy3 = new Entity(558, 515, playerPath);
            enemy4 = new Entity(888, 515, playerPath);
            enemy5 = new Entity(930, 730, playerPath);
            enemy6 = new Entity(324, 730, playerPath);
            enemy7 = new Entity(60, 610, playerPath);
            //enemy8 = new Entity(264, 510, playerPath);

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
            view.PlayAnimation(g, enemy2, map);
            view.PlayAnimation(g, enemy3, map);
            view.PlayAnimation(g, enemy4, map);
            view.PlayAnimation(g, enemy5, map);
            view.PlayAnimation(g, enemy6, map);
            view.PlayAnimation(g, enemy7, map);
            //view.PlayAnimation(g, enemy8, map);
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
                model.ShootInEnnemy(player, enemy2, this);
                model.ShootInEnnemy(player, enemy3, this);
                model.ShootInEnnemy(player, enemy4, this);
                model.ShootInEnnemy(player, enemy5, this);
                model.ShootInEnnemy(player, enemy6, this);
                model.ShootInEnnemy(player, enemy7, this);
                //model.ShootInEnnemy(player, enemy8, this);
            }
            if (enemy.isShooting)      //Отрисовка выстрела
            {
                this.Paint += new PaintEventHandler(ShootEnemy);
            }
            #region дичь, которую надо исправить
            if (enemy2.isShooting)
            {
                this.Paint += new PaintEventHandler(ShootEnemy2);
            }
            if (enemy3.isShooting)
            {
                this.Paint += new PaintEventHandler(ShootEnemy3);
            }
            if (enemy4.isShooting)
            {
                this.Paint += new PaintEventHandler(ShootEnemy4);
            }
            if (enemy5.isShooting)
            {
                this.Paint += new PaintEventHandler(ShootEnemy5);
            }
            if (enemy6.isShooting)
            {
                this.Paint += new PaintEventHandler(ShootEnemy6);
            }
            if (enemy7.isShooting)
            {
                this.Paint += new PaintEventHandler(ShootEnemy7);
            }
            //if (enemy8.isShooting)
            //{
            //    this.Paint += new PaintEventHandler(ShootEnemy8);
            //}
            #endregion
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
        #region дичь, которую надо исправить
        private void ShootEnemy2(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy2gun, enemy2);
        }
        private void ShootEnemy3(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy3gun, enemy3);
        }
        private void ShootEnemy4(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy4gun, enemy4);
        }
        private void ShootEnemy5(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy5gun, enemy5);
        }
        private void ShootEnemy6(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy6gun, enemy6);
        }
        private void ShootEnemy7(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy7gun, enemy7);
        }
        private void ShootEnemy8(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            view.ShootAnimation(map, g, enemy8gun, enemy8);
        }
        #endregion
    }
}
