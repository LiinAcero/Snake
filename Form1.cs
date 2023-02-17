using System.Drawing.Text;

namespace Snake
{
     class Circle
    {
        public int x { get; set; }
        public int y { get; set; }

        public Circle()
        {
            x = 0;
            y = 0;
        }
    }
    public partial class Snake : Form
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

        private List<Circle> SnakeBod = new List<Circle>();
        private Circle food = new Circle();
        private void startGame()
        {

        }
        private void movePlayer() {
        }

        private void genFood()
        {

        }

        private void eat()
        {

        }

        private void die()
        {

        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Rectangle ee = new Rectangle(10, 10, 30, 30);
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, ee);
            }
        }

        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        private Direction _direction = Direction.Right;

        public Snake()
        {
            InitializeComponent();

            const int Rows = 10;
            const int Cols = 10;

            int[,] gameBoard = new int[Rows, Cols];

            gameBoard[0, 0] = 1;

            

            


            


            
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

    }
}