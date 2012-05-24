using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler
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

        }
        public void Update(GameTime gameTime)
        {
            if (IsPickedUp)
            {
                Position=new Vector2(0, 0);
            }
        }
    }
}
