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
        private int DifficultyCounter = 0;

        public Form1()
        {
            InitializeComponent();

            //set ndefault settings
            new Settings();

            //set timer
            //gameTimer.Interval = 1000/Settings.Speed;
            gameTimer.Tick += UpdateScreen;
            gameTimer.Start();

            //start new game
            StartGame();

            

        }

        public void UpdateScreen(object sender, EventArgs e)
        {
            //check game over
            if(Settings.GameOver == true)
            {
                if (Input.KeyPressed(Keys.Enter))
                {
                    StartGame();
                }
              
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
            for (int i = Snake.Count-1; i >= 0; i--)
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

                    int maxXPosition = mainAreaPb.Size.Width / Settings.Width;
                    int maxYposition = mainAreaPb.Size.Height / Settings.Heigth;

                    //detect collisiton with borders
                    if (Snake[i].X < 0 || Snake[i].Y < 0 || Snake[i].X > maxXPosition || Snake[i].Y >= maxYposition)
                        Die();

                    //detect collision with body
                    for(int j = 1; j < Snake.Count ; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                            Die();
                    }

                    //eating food
                    if(Snake[i].X == Food.X && Snake[i].Y == Food.Y)
                    {
                        Eat();
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
            Settings.Score = 0;
            DifficultyCounter = 1;
            gameTimer.Interval = 100;

            //set default settings
            new Settings();

            //create new snake and food
            Snake.Clear();
            Circle head = new Circle();
            head.X = 10;
            head.Y = 5;
            Snake.Add(head);

            //set score label
            pointsLabel.Text = Settings.Score.ToString();

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
                        snakeColor = Brushes.Green;



                    //draw snake
                    area.FillEllipse(snakeColor, new Rectangle(Snake[i].X * Settings.Width,
                                                               Snake[i].Y * Settings.Heigth,
                                                               Settings.Width,
                                                               Settings.Heigth));

                    //draw food
                    area.FillEllipse(Brushes.Yellow, new Rectangle(Food.X * Settings.Width,
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.ChangeState(e.KeyCode, false);
        }

        private void Die()
        {
            Settings.GameOver = true;
            
        }

        private void Eat()
        {
            Circle food = new Circle();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;
            Snake.Add(food);

            GenerateFood();

            Settings.Score += Settings.Points;
            pointsLabel.Text = Settings.Score.ToString();

            //making the game more difficult
            DifficultyCounter++;
            if (DifficultyCounter % 7 == 0)
            { 
               // Settings.Speed += 1;
                gameTimer.Interval -= 10;
            
            }
              
        }
    }

}
