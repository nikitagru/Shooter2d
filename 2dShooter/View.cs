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
        private Entity gunOwner;
        private Graphics weaponGraphics;
        private Gun weapon;

        private int posX;
        private int posY;

        

        public Image CurrentFrame(Image image, Rectangle section)
        {
            Bitmap bitmap = image as Bitmap;

            Bitmap player = bitmap.Clone(section, bitmap.PixelFormat);

            return player;
        }

        public void PlayAnimation(Graphics g, Entity entity, Map map)
        {
            if (entity.isMoving)
            {
                if (entity.isPressW)
                {
                    entity.currentAnimation = 1;
                    if (entity.isPressA)
                    {
                        entity.flip = 3;
                    } else if (entity.isPressD)
                    {
                        entity.flip = 2;
                    }

                    var jumpFrame = CurrentFrame(entity.entityImage, new Rectangle(49 * entity.currentAnimation, 45 * entity.flip, entity.width, entity.height));

                    g.DrawImage(jumpFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));

                } else if (entity.currentAnimation < entity.currentLimit)
                {
                    entity.currentAnimation++;
                }
                else
                {
                    entity.currentAnimation = 0;
                }
                var currentFrame = CurrentFrame(entity.entityImage, new Rectangle(49 * entity.currentAnimation, 45 * entity.flip, entity.width, entity.height));

                g.DrawImage(currentFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));
            } else
            {
                var currentFrame = CurrentFrame(entity.entityImage, new Rectangle(49 * 0, 45 * 2, entity.width, entity.height));
                g.DrawImage(currentFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));
            }
        }

        //public void ShootAnimation(Graphics g, Gun gun, Map map, Entity entity)
        //{
        //    if (entity.isShooting)
        //    {
        //        PictureBox bullet = new PictureBox();
        //        bullet.Location = new Point(entity.posX + 40, entity.posY + 17);
        //        bullet.Image = gun.bulletImage;
        //        bullet.Size = new Size(gun.width, gun.height);

        //        var mapArr = map.map;
        //        var mapY = Math.Abs(entity.posY) / map.linkSize;
        //        var mapX = Math.Abs(entity.posX) / map.linkSize;
        //        var bulletX = entity.posX + 40;
        //        var bulletY = entity.posY + 17;
        //        while (mapArr[mapY, mapX] == 1 || mapArr[mapY, mapX] == 6)
        //        {
        //            bullet.Location = new Point(bulletX, bulletY);
        //            bulletX++;
        //            mapY = Math.Abs(bulletX + 1) / map.linkSize;
        //        }
        //    }
        //}

        public void ShootAnimation(Map map)
        {
            if (gunOwner.isShooting)
            {
                var currentFrame = weapon.bulletImage;
                var bulletX = gunOwner.posX + 40;
                
                weaponGraphics.DrawImage(currentFrame, new Point(bulletX + map.delta.X, gunOwner.posY + 15 + map.delta.Y));
                
            }
            gunOwner.isShooting = false;
        }

        public void ShootInit(Graphics g, Gun gun, Entity entity)
        {
            gunOwner = entity;
            weapon = gun;
            weaponGraphics = g;
            
        }

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
