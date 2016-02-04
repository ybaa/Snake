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
            gameTimer.Interval = 1000/Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //start new game
            StartGame();

            

        }

        public void UpdateScreen(object sender, EventArgs e)
        {
            //check game over
            if(Settings.GameOver)
            {
                if (Input.KeyPressed(Keys.Enter))
                    StartGame();
              
            }
            else
            {
                if (Input.KeyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.KeyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.KeyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.KeyPressed(Keys.Down) & Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                MoveSnake();
            }

            mainAreaPb.Invalidate();

        }

        public void MoveSnake()
        {
            for (int i = Snake.Count; i <= 0; i--)
            {
                //switch head direction and the rest will take the poistion of the previouse one

                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].X++;
                            break;

                        case Direction.Left:
                            Snake[i].X--;
                            break;

                        case Direction.Up:
                            Snake[i].Y--;
                            break;

                        case Direction.Down:
                            Snake[i].Y++;
                            break;
                    }
                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }

            }
        }

        private void StartGame()
        {
            gameOverLabel.Visible = false;

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

        

        private void mainAreaPb_Paint(object sender, PaintEventArgs e)
        {

            Graphics area = e.Graphics;

            if (!Settings.GameOver)
            {
                //set color of snake
                Brush snakeColor;

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (i == 0) //head
                        snakeColor = Brushes.Black;
                    else // rest
                        snakeColor = Brushes.Blue;



                    //draw snake
                    area.FillEllipse(snakeColor, new Rectangle(Snake[i].X * Settings.Width,
                                                               Snake[i].Y * Settings.Heigth,
                                                               Settings.Width,
                                                               Settings.Heigth));

                    //draw food
                    area.FillEllipse(Brushes.Red, new Rectangle(Food.X * Settings.Width,
                                                                Food.Y * Settings.Heigth,
                                                                Settings.Width,
                                                                Settings.Heigth));
                }


            }
            else
            {
                string gameOverText = "Game over, your final score is " + Settings.Score + "\nPress Enter to try again";
                gameOverLabel.Text = gameOverText.ToString();
                gameOverLabel.Visible = true;
            }
        }
    }
}
