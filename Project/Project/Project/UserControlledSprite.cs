using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project
{
    class UserControlledSprite
    {
        public UserControlledSprite(Texture2D textureImage, Vector2 postion,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed) 
            : base(textureImage, postion, frameSize,
            collisionOffset ,currentFrame, sheetSize, speed)
        { 
        }
    }
}
