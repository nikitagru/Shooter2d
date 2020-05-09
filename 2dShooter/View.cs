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
            } else
            {
                var idleImage = new Bitmap(Properties.Resources.idlePlayer as Bitmap);
                var currentFrame = CurrentFrame(idleImage, new Rectangle(49 * 0, 45 * entity.idleFlip, entity.width - 4, entity.height));
                g.DrawImage(currentFrame, new Point(entity.posX + map.delta.X, entity.posY + map.delta.Y));
            }
        }

        public void ShootAnimation(Map map)
        {
            if (gunOwner.isShooting)
            {
                var currentFrame = CurrentFrame(weapon.bulletImage, new Rectangle(0, 10 * gunOwner.flip, 7, 10));
                var bulletX = gunOwner.posX + 37 - (gunOwner.flip * 45);

                if (gunOwner.flip != 0)
                {
                    bulletX += 7;
                }
                
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
