using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections;

namespace com.Kyle.Keebler
{
    public abstract class Character : IRenderable, IMoveable
    {

        #region Fields

        //Position of the Character on the screen
        protected Vector2 Position = new Vector2(0,0); 

        //Which sprite is selected on the Sheet
        protected Vector2 CurrentFrame = new Vector2(0,0); 

       
        //Time between each frame
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 150;

        //Movement Elements
        protected Direction characterDirection = Direction.South;
        protected Dictionary<Direction, Tuple<Point, Point>> walkFrames;
        protected Dictionary<Direction, Tuple<Point, Point>> idleFrames;

        protected int movementRate = 2;

        #endregion

        public string Name { get; set; }  //Name of the Character
        public Texture2D Texture { get; set; } //Sprite Sheet assigned to the Character
        public Point FrameSize { get; set; } //The size of one frame on the Sprite Sheet

        public int MaxHealth { get; set; } //Max health a character has
        public int CurrentHealth { get; set; } //Current amount of health a character has

        public int ExperiencePointValue { get; set; } //How much experience points the character gives???

        public Rectangle CollisionRec
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + 5,
                    (int)Position.Y + 5,
                    FrameSize.X - 5,
                    FrameSize.Y - 5);
            }
        }

        public bool CanCollide { get; set; }

        public abstract void ChangeGraphic(); //allows a change to the texture
        public abstract bool ResolveAttack(); //Handles what happens when attacked?
        public abstract void Update(GameTime gameTime); //Used to Update the Character in the Game Class
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
                    Position.Y += movementRate;
                    break;
                case Direction.East:
                    Position.X += movementRate;
                    break;
                case Direction.West:
                    Position.X -= movementRate;
                    break;
                case Direction.North:
                    Position.Y -= movementRate;
                    break;
                default:
                    throw new ArgumentException("Unhandled move direction.");
                    break;
            }
            WalkCharacter(gameTime, direction);
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

        public virtual bool Collide(Rectangle collideRec)
        {

            return CollisionRec.Intersects(collideRec);
        }

        /// <summary>
        /// Creates a Rectangle that has the exact position of the CurrentFrame.
        /// </summary>
        /// <returns></returns>
        public Rectangle renderFrame()
        {
            return new Rectangle(Convert.ToInt32(CurrentFrame.X) * Convert.ToInt32(FrameSize.X),
                    Convert.ToInt32(CurrentFrame.Y) * Convert.ToInt32(FrameSize.Y),
                    Convert.ToInt32(FrameSize.X), Convert.ToInt32(FrameSize.Y));
        }

        public void IdleCharacter(GameTime gameTime, Direction direction)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrame.X;
                if (CurrentFrame.X >= idleFrames[direction].Item2.X)
                {
                    CurrentFrame.X = idleFrames[direction].Item1.X;
                    ++CurrentFrame.Y;
                    if (CurrentFrame.Y >= idleFrames[direction].Item2.Y)
                        CurrentFrame.Y = idleFrames[direction].Item1.Y;
                }
            }
        }

        public void WalkCharacter(GameTime gameTime, Direction direction)
        {
            characterDirection = direction;

            CurrentFrame.Y = walkFrames[direction].Item1.Y;
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrame.X;
                if (CurrentFrame.X >= walkFrames[direction].Item2.X)
                {
                    CurrentFrame.X = walkFrames[direction].Item1.X;
                    ++CurrentFrame.Y;
                    if (CurrentFrame.Y >= walkFrames[direction].Item2.Y)
                        CurrentFrame.Y = walkFrames[direction].Item1.Y;
                }
            }
        }


        #region IRenderable Members

        public void Initialize()
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
