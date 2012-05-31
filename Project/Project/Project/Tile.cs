using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace com.Kyle.Keebler
{
    public class Tile : IRenderable, ICloneable
    {

        public string TileName {get; set;}
        public Texture2D Texture { get; set; }
        public Point FrameSize { get; set; }
        public Vector2 TilesFrame { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle CollisionRec
        {
            get
            {
                return new Rectangle(
                    (int)Position.X + 5,
                    (int)Position.Y + 5,
                    FrameSize.X - 5,
                    FrameSize.Y - 5);
            }
        }

        public bool CanCollide { get; set; }

        public Tile(string TileName, Texture2D Texture,bool CanCollide,Vector2 TilesFrame)
        {
            this.TileName = TileName;
            this.Texture = Texture;
            this.CanCollide = CanCollide;
            this.TilesFrame = TilesFrame;
            FrameSize = new Point(16, 16);
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public Rectangle renderFrame()
        {
            return new Rectangle((int)TilesFrame.X * (int)FrameSize.X,
                (int)TilesFrame.Y * (int)FrameSize.Y,
                (int)FrameSize.X, (int)FrameSize.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, renderFrame(), Color.White);
        }

        public void CollisionAction(ICollidable impactedElement)
        {
            throw new NotImplementedException();
        }

        public void CollisionActionItem(Item impactedElement)
        {
            throw new NotImplementedException();
        }

        #region ICloneable Members

        public object Clone()
        {
            Tile newTile = new Tile(this.TileName, this.Texture, this.CanCollide, this.TilesFrame);
            return newTile;
        }

        #endregion
    }
}
