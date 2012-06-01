using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
        public static Direction DirectionTo(IRenderable item1, IRenderable item2)
        {
            Point middlePoint1 = new Point((int)item1.getPosition().X + item1.getFrameSize().X / 2, (int)item1.getPosition().Y + item1.getFrameSize().X / 2);
            Point middlePoint2 = new Point((int)item2.getPosition().X + item2.getFrameSize().X / 2, (int)item2.getPosition().Y + item2.getFrameSize().X / 2);

            if (item1.getPosition().X < middlePoint2.X &&
                middlePoint2.X < item1.getPosition().X + item1.getFrameSize().X)
            {
                if (middlePoint1.Y < middlePoint2.Y)
                {
                    return Direction.South;
                }
                if (middlePoint1.Y > middlePoint2.Y)
                {
                    return Direction.North;
                }
            }
            if (middlePoint1.X < middlePoint2.X)
            {
                return Direction.East;
            }
            if (middlePoint1.X > middlePoint2.X)
            {
                return Direction.West;
            }
           

            return Direction.East;
        }
    }
}
