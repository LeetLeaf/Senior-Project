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
        private Point frameSize = new Point(18, 24);

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
        private int millisecondsPerFrame = 150;


        public Rectangle renderFrame()
        {
            return new Rectangle(CurrentFrameX * FrameSizeX,
                    CurrentFrameY * FrameSizeY, FrameSizeX, FrameSizeY);
        }

        //Idle Cycle South
        private Point[] idleFramesSouth = new Point[2] {new Point(1,0),new Point (1,0)};

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
