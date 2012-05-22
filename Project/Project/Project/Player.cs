using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler
{
    public class Player : Character
    {
        //Properties

        private Vector2 pos = new Vector2(0, 0);

        public Player(Texture2D texture, Vector2 Position)
        {
            Texture = texture;
            this.Position = Position;
            FrameSize = new Point(18, 24);
        }

        public override void ChangeGraphic()
        {
            throw new NotImplementedException();
        }
        public override bool ResolveAttack()
        {
            throw new NotImplementedException();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,
                renderFrame(), Color.White);
        }

    }
}
