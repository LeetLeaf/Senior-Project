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

    }
}
