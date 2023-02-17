using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private const int GameBoardWidth = 20;
        private const int GameBoardHeight = 20;
        private const int SnakeSize = 10;
        private const int FoodSize = 10;
        private readonly Random _random = new Random();



        private readonly List<Point> _snake = new List<Point>();
        private Point _food;

        private int _score;
        private bool _gameOver;

        public enum Direction
        {
            Left, Right, Up, Down
        }




        private Direction _direction = Direction.Right;

        public Form1()
        {
            InitializeComponent();



            const int Rows = 10;
            const int Cols = 10;

            int[,] gameBoard = new int[Rows, Cols];


            gameBoard[0, 0] = 1;


            


            
=======
            
            gameBoard.BackColor = Color.Black;
            gameBoard.Width = GameBoardWidth * SnakeSize;
            gameBoard.Height = GameBoardHeight * SnakeSize;

            
            gameLoop.Start();
>>>>>>> d684cb16e4f23f4110bee967548e23cb4e568075
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                    _direction = Direction.Left;
                    break;
                case Keys.Right:
                    _direction = Direction.Right;
                    break;
                case Keys.Up:
                _direction = Direction.Up;
                    
                    break;
                case Keys.Down:                    
                    _direction = Direction.Down;
                    break;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {


        }   
    }
}
=======
            
            if (head == _food)
            {
                _snake.Add(_snake[0]);
                _food = new Point(_random.Next(0, GameBoardWidth) * SnakeSize,
                                  _random.Next(0, GameBoardHeight) * SnakeSize);
                _score++;
            }
            else if (head.X < 0 || head.X >= gameBoard.Width ||
                     head.Y < 0 || head.Y >= gameBoard.Height ||
                     _snake.Contains(head))
            {
                
                _gameOver = true;
                gameLoop.Stop();
            }

            
            for (var i = 0; i < _snake.Count;

