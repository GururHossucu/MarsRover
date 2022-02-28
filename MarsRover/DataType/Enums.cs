using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Enums
    {
        public enum Heading
        {
            North = 0,
            East = 1,
            South = 2,
            West = 3
        }
        public enum Direction
        {
            Left = -1,
            Right = 1
        }

        public enum Action
        {
            M = 1,
            L = 2,
            R = 3
        }
    }
}
