using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Position> positions = new List<Position>();
            Explorer exp = new Explorer(5, 5);
            //Rover1
            Position pos1 = new Position() { Coordinate = new Coordinate() { X = 1,  Y = 2}, Heading = Enums.Heading.North };
            //Rover2

            Position pos2 = new Position() { Coordinate = new Coordinate() { X = 3, Y = 3 }, Heading = Enums.Heading.East };
            var result = exp.ExecuteActions(pos1, new List<Enums.Action>() 
            { 
                Enums.Action.L, Enums.Action.M,
                Enums.Action.L, Enums.Action.M,
                Enums.Action.L, Enums.Action.M, 
                Enums.Action.L, Enums.Action.M,
                Enums.Action.M
            });

            var result2 = exp.ExecuteActions(pos2, new List<Enums.Action>()
            {
                Enums.Action.M, Enums.Action.M, Enums.Action.R,
                Enums.Action.M, Enums.Action.M, Enums.Action.R,
                Enums.Action.M, Enums.Action.R, Enums.Action.R,
                Enums.Action.M,
            });

            positions.Add(result);
            positions.Add(result2);
            foreach (var item in positions)
            {
                Console.WriteLine(string.Format("PosX, Y: {0}, {1}  Heading: {2}", item.Coordinate.X, item.Coordinate.Y, item.Heading));
            }

            Console.ReadKey();
        }
    }
}
