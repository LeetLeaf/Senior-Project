using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using com.Kyle.Keebler.Items;

namespace com.Kyle.Keebler
{
    public interface ICollidable
    {
        Rectangle CollisionRec { get; }
        bool CanCollide { get; set; }

        void CollisionAction(ICollidable impactedElement);
        void CollisionActionItem(Item impactedElement);
    }
}
