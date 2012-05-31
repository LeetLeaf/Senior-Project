using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using com.Kyle.Keebler.Map;
using com.Kyle.Keebler.Items;

namespace com.Kyle.Keebler.Characters
{
    public class Enemy : Character
    {

        public Player userPlayer { get; set; }
        private MapBase theMap;

        public Enemy(Texture2D PlayerTexture, Vector2 Position, MapBase Map,Rectangle MapBoundry)
        {
            this.Texture = PlayerTexture;
            this.Position = Position;
            FrameSize = new Point(18, 24);
            CanCollide = true;
            theMap = Map;
            movementRate = 1;
            CharacterDirection = Direction.South;
            this.MapBoundry = MapBoundry;
            MaxHealth = 5;
            CurrentHealth = MaxHealth;

            walkFrames = new Dictionary<Direction,Tuple<Point,Point>>();
            walkFrames.Add(Direction.North, 
                new Tuple<Point, Point>(new Point(0, 3),new Point(4, 3)));
            walkFrames.Add(Direction.South, 
                new Tuple<Point, Point>(new Point(0, 0), new Point(4, 0)));
            walkFrames.Add(Direction.West, 
                new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)));
           walkFrames.Add(Direction.East, 
                new Tuple<Point, Point>(new Point(0, 2), new Point(4, 2)));

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

        public override void Update(GameTime gameTime)
        {
            if (CanMove)
            {
                Chase(theMap.userPlayer.getPosition(), gameTime);
            }
            else
            {
                TimeToWait -= gameTime.ElapsedGameTime.Milliseconds;
                if (TimeToWait < 0)
                    CanMove = true;
            }

            if (CurrentHealth <= 0)
            {
                Position = new Vector2(0, 0);
                CurrentHealth = MaxHealth;
            }

            BoundryCollision(MapBoundry);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,
                 renderFrame(), Color.White);
        }

        public override void CollisionAction(ICollidable collisionElement)
        {
            if (collisionElement is Player)
            {
                TimeToWait = 1000;
                CanMove = false;
            }
        }

        public override void CollisionActionItem(Item item)
        {
            CurrentHealth--;
        }

        public void Chase(Vector2 Desination, GameTime gameTime)
        {
            if (Position.X < Desination.X)
            {
                MovePosition(Direction.East, gameTime);
            }
            else if (Position.X > Desination.X)
            {
                MovePosition(Direction.West, gameTime);
            }
            if (Position.Y < Desination.Y)
            {
                MovePosition(Direction.South, gameTime);
            }
            else if (Position.Y > Desination.Y)
            {
                MovePosition(Direction.North, gameTime);
            }
        }

    }
}
