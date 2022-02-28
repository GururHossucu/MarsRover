using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums;

namespace MarsRover
{
    public interface IRotation
    {
        /// <summary>
        /// Rotates Rover's Direction 
        /// </summary>
        /// <param name="heading"></param>
        /// <param name="direction"></param>
        /// <returns>Headings -> N, S, W, E</returns>
        Heading Rotate(Heading heading, Direction direction);
    }
}
