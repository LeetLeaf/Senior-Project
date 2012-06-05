using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.Kyle.Keebler.Characters;

namespace com.Kyle.Keebler.Items
{
    public class Sword : Item
    {
        public Sword(String Name, Texture2D Texture, Vector2 Position, ItemType TypeOfItem)
        {
            this.Name = Name;
            this.Texture = Texture;
            this.Position = Position;
            this.TypeOfItem = TypeOfItem;
            IsPickedUp = false;
            CanCollide = true;

        }
        public void Update(GameTime gameTime)
        {
            Player userPlayer = HeldBy as Player;
            if (userPlayer.Attacking || !this.IsPickedUp)
            {
                CanCollide = true;
            }
        }   

        public override void PickMeUp(Character pickedUpBy)
        {
            base.PickMeUp(pickedUpBy);
            this.CanCollide = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            float rotation = 0;
            if (HeldBy != null)
            {
                //rotation rate in radians 
                rotation = (int)HeldBy.CharacterDirection * (float)(Math.PI / 2.0);
            }

            spriteBatch.Draw(Texture, new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height),
                null, Color.White, rotation, new Vector2(Texture.Width, Texture.Height), SpriteEffects.None, 1.0f);


            //base.Draw(spriteBatch);
        }

    }
}
