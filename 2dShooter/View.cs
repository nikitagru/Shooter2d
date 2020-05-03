using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace _2dShooter
{
    public class View
    {
        static Image playerImg = new Bitmap(Properties.Resources.player1 as Bitmap);

        public Entity player = new Entity(310, 310, playerImg);

        public Image CurrentFrame(Image image, Rectangle section)
        {
            Bitmap bitmap = image as Bitmap;

            Bitmap player = bitmap.Clone(section, bitmap.PixelFormat);

            return player;
        }

        //public View(Bitmap bitmap)
        //{
        //    playerImg = bitmap;
        //}
    }
}
