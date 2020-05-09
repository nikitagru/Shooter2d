using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dShooter
{
    public class Entity
    {
        public int posX;
        public int posY;

        public int maxJumpHeight = 10;
        public int currentJumpHeight = 0;

        public int currentAnimation;
        public int currentLimit = 7;
        
        public int width = 49;
        public int height = 45;
        public int flip;

        public bool isPressW;
        public bool isPressA;
        public bool isWasPressedA;
        public bool isPressD;
        public bool isWasPressedD;
        public bool isMoving;
        public bool isFalled;
        public bool isJumped;
        public bool isShooting;

        public Image entityImage;

        public Entity(int posX, int posY, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.entityImage = spriteSheet;
            this.currentAnimation = 0;
            flip = 0;
            this.isMoving = false;
            this.isFalled = true;
            this.isJumped = false;
            this.isShooting = false;
        }
    }
}
