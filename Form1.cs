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
        }

        private void movePlayer()
        {
        }

        private void generateFood()
        {
        }

        private void eat()
        {
        }

        private void die()
        {
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    settings.Direction = Direction.Left;
                    break;

                case Keys.Right:
                    settings.Direction = Direction.Right;
                    break;

                case Keys.Up:
                    settings.Direction = Direction.Up;
                    break;

                case Keys.Down:
                    settings.Direction = Direction.Down;
                    break;
            }
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