using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    interface IRenderable
    {
        void Initialize();
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
    }
}
