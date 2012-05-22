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
        public string Name { get; set; }  //Name of the Character
        public Texture2D Texture { get; set; } //Sprite Sheet assigned to the Character
        protected Vector2 Position; //Position of the Character on the screen
        public Point FrameSize { get; set; } //The size of one frame on the Sprite Sheet
        public int CurrentFrameX { get; set; } //Which sprite is selected on the Sheet, horizontally 
        public int CurrentFrameY { get; set; } //Which sprite is selected on the Sheet, vertically

        public int MaxHealth { get; set; } //Max health a character has
        public int CurrentHealth { get; set; } //Current amount of health a character has

        public int ExperiencePointValue { get; set; } //How much experience points the character gives???

        public abstract void ChangeGraphic(); //allows a change to the texture
        public abstract bool ResolveAttack(); //Handles what happens when attacked?
        public abstract void Draw(SpriteBatch spriteBatch); //Used to Draw the Character in the Game Class

        /// <summary>
        /// Updates the Player position on the screen when a certain direction is called.
        /// Draws the frames that correspond with direction the character is moving.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="gameTime"></param>
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
        /// <summary>
        /// This Initialize of character assigns the Character to a Sprite sheet
        /// and the position of the character on the screen.
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        public virtual void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }
        /// <summary>
        /// Creates a Rectangle that has the exact position of the CurrentFrame.
        /// </summary>
        /// <returns></returns>
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
