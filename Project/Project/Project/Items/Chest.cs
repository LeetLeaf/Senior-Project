using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler.Items
{
    public class Chest : IRenderable
    {
        public bool CanCollide { get; set; }
        public bool empty { get; set;}
        public Item chestItem { get; set; }
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        
        private Vector2 CurrentFrame;
        private Point FrameSize;

        public Chest(Item item, Vector2 Position,Texture2D Texture)
        {
            this.Texture = Texture; 
            CurrentFrame = new Vector2(0,0);
            FrameSize = new Point(16,16);
            this.Position = Position;
            CanCollide = true;
            chestItem = item;
            empty = false;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }     
        public void Draw(SpriteBatch spriteBatch)
        {
            if (empty)
            {
                CurrentFrame.X = 1;

            }
            else if (!empty)
            {
                CurrentFrame.Y = 0;
            }
            spriteBatch.Draw(Texture, Position, renderFrame, Color.White); 
           
        }

        public Rectangle renderFrame
        {
            get
            {
                return new Rectangle((int)CurrentFrame.X * (int)FrameSize.X,
                    (int)CurrentFrame.Y * (int)FrameSize.Y,
                    (int)FrameSize.X, (int)FrameSize.Y);
            }
        }
        public Vector2 getPosition()
        {
            return Position;
        }

        public Point getFrameSize()
        {
            return FrameSize;
        }

        public Rectangle CollisionRec
        {
            get 
            {
                return new Rectangle(
                    (int)Position.X,
                    (int)Position.Y,
                    FrameSize.X,
                    FrameSize.Y);
            }
        }


        public void CollisionAction(ICollidable impactedElement)
        {
            throw new NotImplementedException();
        }

        public void CollisionActionItem(Item impactedElement)
        {
            throw new NotImplementedException();
        }
    }
}
