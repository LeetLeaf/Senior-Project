using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public abstract class Character
    {
        public string Name { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }

        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public int ExperiencePointValue { get; set; }

        public abstract void ChangeGraphic();
        public abstract bool ResolveAttack();
        public abstract void Draw(SpriteBatch sprite);


        public void MovePosition(Direction direction)
        {
            //let put basic movements here
        }

        public void Initialize(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        


    }
}
