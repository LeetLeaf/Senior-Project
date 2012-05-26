using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public interface IRenderable : ICollidable
    {
        void Initialize();
        void Draw(SpriteBatch spriteBatch);
        
    }
}
