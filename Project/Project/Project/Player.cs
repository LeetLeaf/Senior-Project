using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace com.Kyle.Keebler
{
    public class Player : Character
    {
        //Properties
        public bool showItems {get; set;}
        public Inventory PlayerItems {get;set;}
        public SpriteFont HealthHUDFont { get; set; }

        private MapBase theMap;

        public Player(Texture2D PlayerTexture, Vector2 Position,Texture2D InventoryTexture, SpriteFont HealthHUDFont, MapBase theMap)
        {
            this.Texture = PlayerTexture;
            PlayerItems = new Inventory(InventoryTexture);
            this.Position = Position;
            this.HealthHUDFont = HealthHUDFont;
            this.theMap = theMap;
            FrameSize = new Point(18, 24);
            MaxHealth = 5;
            CurrentHealth = MaxHealth;
            CanMove = true;
            showItems = false;

            movementRate = 2;

            walkFrames = new Dictionary<Direction,Tuple<Point,Point>>();
            walkFrames.Add(Direction.North, 
                new Tuple<Point, Point>(new Point(0, 4),new Point(4, 4)));
            walkFrames.Add(Direction.South, 
                new Tuple<Point, Point>(new Point(0, 1), new Point(4, 1)));
            walkFrames.Add(Direction.West, 
                new Tuple<Point, Point>(new Point(0, 2), new Point(4, 2)));
           walkFrames.Add(Direction.East, 
                new Tuple<Point, Point>(new Point(0, 3), new Point(4, 3)));

            idleFrames = new Dictionary<Direction,Tuple<Point,Point>>();
            idleFrames.Add(Direction.North, 
                new Tuple<Point,Point>(new Point(0, 4), new Point(0, 4)));
            idleFrames.Add(Direction.South, 
                new Tuple<Point, Point>(new Point(0, 0), new Point(0, 0)));
            idleFrames.Add(Direction.West, 
                new Tuple<Point, Point>(new Point(0, 2), new Point(0, 2)));
           idleFrames.Add(Direction.East, 
                new Tuple<Point, Point>(new Point(0, 3), new Point(0, 3)));


        }

        public override void ChangeGraphic()
        {
            throw new NotImplementedException();
        }
        
        public override bool ResolveAttack()
        {
            if (PlayerItems.InventoryList.Count > 0)
            {
                if (PlayerItems.InventoryList[0].TypeOfItem == ItemType.Weapon)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
                return false;
        }

        public override void Update(GameTime gameTime)
        {
            if (CanMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.T))
                {
                    showItems = !showItems;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    MovePosition(Direction.West, gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    MovePosition(Direction.East, gameTime);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    MovePosition(Direction.South, gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    MovePosition(Direction.North, gameTime);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.X))
                {
                    ResolveAttack();
                }
            }
            else
            {
                TimeToWait -= gameTime.ElapsedGameTime.Milliseconds;
                if (TimeToWait < 0)
                {
                    CanMove = true;
                }
            }
            //Idle
            if (Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up)
                && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left))
            {
                IdleCharacter(gameTime, CharacterDirection);
                
            }

            if (CurrentHealth <= 0)
            {
                Position = new Vector2(0, 0);
                CurrentHealth = MaxHealth;
            }
            BoundryCollision(MapBoundry);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position,
                renderFrame(), Color.White);
            spriteBatch.DrawString(HealthHUDFont, "Health: " + CurrentHealth + "/" + MaxHealth,
                Vector2.Zero, Color.White);
        }

        public override bool Collide(Rectangle collideRec)
        {
            bool collision = base.Collide(collideRec);
            if (collision)
            {
            }
            return collision;
        }

        public override void CollisionAction(ICollidable collisionElement)
        {
            if (collisionElement is Enemy) 
            {

                Enemy collidedEnemy = collisionElement as Enemy;
                KnockBack(Utilities.FlipDirection(collidedEnemy.CharacterDirection),15);
                if(BoundryCollision(theMap.MapBoundry))
                {
                    collidedEnemy.KnockBack(collidedEnemy.CharacterDirection, 15);
                }
                CurrentHealth -= 1;
                CanMove = false;
                TimeToWait = 500;

                collidedEnemy.TimeToWait = 800;
                collidedEnemy.CanMove = false;
            }
            //if (collisionElement)
            //{
            //    basicSword.isPickedUp = true;
            //    playerItems.InventoryList.Add(basicSword);
            //}
        }

        public override void CollisionActionItem(Item item)
        {

            item.PickMeUp(this);
            //item.IsPickedUp = true;
            ////item.CanCollide = false;
            //item.CollisionAction(this);
            //item.HeldBy = this;
            PlayerItems.InventoryList.Add(item);
            
        }

    }
}
