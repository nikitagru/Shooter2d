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

        public int dirX;
        public int dirY;

        public int width = 49;
        public int height = 48;

        public Image entityImage;

        public Entity(int posX, int posY, Image spriteSheet)
        {
            this.posX = posX;
            this.posY = posY;
            this.entityImage = spriteSheet;
        }
    }
}
