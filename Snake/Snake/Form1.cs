using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle Food = new Circle();

        public Form1()
        {
            InitializeComponent();

            //set ndefault settings
            new Settings();

            //set timer


            //start new game
            StartGame();


        }

        private void StartGame()
        { 
            //set default settings
            new Settings();

            //create new snake and food
            Snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            //set score label
            scoreLabel.Text = Settings.Score.ToString();

            GenerateFood();

        }

        private void GenerateFood()
        {
            Random random = new Random();
            Food = new Circle();

            //set max position of food
            int maxXPosition = mainAreaPb.Size.Width / Settings.Width;
            int maxYPosition = mainAreaPb.Size.Height / Settings.Heigth;

            Food.X = random.Next(0, maxXPosition);
            Food.Y = random.Next(0, maxYPosition);
        }
    }
}
