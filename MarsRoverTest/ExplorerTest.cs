using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nancy.Json;
using System;
using System.Collections.Generic;
using static MarsRover.Enums;


namespace MarsRoverTest
{
    [TestClass]
    public class ExplorerTest
    {
        #region Properties

        private readonly int maxX = 5;
        private readonly int maxY = 5;

        #endregion

        [TestMethod]
        public void ValidateStep()
        {
            Step stepClass = new Step() { MaxX = maxX, MaxY = maxY };
            //1. Scenario - Out Of Range Coordinate
            Coordinate outOfRangecoordinate = new Coordinate() { X = 6, Y = 6 };
            //2. Scenario - In Range Coordinate
            Coordinate inRangecoordinate = new Coordinate() { X = 3, Y = 3 };

            var result = stepClass.ValidateStep(outOfRangecoordinate);
            var result2 = stepClass.ValidateStep(inRangecoordinate);

            //Control All Scenario
            Assert.AreEqual(false, result);
            Assert.AreEqual(true, result2);
        }

        [TestMethod]
        public void Step()
        {
            Step stepClass = new Step() { MaxX = maxX, MaxY = maxY };
            Coordinate expectedCoordinate = new Coordinate();
            var js = new JavaScriptSerializer();

            //1. Scenario
            Position position = new Position
            {
                Coordinate = new Coordinate() { X = 2, Y = 2 },
                Heading = Heading.North
            };
            var result = stepClass.PerformStep(position);

            //2. Scenario
            position = new Position
            {
                Coordinate = new Coordinate() { X = 2, Y = 2 },
                Heading = Heading.East
            };
            var result2 = stepClass.PerformStep(position);

            //3. Scenario
            position = new Position
            {
                Coordinate = new Coordinate() { X = 2, Y = 2 },
                Heading = Heading.West
            };
            var result3 = stepClass.PerformStep(position);

            //4. Scenario
            position = new Position
            {
                Coordinate = new Coordinate() { X = 2, Y = 2 },
                Heading = Heading.South
            };
            var result4 = stepClass.PerformStep(position);

            //Control 1.Scenario
            expectedCoordinate.X = 2; 
            expectedCoordinate.Y = 3;
            Assert.AreEqual(js.Serialize(expectedCoordinate), js.Serialize(result));

            //Control 2.Scenario
            expectedCoordinate.X = 3;
            expectedCoordinate.Y = 2;
            Assert.AreEqual(js.Serialize(expectedCoordinate), js.Serialize(result2));

            //Control 3.Scenario
            expectedCoordinate.X = 1;
            expectedCoordinate.Y = 2;
            Assert.AreEqual(js.Serialize(expectedCoordinate), js.Serialize(result3));

            //Control 4.Scenario
            expectedCoordinate.X = 2;
            expectedCoordinate.Y = 1;
            Assert.AreEqual(js.Serialize(expectedCoordinate), js.Serialize(result4));
        }

        [TestMethod]
        public void Rotate()
        {
            Rotation rotationClass = new Rotation();

            //1. Scenario
            var result = rotationClass.Rotate(Heading.North, Direction.Left);

            //2. Scenario
            var result2 = rotationClass.Rotate(Heading.West, Direction.Left);

            //3. Scenario
            var result3 = rotationClass.Rotate(Heading.South, Direction.Left);

            //4. Scenario
            var result4 = rotationClass.Rotate(Heading.East, Direction.Left);

            //5. Scenario
            var result5 = rotationClass.Rotate(Heading.North, Direction.Right);

            //6. Scenario
            var result6 = rotationClass.Rotate(Heading.West, Direction.Right);

            //7. Scenario
            var result7 = rotationClass.Rotate(Heading.South, Direction.Right);

            //4. Scenario
            var result8 = rotationClass.Rotate(Heading.East, Direction.Right);

            //Control All Scenario
            Assert.AreEqual(result, Heading.West);
            Assert.AreEqual(result2, Heading.South);
            Assert.AreEqual(result3, Heading.East);
            Assert.AreEqual(result4, Heading.North);
            Assert.AreEqual(result5, Heading.East);
            Assert.AreEqual(result6, Heading.North);
            Assert.AreEqual(result7, Heading.West);
            Assert.AreEqual(result8, Heading.South);
        }

        [TestMethod]
        public void ExecuteAction()
        {
            Explorer explorer = new Explorer(maxX, maxY);
            var js = new JavaScriptSerializer();

            //1. Scenario
            Position pos1 = new Position() { Coordinate = new Coordinate() { X = 1, Y = 2 }, Heading = Enums.Heading.North };
            Position expectedPosition = new Position() { Coordinate = new Coordinate() { X = 1, Y = 3 }, Heading = Enums.Heading.North };

            var result = explorer.ExecuteActions(pos1, new List<Enums.Action>()
            {
                Enums.Action.L, Enums.Action.M,
                Enums.Action.L, Enums.Action.M,
                Enums.Action.L, Enums.Action.M,
                Enums.Action.L, Enums.Action.M,
                Enums.Action.M
            });

            //2. Scenario
            Position pos2 = new Position() { Coordinate = new Coordinate() { X = 3, Y = 3 }, Heading = Enums.Heading.East };
            Position expectedPosition2 = new Position() { Coordinate = new Coordinate() { X = 5, Y = 1 }, Heading = Enums.Heading.East };

            var result2 = explorer.ExecuteActions(pos2, new List<Enums.Action>()
            {
                Enums.Action.M, Enums.Action.M, Enums.Action.R,
                Enums.Action.M, Enums.Action.M, Enums.Action.R,
                Enums.Action.M, Enums.Action.R, Enums.Action.R,
                Enums.Action.M,
            });

            //Control All Scenario
            Assert.AreEqual(js.Serialize(expectedPosition), js.Serialize(result));
            Assert.AreEqual(js.Serialize(expectedPosition2), js.Serialize(result2));
        }

    }
}
