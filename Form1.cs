namespace Snake
{
    public partial class Snake : Form
    {
        private readonly Random random = new Random();

        private List<Circle> SnakeBod = new List<Circle>();
        private Circle food = new Circle();
        private Settings settings = new Settings();

        public Snake()
        {
            InitializeComponent();
        }

        private void startGame()
        {
            label3.Visible = false;
            settings = new Settings();
            SnakeBod.Clear();
            Circle head = new Circle { x = 10, y = 5 };
            SnakeBod.Add(head);

            label2.Text = settings.Score.ToString();

            timer.Interval = 1000 / settings.Speed;
            timer.Start();

            generateFood();
        }

        private void updateGraphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;
            if (settings.GameOver == false)
            {
                Brush snakeColor;

                for (int i = 0; i < SnakeBod.Count; i++)
                {
                    if (i == 0)
                    {
                        snakeColor = Brushes.Black;
                    }
                    else
                    {
                        snakeColor = Brushes.Green;
                    }
                    canvas.FillEllipse(snakeColor,
                        new Rectangle(
                            SnakeBod[i].x * settings.Width,
                            SnakeBod[i].y * settings.Height,
                            settings.Width, settings.Height
                            ));

                    canvas.FillEllipse(Brushes.Red,
                                        new Rectangle(
                                            food.x * settings.Width,
                                            food.y * settings.Height,
                                            settings.Width, settings.Height
                                            ));
                }
            }
            else
            {
                string GameOver = "Game Over \n" + "Final Score is " + settings.Score + "\n Press Enter to Restart \n";
                label3.Text = GameOver;
                label3.Visible = true;
            }
        }

        private void movePlayer()
        {
            for (int i = SnakeBod.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (settings.Direction)
                    {
                        case Direction.Right:
                            SnakeBod[i].x++;
                            break;

                        case Direction.Left:
                            SnakeBod[i].x--;
                            break;

                        case Direction.Up:
                            SnakeBod[i].y--;
                            break;

                        case Direction.Down:
                            SnakeBod[i].y++;
                            break;
                    }

                    int maxxpos = pbCanvas.Size.Width / settings.Width;
                    int maxypos = pbCanvas.Size.Height / settings.Height;

                    if (
                        SnakeBod[i].x < 0 || SnakeBod[i].y < 0 ||
                        SnakeBod[i].x > maxxpos || SnakeBod[i].y > maxypos
                        )
                    {
                        die();
                    }

                    for (int j = 1; j < SnakeBod.Count; j++)
                    {
                        if (SnakeBod[i].x == SnakeBod[j].x && SnakeBod[i].y == SnakeBod[j].y)
                        {
                            die();
                        }
                    }

                    if (SnakeBod[0].x == food.x && SnakeBod[0].y == food.y)
                    {
                        eat();
                    }
                }
                else
                {
                    SnakeBod[i].x = SnakeBod[i - 1].x;
                    SnakeBod[i].y = SnakeBod[i - 1].y;
                }
            }
        }

        private void generateFood()
        {
            int maxxpos = pbCanvas.Size.Width / settings.Width;
            int maxypos = pbCanvas.Size.Height / settings.Height;
            food = new Circle { x = random.Next(0, maxxpos), y = random.Next(0, maxypos) };
        }

        private void eat()
        {
            Circle body = new Circle
            {
                x = SnakeBod[SnakeBod.Count - 1].x,
                y = SnakeBod[SnakeBod.Count - 1].y,
            };

            SnakeBod.Add(body);
            settings.Score += settings.Points;
            label2.Text = settings.Score.ToString();
            generateFood();
        }

        private void die()
        {
            settings.GameOver = true;
            timer.Stop();
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    settings.Direction = Direction.Left;
                    break;

                case Keys.D:
                    settings.Direction = Direction.Right;
                    break;

                case Keys.W:
                    settings.Direction = Direction.Up;
                    break;

                case Keys.S:
                    settings.Direction = Direction.Down;
                    break;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            movePlayer();
            pbCanvas.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startGame();
        }
    }
}