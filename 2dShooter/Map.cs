﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2dShooter
{
    public class Map
    {
        public View view = new View();

        public static int mapWidth = 20;        //Ширина карты(эквивалент координате Y)
        public static int mapHeight = 30;       //Высота карты(эквивалент координате X)
        public static int cellsize = 32;        //Размер отрисовки каждого кадра
        public int linkSize = cellsize;         //Ссылка на переменную cellsize 

        public int[,] map = new int[mapWidth, mapHeight];       //Массив карты

        public Image backgroung;        //Картинка заднего фона
        public Image main;              //Картинка области, по которой может ходить персонаж
        public Image wall;              //Горизонтальная стена
        public Image vertWall;          //Вертикальная стена
        public Point delta;             //Смещение отрисовки(следящая камера)

        /// <summary>
        /// Инициализация карты
        /// </summary>
        public void Init()
        {
            map = GetMap();
            backgroung = new Bitmap(Properties.Resources.backgroundNew as Bitmap);
            main = view.CurrentFrame(new Bitmap(Properties.Resources.mainPlace as Bitmap),
                new Rectangle(cellsize + 4, 0, 32, 32));
            wall = view.CurrentFrame(new Bitmap(Properties.Resources.mainPlace as Bitmap),
                new Rectangle(0, 0, 32, 32));
            vertWall = view.CurrentFrame(new Bitmap(Properties.Resources.mainPlaceVert as Bitmap),
                new Rectangle(0, 0, 32, 32));
            delta = new Point(0, 0);
        }


        /// <summary>
        /// Получение массива карты
        /// </summary>
        /// <returns></returns>
        private int[,] GetMap()
        {
            return new int[,]
            {
                {5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,5}, 
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,1,1,1,1,1,1,1,1,1,4,5},
                {5,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,5},
                {5,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,6,1,1,1,1,1,1,1,1,1,4,5},
                {5,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1,4,5}
            };

        }

        /// <summary>
        /// Отрисовка карты
        /// </summary>
        /// <param name="g">Графика</param>
        public void DrawMap(Graphics g)
        {
            for(var i = 0; i < mapWidth; i++)
            {
                for(var j = 0; j < mapHeight; j++)
                {
                    if (map[i, j] == 1)
                    {
                        g.DrawImage(backgroung, new Point(j * cellsize + delta.X, i * cellsize + delta.Y));
                    }
                    if (map[i, j] == 4)
                    {
                        g.DrawImage(backgroung, new Point(j * cellsize + delta.X, i * cellsize + delta.Y));
                    }
                    if (map[i, j] == 6)
                    {
                        g.DrawImage(backgroung, new Point(j * cellsize + delta.X, i * cellsize + delta.Y));
                    }
                    if (map[i, j] == 2)
                    {
                        g.DrawImage(main, new Point(j * cellsize + delta.X, i * cellsize + delta.Y));
                    }
                    if (map[i, j] == 3)
                    {
                        g.DrawImage(wall, new Point(j * cellsize + delta.X, i * cellsize + delta.Y));
                    }
                    if (map[i, j] == 5)
                    {
                        g.DrawImage(vertWall, new Point(j * cellsize + delta.X, i * cellsize + delta.Y));
                    }
                }
            }
        }
    }
}
