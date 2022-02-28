using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums;

namespace MarsRover
{
    public class Step : IStep
    {
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public Step()
        {
        }

        public Coordinate PerformStep(Position position)
        {
            Coordinate tmpCoordinate = new Coordinate() { X = position.Coordinate.X, Y = position.Coordinate.Y };
            switch (position.Heading)
            {
                case Heading.North:
                    tmpCoordinate.Y++;
                    break;
                case Heading.East:
                    tmpCoordinate.X++;
                    break;
                case Heading.West:
                    tmpCoordinate.X--;
                    break;
                case Heading.South:
                    tmpCoordinate.Y--;
                    break;
                default:
                    break;
            }

            if (this.ValidateStep(tmpCoordinate))
            {
                position.Coordinate = tmpCoordinate;
            }

            return position.Coordinate;
        }
        public bool ValidateStep(Coordinate coordinate)
        {
            if (coordinate.X > MaxX || coordinate.X < 0 || coordinate.Y > MaxY || coordinate.Y < 0)
                return false;
            return true;
        }
    }
}
