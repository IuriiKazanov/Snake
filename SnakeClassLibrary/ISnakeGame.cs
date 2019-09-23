using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClassLibrary
{
    interface ISnakeGame
    {
        void Initialization();
        void Start();
        void Step();
        void Stop();
        void Instruction(Direction direction);
        Action<Point, Item> Draw { get; set; }

        GameState State { get; }
    }
}
