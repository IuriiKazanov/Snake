using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeClassLibrary
{
    [Serializable]
    public class Record 
    {
        public string Name;
        public int Score;

        public Record(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public Record()
        {
            Name = string.Empty;
            Score = 0;
        }

    }
}
