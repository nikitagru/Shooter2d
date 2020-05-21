using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _2dShooter
{
    public class Model
    {
        /// <summary>
        /// Проверка может ли персонаж двигаться дальше с встроенной конвертацией координат формы к координатам массива карты.
        /// </summary>
        /// <param name="map">Карта уровня</param>
        /// <param name="entity">Персонаж</param>
        /// <param name="dirX">Направление по X</param>
        /// <param name="dirY">Направление по Y</param>
        /// <returns></returns>
        public bool IsCanMoving(Map map, Entity entity, int dirX, int dirY)
        {
            if (entity.isAlive)
            {
                var mapArr = map.map;

                if (mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] != 1
                    && mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] != 6
                    && mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] != 8)
                {
                    if (mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] == 4)
                        return false;
                    return false;
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Движение при нажатии на клавишу A
        /// </summary>
        /// <param name="entity">Персонаж</param>
        /// <param name="dirX">Направление по X</param>
        /// <param name="dirY">Направление по Y</param>
        /// <param name="map">Карта уровня</param>
        public void MovingA(Entity entity, int dirX, int dirY, Map map) 
        {
            if (IsCanMoving(map, entity, dirX, dirY))
            {
                entity.posX += dirX;
                entity.posY += dirY;
                TakeHealth(entity, map);
            }
            
        }

        /// <summary>
        /// Движение при нажатии на клавишу D
        /// </summary>
        /// <param name="entity">Персонаж</param>
        /// <param name="dirX">Направление по X</param>
        /// <param name="dirY">Направление по Y</param>
        /// <param name="map">Карта уровня</param>
        public void MovingD(Entity entity, int dirX, int dirY, Map map)
        {
            if (IsCanMoving(map, entity, dirX, dirY))
            {
                entity.posX += dirX;
                entity.posY += dirY;
                TakeHealth(entity, map);
            }
        }

        /// <summary>
        /// Движение при нажатии на клавишу W
        /// </summary>
        /// <param name="entity">Персонаж</param>
        /// <param name="dirY">Направление по Y</param>
        /// <param name="map">Карта уровня</param>
        /// <param name="form">Главная форма игры</param>
        public void MovingW(Entity entity, int dirY, Map map, Form1 form)
        {
            
            for(var i = 0; i < 12; i++)
            {
                if (IsCanMoving(map, entity, 0, dirY) && entity.isFalled)
                {
                    entity.posY += dirY;
                    if (entity.posY > form.Height / 2 && entity.posY < 32 * 33 - form.Height / 2)
                    {
                        map.delta.Y -= dirY;
                    }
                    
                }
                entity.isJumped = true;
            }
                
            entity.isFalled = false;
        }

        /// <summary>
        /// Окончание движения
        /// </summary>
        /// <param name="entity">Персонаж</param>
        /// <param name="dirX">Направление по X</param>
        /// <param name="dirY">Направление по Y</param>
        public void Moving(Entity entity, int dirX, int dirY)
        { 
            entity.posX += dirX;
            entity.posY += dirY;
        }
        /// <summary>
        /// Ускороние свободного падения.
        /// </summary>
        /// <param name="entity">Персонаж</param>
        /// <param name="dirX">Направление по X</param>
        /// <param name="map">Карта уровня</param>
        /// <param name="form">Главная форма игры</param>
        public void Falling(Entity entity, int dirX, Map map, Form1 form)
        {
            var mapArr = map.map;
            if (mapArr[(Math.Abs(entity.posY) + dirX + 12) / map.linkSize, Math.Abs(entity.posX) / map.linkSize] != 6
                && mapArr[(Math.Abs(entity.posY) + dirX + 12) / map.linkSize, Math.Abs(entity.posX) / map.linkSize] != 0)
            {
                entity.posY += dirX;
                if (!entity.isEnemy)
                if (entity.posY > form.Height / 2 && entity.posY < 32 * 33 - form.Height / 2)
                {
                    map.delta.Y -= 5;
                }
            } else
            {
                entity.isFalled = true;
            }
        }

        public void EnemyTracking(Entity player, Entity enemy, Form1 form, Map map)
        {
            if (player.isAlive)
            {
                if (Math.Abs(player.posX - enemy.posX) <= form.Width / 2 && Math.Abs(player.posY - enemy.posY) < 100 && enemy.isAlive)
                {
                    if (player.posX < enemy.posX)
                    {
                        enemy.flip = 1;
                        enemy.isMoving = true;
                        MovingA(enemy, -3, 0, map);
                    }
                    else if (player.posX > enemy.posX)
                    {
                        enemy.flip = 0;
                        enemy.isMoving = true;
                        MovingD(enemy, 3, 0, map);
                    }
                    if (Math.Abs(player.posX - enemy.posX) < form.Width / 2 && Math.Abs(player.posY - enemy.posY) < 100 && enemy.isAlive)
                    {

                        enemy.isShooting = true;
                        player.health -= 1;

                    }

                }
            }
        }

        public void ShootInEnnemy(Entity player, Entity enemy, Form1 form)
        {
            if (Math.Abs(player.posX - enemy.posX) < form.Width / 2 && Math.Abs(player.posY - enemy.posY) < 100)
            {
                enemy.health -= 50;
            }
        }

        private void TakeHealth(Entity player, Map map)
        {
            var mapArr = map.map;

            if (mapArr[(player.posY) / map.linkSize, (player.posX) / map.linkSize] == 8)
            {
                if (player.health >= 50)
                {
                    player.health = 100;
                    mapArr[(player.posY) / map.linkSize, (player.posX) / map.linkSize] = 1;
                    mapArr[((player.posY) / map.linkSize) - 32, (player.posX) / map.linkSize] = 1;
                } else
                {
                    player.health += 50;
                    mapArr[(player.posY) / map.linkSize, (player.posX) / map.linkSize] = 1;
                    mapArr[((player.posY) / map.linkSize) - 32, (player.posX) / map.linkSize] = 1;
                }
                
            }
        }
    }
}
