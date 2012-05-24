using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public class Enemy : Character
    {
        public Enemy(Texture2D PlayerTexture, Vector2 Position)
        {
            this.Texture = PlayerTexture;
            this.Position = Position;
            FrameSize = new Point(18, 24);
            CanCollide = true;

            movementRate = 2;

            walkFrames = new Dictionary<Direction,Tuple<Point,Point>>();
            walkFrames.Add(Direction.North, 
                new Tuple<Point, Point>(new Point(0, 4),new Point(4, 4)));
            walkFrames.Add(Direction.South, 
                new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)));
            walkFrames.Add(Direction.West, 
                new Tuple<Point, Point>(new Point(0, 2), new Point(4, 2)));
           walkFrames.Add(Direction.East, 
                new Tuple<Point, Point>(new Point(0, 3), new Point(4, 3)));

            idleFrames = new Dictionary<Direction,Tuple<Point,Point>>();
            idleFrames.Add(Direction.North, 
                new Tuple<Point,Point>(new Point(0, 4), new Point(0, 4)));
            idleFrames.Add(Direction.South, 
                new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0)));
            idleFrames.Add(Direction.West, 
                new Tuple<Point, Point>(new Point(0, 2), new Point(0, 2)));
           idleFrames.Add(Direction.East, 
                new Tuple<Point, Point>(new Point(0, 3), new Point(0, 3)));


        }

        public override void ChangeGraphic()
        {
            throw new NotImplementedException();
        }

        public override bool ResolveAttack()
        {
            throw new NotImplementedException();
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,
                 renderFrame(), Color.White);
        }

        public override void CollisionAction(ICollidable collisionElement)
        {
            Position.X += 2;
        }

        public override void CollisionActionItem(Item item)
        {
            
        }
    }
}
