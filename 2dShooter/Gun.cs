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
        public int width;       //Ширина выстрела
        public int height;      //Высота выстрела

        public Image bulletImage;       //Изображение выстрела

        /// <summary>
        /// Инициализация оружия
        /// </summary>
        public void Init()
        {
            bulletImage = new Bitmap(Properties.Resources.bulletFin as Bitmap);
            width = bulletImage.Width;
            height = bulletImage.Height;
        }

    }
}
