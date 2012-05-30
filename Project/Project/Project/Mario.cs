using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public class Mario : Enemy
    {
        public Mario(Texture2D PlayerTexture, Vector2 Position, MapBase Map, Rectangle MapBoundry)
            : base(PlayerTexture, Position, Map, MapBoundry)
        {
            movementRate = 3;

            walkFrames = new Dictionary<Direction, Tuple<Point, Point>>();
            walkFrames.Add(Direction.North,
                new Tuple<Point, Point>(new Point(0, 3), new Point(4, 3)));
            walkFrames.Add(Direction.South,
                new Tuple<Point, Point>(new Point(0, 0), new Point(4, 0)));
            walkFrames.Add(Direction.West,
                new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)));
            walkFrames.Add(Direction.East,
                 new Tuple<Point, Point>(new Point(0, 2), new Point(4, 2)));

            idleFrames = new Dictionary<Direction, Tuple<Point, Point>>();
            idleFrames.Add(Direction.North,
                new Tuple<Point, Point>(new Point(0, 4), new Point(0, 4)));
            idleFrames.Add(Direction.South,
                new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0)));
            idleFrames.Add(Direction.West,
                new Tuple<Point, Point>(new Point(0, 2), new Point(0, 2)));
            idleFrames.Add(Direction.East,
                 new Tuple<Point, Point>(new Point(0, 3), new Point(0, 3)));

        }
    }
}
