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
        private Point playerFrameSize = new Point(18, 32);

        public int PlayerFrameSizeX
        {
            get { return playerFrameSize.X; }
            set { playerFrameSize.X = value; }
        }
        public int PlayerFrameSizeY
        {
            get { return playerFrameSize.Y; }
            set { playerFrameSize.Y = value; }
        }
        private Point playerCurrentFrame = new Point(0, 0);

        public int PlayerCurrentFrameX
        {
          get { return playerCurrentFrame.X; }
          set { playerCurrentFrame.X = value; }
        }
        public int PlayerCurrentFrameY
        {
            get { return playerCurrentFrame.Y; }
            set { playerCurrentFrame.Y = value; }
        }
        private Point playerIdleFrames = new Point(3, 0);

        public int PlayerIdleFramesX
        {
          get { return playerIdleFrames.X; }
          set { playerIdleFrames.X = value; }
        }
        public int PlayerIdleFramesY
        {
            get { return playerIdleFrames.Y; }
            set { playerIdleFrames.Y = value; }
        }

        private Point playerPos = new Point(0, 0);

        public int PlayerPosX
        {
            get { return playerPos.X; }
            set { playerPos.X = value; }
        }

        public int PlayerPosY
        {
            get { return playerPos.Y; }
            set { playerPos.Y = value; }
        }

    }
}
