using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dShooter
{
    public class Gun
    {
        public int width;
        public int height;

        public int currentFrame;
        public int frameLimit = 6;

        public int posX;

        public Image bulletImage;

        public void Init()
        {
            bulletImage = new Bitmap(Properties.Resources.bulletNew as Bitmap);
            width = bulletImage.Width;
            height = bulletImage.Height;
        }

    }
}
