using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace com.Kyle.Keebler
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType TypeOfItem { get; set; }
        public int ExperiencePointValue { get; private set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public Item()
        { }
        public Item(String Name, Texture2D Texture, Vector2 Position, ItemType TypeOfItem)
        {
            this.Name = Name;
            this.Texture = Texture;
            this.Position = Position;
            this.TypeOfItem = TypeOfItem;

        }

        public void Update(GameTime gameTime)
        { 
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        public Rectangle CollisionRec
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + 2, (int)Position.Y + 2,
                    Texture.Width - 2, Texture.Height - 2);
            }
        }
    }
}
