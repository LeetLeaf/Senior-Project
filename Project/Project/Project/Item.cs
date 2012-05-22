using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public class Item
    {
        public ItemType TypeOfItem { get; set; }
        public int ExperiencePointValue { get; private set; }
        public Vector2 Position { get; set; }
    }
}
