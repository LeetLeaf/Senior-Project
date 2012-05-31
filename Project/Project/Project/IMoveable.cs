using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public interface IMoveable : ICollidable
    {
        void MovePosition(Direction direction, GameTime gameTime);
        void Update(GameTime gameTime);
        bool Collide(Rectangle collideRec);
        bool CanMove { get; set; }
        void KnockBack(Direction direction, int length);
        Direction CharacterDirection{get; set;}
    }
}
