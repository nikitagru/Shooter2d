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
        public int posX;                        //Позиция по X
        public int posY;                        //Позиция по Y

        public int maxJumpHeight = 10;          //Максимальная высота прыжка
        public int currentJumpHeight = 0;       //Нынешняя пройденная высота прыжком

        public int currentAnimation;            //Нынешняя анимация для отрисовки движения
        public int currentLimit = 7;            //Лимит кадров анимации движения
        
        public int width = 49;                  //Ширина персонажа
        public int height = 45;                 //Высота персонажа
        public int flip;                        //Поворот игрока в стороны для анимации движения(право, лево)
        public int idleFlip;                    //Поворот игрока в стороны для анимации спокойствия(право, лево)

        public int health;

        public bool isPressW;                   
        public bool isPressA;
        public bool isPressD;
        public bool isMoving;
        public bool isFalled;
        public bool isJumped;
        public bool isShooting;
        public bool isAlive;
        public bool isEnemy;
        public bool end = false;

        public Image entityImage;               //Набор спрайтов для анимации движения персонажа

        /// <summary>
        /// Конструктор класса сущности
        /// </summary>
        /// <param name="posX">Позиция по X</param>
        /// <param name="posY">Позиция по Y</param>
        /// <param name="spriteSheet">Набор спрайтов для анимации движения</param>
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
            this.idleFlip = 0;
            this.health = 100;
            this.isAlive = true;
            this.isEnemy = true;
        }
    }
}
