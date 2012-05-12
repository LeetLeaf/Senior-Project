using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Project
{
    class Player
    {
        Texture2D textureImage;
        protected Point frameSize;
        Point currentFrame;
        Point sheetSize;
        int collisionOffset;
        int timeSinceLastFrame=0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;
        protected Vector2 speed;
        protected Vector2 postion;

        public Player(Texture2D textureImage, Point frameSize, Point currentFrame, Point sheetSize,
                      int collisionOffset, int millisecondsPerFrame, Vector2 speed, Vector2 postion)
        {
            this.textureImage = textureImage;
            this.frameSize = frameSize;
            this.currentFrame = currentFrame;
            this.sheetSize = sheetSize;
            this.collisionOffset = collisionOffset;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.speed = speed;
            this.postion = postion;
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                    {
                        currentFrame.Y = 0;
                    }
                }
            }
        }
    }
}
