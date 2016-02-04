using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Direction {Down, Up, Left, Right};
    class Settings
    {
        public static int Width { set; get; }
        public static int Heigth { set; get; }
        public static int Speed { set; get; }
        public static int Score { set; get; }
        public static int Points { set; get; }
        public static bool GameOver { set; get; }
        public static Direction direction { set; get; }

        public Settings()
        {
            Width = 20;
            Heigth = 20;
            Speed = 15;
            Points = 10;
            GameOver = false;
            direction = Direction.Down;
        }
    }
}
