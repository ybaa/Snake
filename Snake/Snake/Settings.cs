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
        private static int Width { set; get; }
        private static int Heigth { set; get; }
        private static int Speed { set; get; }
        private static int Score { set; get; }
        private static int Points { set; get; }
        private static bool GameOver { set; get; }
        private static Direction direction { set; get; }

        public Settings()
        {
            Width = 10;
            Heigth = 10;
            Speed = 15;
            Points = 10;
            GameOver = false;
            direction = Direction.Right;
        }
    }
}
