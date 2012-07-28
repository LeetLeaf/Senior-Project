using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public class TextBox : IRenderable
    {

        public SpriteFont spriteFont { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D textBox { get; set; }
        public Vector2 TextPosition { get; set; }

        private Camera gameCamera;
        
        public TextBox(SpriteFont spriteFont, Texture2D textBox)
        {
            this.spriteFont = spriteFont;
            this.textBox = textBox;
            //Position = new Vector2(10, 250);
            //TextPosition = new Vector2(40, 270);
        }
        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBatch,string message)
        {
            Position = new Vector2(gameCamera.center.X + 205, gameCamera.center.Y + 330);
            TextPosition = new Vector2(gameCamera.center.X + 225, gameCamera.center.Y + 340);
            spriteBatch.Draw(textBox, Position, textBox.Bounds, Color.White, 0, Vector2.Zero, 6.5f, SpriteEffects.None, 0);
            string messageFormated = "";
            bool check = false;
            for (int i = 0; i < message.Length; i++)
            {
                messageFormated += message.Substring(i, 1);
                if (i > 42 && !check)
                {
                    messageFormated += "\n";
                    check = true;
                }
            }
            
            spriteBatch.DrawString(spriteFont, messageFormated, TextPosition, Color.White,0f,Vector2.Zero,0.75f,SpriteEffects.None,0);
            
        }

        public void setCamera(Camera camera)
        {
            gameCamera = camera;
        }

        public Vector2 getPosition()
        {
            throw new NotImplementedException();
        }

        public Point getFrameSize()
        {
            throw new NotImplementedException();
        }

        public Rectangle CollisionRec
        {
            get { throw new NotImplementedException(); }
        }

        public bool CanCollide
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void CollisionAction(ICollidable impactedElement)
        {
            throw new NotImplementedException();
        }

        public void CollisionActionItem(Items.Item impactedElement)
        {
            throw new NotImplementedException();
        }
    }
}
