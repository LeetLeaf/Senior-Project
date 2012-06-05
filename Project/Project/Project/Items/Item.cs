using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using com.Kyle.Keebler.Characters;


namespace com.Kyle.Keebler.Items
{
    public class Item : IRenderable
    {
        public string Name { get; set; }
        public ItemType TypeOfItem { get; set; }
        public int ExperiencePointValue { get; private set; }
        public Vector2 Position;
        public Texture2D Texture { get; set; }
        public bool CanCollide { get; set; }
        public bool IsPickedUp { get; set; }
        public Character HeldBy { get; set; }

        public Rectangle CollisionRec
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + 2, (int)Position.Y + 2,
                    Texture.Width -2, Texture.Height -2);
                
            }
        }


        public Item()
        { }

        public Item(String Name, Texture2D Texture, Vector2 Position, ItemType TypeOfItem)
        {
            this.Name = Name;
            this.Texture = Texture;
            this.Position = Position;
            this.TypeOfItem = TypeOfItem;
            
        }

        public Vector2 getPosition()
        {
            return Position;
        }

       

        #region IRenderable Members

        public void Update(GameTime gameTime)
        {
            if (IsPickedUp && HeldBy != null)
            {
                if (HeldBy.CharacterDirection == Direction.West)
                {
                    Position.X = HeldBy.CollisionRec.Center.X - (HeldBy.CollisionRec.Width / 2) - Texture.Width;
                    Position.Y = HeldBy.CollisionRec.Center.Y + 5;
                }
                else if (HeldBy.CharacterDirection == Direction.North)
                {
                    Position.X = HeldBy.CollisionRec.Center.X;
                    Position.Y = HeldBy.CollisionRec.Center.Y - (HeldBy.CollisionRec.Height / 2);
                }
                else if (HeldBy.CharacterDirection == Direction.South)
                {
                    Position.X = HeldBy.CollisionRec.Center.X;
                    Position.Y = HeldBy.CollisionRec.Center.Y + (HeldBy.CollisionRec.Height / 2);
                }
                else // Direction.East
                {
                    Position.X = HeldBy.CollisionRec.Center.X + (HeldBy.CollisionRec.Width / 2) + Texture.Width/2;
                    Position.Y = HeldBy.CollisionRec.Center.Y - 4;
                }
            }
            if (HeldBy != null)
            {
                if (HeldBy.Attacking || !IsPickedUp)
                {
                    CanCollide = true;
                }
                else
                {
                    CanCollide = false;
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        
        

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void CollisionAction(ICollidable collisionElement)
        {

        }

        public void CollisionActionItem(Item item)
        {

        }
        public virtual void PickMeUp(Character pickedUpBy)
        {
            this.IsPickedUp = true;
            this.HeldBy = pickedUpBy;
        }

        public Point getFrameSize()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
