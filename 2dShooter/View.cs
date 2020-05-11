using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace _2dShooter
{
    public class View
    {
        private Entity gunOwner;        //Владелец оружия
        private Graphics weaponGraphics;        //Графика для оружия
        private Gun weapon;     //Экземпляр класса Gun - оружие

        private int posX;       //Позиция воспроизведения выстрела по Х
        private int posY;       //Позиция воспроизведения выстрела по Y

        /// <summary>
        /// Получение нужного изображения из набора спрайтов
        /// </summary>
        /// <param name="image">Исходное изображение, из которого будет вырезаться спрайт</param>
        /// <param name="section">Размер и позиция вырезаемой области</param>
        /// <returns></returns>
        public Image CurrentFrame(Image image, Rectangle section)
        {
            Bitmap bitmap = image as Bitmap;

            Bitmap player = bitmap.Clone(section, bitmap.PixelFormat);
            
            return player;
        }
        /// <summary>
        /// Проигрывание анимации персонажа
        /// </summary>
        /// <param name="g">Графика</param>
        /// <param name="entity">Объект, к которому применяется анимация</param>
        /// <param name="map">Карта уровня</param>
        public void PlayAnimation(Graphics g, Entity entity, Map map)
        {
            if (entity.isMoving)        //Анимация обычного движения
            {
                if (entity.isPressW)        //Анимация прыжка
                {
                    entity.currentAnimation = 1;
                    if (entity.isPressA)
                    {
                        entity.flip = 3;
                        entity.idleFlip = 1;
                    }
                    else if (entity.isPressD)
                    {
                        entity.flip = 2;
                        entity.idleFlip = 0;
                    }

                    var jumpFrame = CurrentFrame(entity.entityImage, new Rectangle(49 * entity.currentAnimation, 45 * entity.flip, entity.width, entity.height));
                    
                    g.DrawImage(jumpFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));

                }
                else if (entity.currentAnimation < entity.currentLimit)
                {
                    entity.currentAnimation++;
                }
                else
                {
                    entity.currentAnimation = 0;
                }
                var currentFrame = CurrentFrame(entity.entityImage, new Rectangle(49 * entity.currentAnimation, 45 * entity.flip, entity.width, entity.height));

                g.DrawImage(currentFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));
            } else         //Анимация спокойствия
            {
                var idleImage = new Bitmap(Properties.Resources.idlePlayer as Bitmap);      //Набор спрайтов с кадрами для анимации спокойствия
                var currentFrame = CurrentFrame(idleImage, new Rectangle(49 * 0, 45 * entity.idleFlip, entity.width - 4, entity.height));
                g.DrawImage(currentFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));
            }
        }
        /// <summary>
        /// Анимация выстрела
        /// </summary>
        /// <param name="map">Карта уровня</param>
        public void ShootAnimation(Map map, Graphics g, Gun gun, Entity entity)
        {
            if (entity.isShooting)        //Если нажата кнопка выстрела
            {
                var currentFrame = CurrentFrame(gun.bulletImage, new Rectangle(0, 10 * entity.flip, 7, 10));
                var bulletX = entity.posX + 37 - (entity.flip * 45);

                if (entity.flip != 0)
                {
                    bulletX += 7;
                }
                
                g.DrawImage(currentFrame, new Point(bulletX + map.delta.X, entity.posY + 15 + map.delta.Y));
            }
            entity.isShooting = false;        //Прекращение выстрела
        }
        /// <summary>
        /// Инициализация полей для анимации выстрела
        /// </summary>
        /// <param name="g">Графика выстрела</param>
        /// <param name="gun">Оружие</param>
        /// <param name="entity">Персонаж(владелец оружия)</param>
        //public void ShootInit(Graphics g, Gun gun, Entity entity)
        //{
        //    gunOwner = entity;
        //    weapon = gun;
        //    weaponGraphics = g;
        //}
        /// <summary>
        /// Воспроизведение выстрела
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="gun"></param>
        /// <param name="g"></param>
        public void Shooting(Entity entity, Gun gun, Graphics g)
        {
            posX = entity.posX + 40;
            posY = entity.posY + 15;
            var spaceFrame = new Bitmap(Properties.Resources.space as Bitmap);
            var currentFrame = gun.bulletImage;
            g.DrawImage(currentFrame, new Point(posX, posY));
            g.DrawImage(spaceFrame, new Point(posX, posY));
        }

    }
}
