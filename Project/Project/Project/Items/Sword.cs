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

        public Sword(String Name, Texture2D Texture, Vector2 Position, ItemType TypeOfItem,bool InChest)
        {
            this.Name = Name;
            this.Texture = Texture;
            this.Position = Position;
            this.TypeOfItem = TypeOfItem;
            IsPickedUp = false;
            CanCollide = true;
            this.InChest = InChest;

        }

        public override Rectangle CollisionRec
        {
            get
            {
                Rectangle result = new Rectangle(
                        (int)Position.X + 2, (int)Position.Y + 2,
                        Texture.Width - 2, Texture.Height - 2);
                if (IsPickedUp)
                {
                    switch (HeldBy.CharacterDirection)
                    { 
                        case(Direction.North):
                            result = new Rectangle(
                                (int)Position.X + 2, (int)Position.Y - 10,
                                Texture.Width - 2, Texture.Height - 2);
                            break;
                        case (Direction.South):
                            result = new Rectangle(
                                (int)Position.X + 2, (int)Position.Y + 2,
                                Texture.Width - 2, Texture.Height + 2);
                            break;
                        case (Direction.East):
                            result = new Rectangle(
                                (int)Position.X + 2, (int)Position.Y + 2,
                                Texture.Width - 2, Texture.Height - 2);
                            break;
                        case (Direction.West):
                            result = new Rectangle(
                                (int)Position.X - 1, (int)Position.Y + 2,
                                Texture.Width - 2, Texture.Height - 2);
                            break;
                    }
                }
                else
                {
                    result = new Rectangle(
                        (int)Position.X + 2, (int)Position.Y + 2,
                        Texture.Width - 2, Texture.Height - 2);
                }
                return result;
            }
        }

        public void Update(GameTime gameTime)
        {
         
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
