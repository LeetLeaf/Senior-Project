using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.Kyle.Keebler.Characters;

namespace com.Kyle.Keebler
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        Vector2 center;

        public Camera(Viewport view)
        {
            this.view = view;
        }

        public void Update(GameTime gameTime, Character target, Rectangle window)
        {
            center = new Vector2(target.getPosition().X + (target.FrameSize.X / 2 - window.Width /2),
                target.getPosition().Y + (target.FrameSize.Y / 2 - window.Height /2));
            transform = Matrix.CreateScale(new Vector3(2,2,0)) *
                Matrix.CreateTranslation(new Vector3(-center.X*2 - window.Width/2,-center.Y*2 - window.Height/2,0));
        }
    }
}
