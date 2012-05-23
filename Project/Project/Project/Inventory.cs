using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler
{
    class Inventory
    {
        public List<Item> InventoryList { get; set; }
        public Texture2D Texture { get; set; }

        public Inventory(Texture2D Texture)
        {
            this.Texture = Texture;
            InventoryList = new List<Item>();
        }

        public void Draw(SpriteBatch spriteBatch,Rectangle clientBounds)
        {
            spriteBatch.Draw(Texture,
                new Vector2(clientBounds.Width/2 - Texture.Width/2,
                            clientBounds.Height/2 - Texture.Height/2),
                            Color.White);
            for (int i = 0; i < InventoryList.Count; i++)
            {
                InventoryList[i].Position = new Vector2(clientBounds.Width/2 - Texture.Width/2 + (InventoryList[i].Texture.Width*i+1),
                                                        clientBounds.Height/2 - Texture.Height/2 + (InventoryList[i].Texture.Height*i+1));
                InventoryList[i].Draw(spriteBatch);
            }
        }
    }
}
