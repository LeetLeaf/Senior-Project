using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Kyle.Keebler
{
    public class Utilities
    {
        public static Direction FlipDirection(Direction d)
        {
            switch (d)
            {
                case Direction.East:
                    return Direction.West;
                case Direction.North:
                    return Direction.South;
                case Direction.South:
                    return Direction.North;
                case Direction.West:
                    return Direction.East;
                default:
                    throw new ArgumentException("Direction not supported");
            }
        }
    }
}
