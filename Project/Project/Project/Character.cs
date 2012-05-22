using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public abstract class Character
    {
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        protected Vector2 Position;
        public Point FrameSize { get; set; }
        public int CurrentFrameX { get; set; }
        public int CurrentFrameY { get; set; }

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public int ExperiencePointValue { get; set; }

        public abstract void ChangeGraphic();
        public abstract bool ResolveAttack();
        public abstract void Draw(SpriteBatch spriteBatch);


        public void MovePosition(Direction direction, GameTime gameTime)
        {
            //let put basic movements here
            switch (direction)
            { 
                case Direction.South:
                    Position.Y +=2 ;
                    walkCycleSouth(gameTime);
                    break;
                case Direction.East:
                    Position.X += 2;
                    walkCycleEast(gameTime);
                    break;
                case Direction.West:
                    Position.X -= 2;
                    walkCycleWest(gameTime);
                    break;
                case Direction.North:
                    Position.Y -= 2;
                    break;
                default:
                    throw new ArgumentException("Unhandled move direction.");
                    break;
            } 

        }

        public virtual void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public Rectangle renderFrame()
        {
            return new Rectangle(Convert.ToInt32(CurrentFrameX) * Convert.ToInt32(FrameSize.X),
                    Convert.ToInt32(CurrentFrameY) * Convert.ToInt32(FrameSize.Y),
                    Convert.ToInt32(FrameSize.X), Convert.ToInt32(FrameSize.Y));
        }

        //Time between each frame
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        //Idle Cycle South
        private Point[] idleFramesSouth = new Point[2] { new Point(1, 0), new Point(1, 0) };

        public void idleCycleSouth(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrameX;
                if (CurrentFrameX >= idleFramesSouth[1].X)
                {
                    CurrentFrameX = idleFramesSouth[0].X;
                    ++CurrentFrameY;
                    if (CurrentFrameY >= idleFramesSouth[1].Y)
                        CurrentFrameY = idleFramesSouth[0].Y;
                }
            }
        }

        //Walking Cycle South
        private Point[] walkFramesSouth = new Point[2] { new Point(0, 0), new Point(3, 0) };

        public void walkCycleSouth(GameTime gameTime)
        {

            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrameX;
                if (CurrentFrameX >= walkFramesSouth[1].X)
                {
                    CurrentFrameX = walkFramesSouth[0].X;
                    ++CurrentFrameY;
                    if (CurrentFrameY >= walkFramesSouth[1].Y)
                        CurrentFrameY = walkFramesSouth[0].Y;
                }
            }
        }

        //Walking cycle West
        private Point[] walkFramesWest = new Point[2] { new Point(0, 1), new Point(3, 1) };

        public void walkCycleWest(GameTime gameTime)
        {
            CurrentFrameY = walkFramesWest[0].Y;
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrameX;
                if (CurrentFrameX >= walkFramesWest[1].X)
                {
                    CurrentFrameX = walkFramesWest[0].X;
                    ++CurrentFrameY;
                    if (CurrentFrameY >= walkFramesWest[1].Y)
                        CurrentFrameY = walkFramesWest[0].Y;
                }
            }
        }

        //Walking Cycle East
        private Point[] walkFramesEast = new Point[2] { new Point(0, 2), new Point(3, 2) };

        public void walkCycleEast(GameTime gameTime)
        {
            CurrentFrameY = walkFramesEast[0].Y;
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrameX;
                if (CurrentFrameX >= walkFramesEast[1].X)
                {
                    CurrentFrameX = walkFramesEast[0].X;
                    ++CurrentFrameY;
                    if (CurrentFrameY >= walkFramesEast[1].Y)
                        CurrentFrameY = walkFramesEast[0].Y;
                }
            }
        }


    }
}
