namespace Snake
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    public class Circle
    {
        public int x { get; set; }
        public int y { get; set; }

        public Circle()
        {
            x = 0;
            y = 0;
        }
    }

    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Speed { get; set; }
        public int Score { get; set; }
        public int Points { get; set; }
        public bool GameOver { get; set; }
        public Direction Direction { get; set; }

        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 20;
            Score = 0;
            Points = 100;
            GameOver = false;
            Direction = Direction.Right;
        }
    }
}