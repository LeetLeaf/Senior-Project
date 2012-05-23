using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    interface IMoveable
    {
        void MovePosition(Direction direction, GameTime gameTime);

    }
}
