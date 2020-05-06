using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dShooter
{
    public class Model
    {
        public bool IsCanMoving(Map map, Entity entity, int dirX, int dirY)
        {
            var mapArr = map.map;
            
            if (mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] != 1)
            {
                if (mapArr[(entity.posY + dirY) / map.linkSize, (entity.posX + dirX) / map.linkSize] == 4)
                    return false;
                return false;
            }
            return true;
        }

        public void MovingA(Entity entity, int dirX, int dirY, Map map) 
        {
            if (IsCanMoving(map, entity, dirX, dirY))
            {
                entity.posX += dirX;
                entity.posY += dirY;
            }
            
        }
        public void MovingD(Entity entity, int dirX, int dirY, Map map)
        {
            if (IsCanMoving(map, entity, dirX, dirY))
            {
                entity.posX += dirX;
                entity.posY += dirY;
            }
        }
        public void MovingW(Entity entity, int dirY, Map map)
        {
            if (IsCanMoving(map, entity, 0, dirY) && entity.isFalled)
            {
                for(var i = 0; i < 12; i++)
                {
                    entity.posY += dirY;
                    System.Threading.Thread.Sleep(8);
                }
                
                entity.isJumped = true;
            }
                
            entity.isFalled = false;
        }

        public void Moving(Entity entity, int dirX, int dirY)
        { 
            entity.posX += dirX;
            entity.posY += dirY;
        }

        public void Falling(Entity entity, int dirX, Map map)
        {
            var mapArr = map.map;
            if (mapArr[(Math.Abs(entity.posY) + dirX + 12) / map.linkSize, Math.Abs(entity.posX) / map.linkSize] != 6)
            {
                entity.posY += dirX;
            } else
            {
                entity.isFalled = true;
            }
            
        }

        //public void Shoting(Entity entity, Gun gun, Map map)
        //{
        //    var mapArr = map.map;
        //    var mapY = entity.posY / map.linkSize;
        //    var mapX = entity.posX / map.linkSize;
        //    gun.posX = entity.posY;

        //    while (mapArr[mapY, mapX + 1] == 1)
        //    {
        //        gun.posX++;
        //        mapX++;
        //    }
        //}
    }
}
