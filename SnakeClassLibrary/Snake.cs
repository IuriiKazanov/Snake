using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClassLibrary
{
    public struct Point
    {
        public int X;
        public int Y;
        
        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
    }

    public enum Direction
    {
        Up, Down, Left, Right, Error
    }

    public enum Item
    {
        SnakeSegment, Prize, Zero
    }

    public enum GameState
    {
        Begin, Process, End
    }

    public class Snake
    {
        Queue<Point> segments;

        public Snake(int length)
        {
            segments = new Queue<Point>();

            for (int i = 0; i < length; i++)
                segments.Enqueue(new Point(i));
        }

        public IEnumerable<Point> Segments { get { return segments; } }

        public void AddSegment(Direction direction)
        {
            Point newSegment = segments.Last();
            switch (direction)
            {
                case Direction.Up: newSegment.Y--; break;
                case Direction.Down: newSegment.Y++; break;
                case Direction.Left: newSegment.X--; break;
                case Direction.Right: newSegment.X++; break;
            }
            segments.Enqueue(newSegment);
        }

        public Point DeleteSegment()
        {
            Point segment = segments.Dequeue();
            return segment;
        }
    }
}
