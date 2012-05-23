using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace com.Kyle.Keebler
{
    public class Player : Character
    {
        //Properties
        public bool showItems {get; set;}
        

        public Player(Texture2D Texture, Vector2 Position)
        {
            this.Texture = Texture;
            this.Position = Position;
            FrameSize = new Point(18, 24);
            showItems = false;
            
        }

        public override void ChangeGraphic()
        {
            throw new NotImplementedException();
        }
        public override bool ResolveAttack()
        {
            throw new NotImplementedException();
        }
        public override void Update(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.T))
            {
                showItems = !showItems;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                MovePosition(Direction.South, gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                MovePosition(Direction.North, gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                MovePosition(Direction.West, gameTime);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                MovePosition(Direction.East, gameTime);
            }
            //Idle
            if (Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up)
                && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                idleCycleSouth(gameTime);
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,
                renderFrame(), Color.White);
        }

    }
}
