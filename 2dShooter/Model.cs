using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dShooter
{
    static class Model
    {

        public static void Moving(int posX, int posY, int dirX, int dirY) 
        {
            posX += dirX;
            posY += dirY;
        }
    }
}
