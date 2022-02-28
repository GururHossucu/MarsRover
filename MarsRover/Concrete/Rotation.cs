using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums;

namespace MarsRover
{
    public class Rotation : IRotation
    {
        private const int DIRECTION_MODE = 4;
        public Heading Rotate(Heading heading, Direction direction)
        {
            int calculatedHeading = (int)heading + (int)direction;
            calculatedHeading = calculatedHeading >= 0 ? calculatedHeading %= DIRECTION_MODE : calculatedHeading += DIRECTION_MODE;
            return (Heading)calculatedHeading;
        }
    }
}
