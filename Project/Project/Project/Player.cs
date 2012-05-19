using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics

namespace com.Kyle.Keebler
{
    class Player
    {
        Point playerFrameSize = new Point(18, 32);

        public Point PlayerFrameSize
        {
            get { return playerFrameSize; }
            set { playerFrameSize = value; }
        }

        Point playerCurrentFrame = new Point(0, 0);

        public Point PlayerCurrentFrame
        {
          get { return playerCurrentFrame; }
          set { playerCurrentFrame = value; }
        }
        Point playerIdleFrames = new Point(3, 0);

        public Point PlayerIdleFrames
        {
          get { return playerIdleFrames; }
          set { playerIdleFrames = value; }
        }
    }
}
