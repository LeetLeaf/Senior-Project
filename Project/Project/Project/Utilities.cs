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
            if (item2.getPosition().X <= item1.getPosition().X &&
                item1.getPosition().X <= item2.getPosition().X + item2.getFrameSize().X)
            {
                if (item1.getPosition().Y <= item2.getPosition().Y)
                {
                    return Direction.South;
                }
                else if(item1.getPosition().Y >= item2.getPosition().Y+item2.getFrameSize().Y)
                {
                    return Direction.North;
                }
            }
            else if (item2.getPosition().X+item2.getFrameSize().X  >= item1.getPosition().X)
            {
                if (item2.getPosition().Y <= item1.getPosition().Y &&
                item1.getPosition().Y <= item2.getPosition().Y + item2.getFrameSize().Y)
                {
                    return Direction.East;
                }

            }
            else if (item2.getPosition().Y <= item1.getPosition().Y &&
                item1.getPosition().Y <= item2.getPosition().Y + item2.getFrameSize().Y)
            {
                return Direction.West;
            }
            return Direction.North;
        }
    }
}
