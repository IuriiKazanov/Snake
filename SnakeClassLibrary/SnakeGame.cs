using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClassLibrary
{
    public class SnakeGame : ISnakeGame
    {
        Random rnd = new Random();
        const int SizeX = 50;
        const int SizeY = 22;
        const int SnakeLength = 3;
        public int Score = 0;


        private Snake mySnake;
        Point currentPrize;
        Direction currentDirection;
        GameState gameState;

        public Action<Point, Item> Draw { get; set; }

        public GameState State
        {
            get { return gameState; }
        }

        public void Initialization()
        {
            mySnake = new Snake(SnakeLength);
            currentPrize = PrizeFactory();
            currentDirection = Direction.Right;

            Draw(currentPrize, Item.Prize);
            SnakeDraw();

            gameState = GameState.Begin;
        }

        public void Instruction(Direction direction)
        {
            if (direction == Direction.Error)
            {
                Stop();
                return;
            }
            currentDirection = direction;
        }

        public void Start()
        {
            gameState = GameState.Process;
        }

        public void Step()
        {
            mySnake.AddSegment(currentDirection);
            
            Draw(mySnake.Segments.Last(), Item.SnakeSegment);

            if (mySnake.Segments.Last().Equals(currentPrize))
            {
                currentPrize = PrizeFactory();
                Draw(currentPrize, Item.Prize);
                return;
            }
            else if (IsSegment() || IsRegion() )
            {
                Stop();
            }

            Draw(mySnake.Segments.First(), Item.Zero);
            mySnake.DeleteSegment();
        }

        public void Stop()
        {
            gameState = GameState.End;
        }


        private void SnakeDraw()
        {
            foreach (var point in mySnake.Segments)
            {
                Draw(point, Item.SnakeSegment);
            }
        }

        private Point PrizeFactory()
        {
            Point prize = mySnake.Segments.ElementAt(0);
            while (mySnake.Segments.Contains(prize))
            {
                prize = new Point { X = rnd.Next(0, SizeX), Y = rnd.Next(0, SizeY) };
            }
            return prize;
        }

        private bool IsSegment()
        {
            int c = mySnake.Segments.Count();
            return mySnake.Segments.Take(c - 1).Contains(mySnake.Segments.Last());
        }

        private bool IsRegion()
        {
            Point segment = mySnake.Segments.Last();
            return (segment.X < 0 || segment.X > SizeX || segment.Y < 0 || segment.Y > SizeY);
        }
    }
}
