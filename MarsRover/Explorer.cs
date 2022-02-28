using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRover.Enums;
using Action = MarsRover.Enums.Action;

namespace MarsRover
{
    public class Explorer
    {
        public Step stepClass;
        public Rotation rotationClass;
        public Explorer(int maxX, int maxY)
        {
            stepClass = new Step() { MaxX = maxX, MaxY = maxY };
            rotationClass = new Rotation();
        }
        /// <summary>
        /// Calculates the new positions/direciton of Rovers
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private Position Move(Position currentPosition, Action action)
        {
            Position calculatedPosition = new Position() { Coordinate = currentPosition.Coordinate, Heading = currentPosition.Heading };
            switch (action)
            {
                case Enums.Action.M:
                    calculatedPosition.Coordinate = stepClass.PerformStep(currentPosition);
                    break;
                case Enums.Action.L:
                    calculatedPosition.Heading = rotationClass.Rotate(currentPosition.Heading, Direction.Left);
                    break;
                case Enums.Action.R:
                    calculatedPosition.Heading = rotationClass.Rotate(currentPosition.Heading, Direction.Right);
                    break;
                default:
                    break;
            }

            return calculatedPosition;
        }

        /// <summary>
        /// Applys give an actions starting from the initial positions
        /// </summary>
        /// <param name="initialPos"></param>
        /// <param name="actionList"></param>
        /// <returns></returns>
        public Position ExecuteActions(Position initialPos, List<Action> actionList)
        {
            var currentPos = initialPos;
            foreach (var item in actionList)
            {
                currentPos = this.Move(currentPos, item);
            }

            return currentPos;
        }
       
    }
}
