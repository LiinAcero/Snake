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

        private Direction _direction = Direction.Right;

        public Form1()
        {
            InitializeComponent();

            // Set up the game board
            gameBoard.BackColor = Color.Black;
            gameBoard.Width = GameBoardWidth * SnakeSize;
            gameBoard.Height = GameBoardHeight * SnakeSize;

            // Start the game loop
            gameLoop.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (_direction != Direction.Right)
                    {
                        _direction = Direction.Left;
                    }
                    break;
                case Keys.Right:
                    if (_direction != Direction.Left)
                    {
                        _direction = Direction.Right;
                    }
                    break;
                case Keys.Up:
                    if (_direction != Direction.Down)
                    {
                        _direction = Direction.Up;
                    }
                    break;
                case Keys.Down:
                    if (_direction != Direction.Up)
                    {
                        _direction = Direction.Down;
                    }
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            
            var head = _snake[_snake.Count - 1];
            switch (_direction)
            {
                case Direction.Left:
                    head.X -= SnakeSize;
                    break;
                case Direction.Right:
                    head.X += SnakeSize;
                    break;
                case Direction.Up:
                    head.Y -= SnakeSize;
                    break;
                case Direction.Down:
                    head.Y += SnakeSize;
                    break;
            }

            
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
                // Game over
                _gameOver = true;
                gameLoop.Stop();
            }

            
            for (var i = 0; i < _snake.Count;