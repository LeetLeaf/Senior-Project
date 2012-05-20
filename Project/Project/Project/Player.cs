using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler
{
    public class Player
    {
        //Properties
        private Point frameSize = new Point(18, 32);

        public int FrameSizeX
        {
            get { return frameSize.X; }
            set { frameSize.X = value; }
        }
        public int FrameSizeY
        {
            get { return frameSize.Y; }
            set { frameSize.Y = value; }
        }
        private Point currentFrame = new Point(0, 0);

        public int CurrentFrameX
        {
          get { return currentFrame.X; }
          set { currentFrame.X = value; }
        }
        public int CurrentFrameY
        {
            get { return currentFrame.Y; }
            set { currentFrame.Y = value; }
        }

        private Point pos = new Point(0, 0);

        public int PosX
        {
            get { return pos.X; }
            set { pos.X = value; }
        }

        public int PosY
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }

        
        //Animation and Rendering Methods
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame = 120;


        public Rectangle renderFrame()
        {
            return new Rectangle(CurrentFrameX * FrameSizeX,
                    CurrentFrameY * FrameSizeY, FrameSizeX, FrameSizeY);
        }

        private Point idleFrames = new Point(3,0);

        public void idleCycle(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++CurrentFrameX;
                if (CurrentFrameX >= idleFrames.X)
                {
                    CurrentFrameX = 0;
                    ++CurrentFrameY;
                    if (CurrentFrameY >= idleFrames.Y)
                        CurrentFrameY = 0;
                }
            }
        }
    }
}
