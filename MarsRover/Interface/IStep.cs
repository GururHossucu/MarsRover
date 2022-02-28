using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public interface IStep
    {
        int MaxX { get; set; }
        int MaxY { get; set; }
        /// <summary>
        /// Step 1 unit with respect to Rover's direction
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        Coordinate PerformStep(Position position);
        /// <summary>
        /// Check boundaies of the surface for step
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>true, false</returns>
        bool ValidateStep(Coordinate coordinate);
    }
}
