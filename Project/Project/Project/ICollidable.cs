using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public interface ICollidable
    {
        Rectangle CollisionRec { get; }
        bool CanCollide { get; set; }
    }
}
