using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var mapArr = map.map;
            
            if (mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] != 1
                && mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] != 6)
            {
                if (mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] == 4)
                    return false;
                return false;
            }
            return true;
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
            if (IsCanMoving(map, entity, 0, dirY) && entity.isFalled)
            {
                for(var i = 0; i < 12; i++)
                {
                    entity.posY += dirY;
                    if (entity.posY > form.Height / 2 + 10 && entity.posY < 32 * 30 - form.Height / 2 + 10)
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
            if (mapArr[(Math.Abs(entity.posY) + dirX + 12) / map.linkSize, Math.Abs(entity.posX) / map.linkSize] != 6)
            {
                entity.posY += dirX;
                if (entity.posY > form.Height / 2 + 80 && entity.posY < 32 * 30 - form.Height / 2 + 80)
                {
                    map.delta.Y -= 5;
                }
                
            } else
            {
                entity.isFalled = true;
            }
            
        }

    }
}
