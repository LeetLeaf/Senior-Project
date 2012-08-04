using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using com.Kyle.Keebler.Map;
using com.Kyle.Keebler.Items;

namespace com.Kyle.Keebler.Characters
{
    public class Player : Character
    {
        //Properties
        public bool showItems {get; set;}
        public Inventory PlayerItems {get;set;}
        public SpriteFont HealthHUDFont { get; set; }
        
        private MapBase theMap;
        private Camera camera;

        public Player(Texture2D PlayerTexture, Vector2 Position,Texture2D InventoryTexture, SpriteFont HealthHUDFont, MapBase theMap)
        {
            this.Texture = PlayerTexture;
            PlayerItems = new Inventory(InventoryTexture);
            this.Position = Position;
            this.HealthHUDFont = HealthHUDFont;
            this.theMap = theMap;
            FrameSize = new Point(18, 24);
            MaxHealth = 6;
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

           attackFrames = new Dictionary<Direction, Tuple<Point, Point>>();
            attackFrames.Add(Direction.North,
                new Tuple<Point,Point>(new Point(3,4),new Point(3,4)));
            attackFrames.Add(Direction.South,
                new Tuple<Point,Point>(new Point(3,1),new Point(3,1)));
            attackFrames.Add(Direction.West,
                new Tuple<Point,Point>(new Point(0,2),new Point(1,2)));
            attackFrames.Add(Direction.East,
                new Tuple<Point,Point>(new Point(3,3),new Point(3,3)));


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

        public void setCamera(Camera camera)
        {
            this.camera = camera;
        }

        public Camera getCamera()
        {
            return camera;
        }

        public override void Update(GameTime gameTime)
        {
            if (CanMove)
            {  
                if (Keyboard.GetState().IsKeyDown(Keys.T))
                {
                    showItems = !showItems;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
                {
                    MovePosition(Direction.West, gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
                {
                    MovePosition(Direction.East, gameTime);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
                {
                    MovePosition(Direction.South, gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)
                {
                    MovePosition(Direction.North, gameTime);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.X) || GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    AttackCharacter(gameTime, CharacterDirection);
                    Attacking = true;
                }
                else 
                {
                    Attacking = false;
                }
                //Idle
                if (Keyboard.GetState().IsKeyUp(Keys.Down) && Keyboard.GetState().IsKeyUp(Keys.Up)
                    && Keyboard.GetState().IsKeyUp(Keys.Right) && Keyboard.GetState().IsKeyUp(Keys.Left)
                    && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X == 0 && GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y == 0)
                {
                    IdleCharacter(gameTime, CharacterDirection);

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
            //spriteBatch.DrawString(HealthHUDFont, "Player's Health: " + CurrentHealth + "/" + MaxHealth,
            //  new Vector2(camera.center.X + 200,camera.center.Y+150), Color.White);
            DrawLife(spriteBatch);
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
                TimeToWait = 300;

                collidedEnemy.TimeToWait = 800;
                collidedEnemy.CanMove = false;
            }
            if (collisionElement is Chest)
            { 
                Chest thisChest = collisionElement as Chest;
                if (Utilities.DirectionTo(this, thisChest) == Direction.North && this.Attacking)
                {
                    PlayerItems.InventoryList.Add(thisChest.chestItem);
                    thisChest.empty = true;
                    thisChest.chestItem.InChest = false;
                    thisChest.chestItem.PickMeUp(this);
                    
                }
            }
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

        public void DrawLife(SpriteBatch spriteBatch)
        {
            
            switch(CurrentHealth)
            {
                case 6:
                    for (int i = 0; i < CurrentHealth / 2; i++)
                    {
                        spriteBatch.Draw(Game1.Textures["heartFull"],
                            new Vector2(camera.center.X + 200 + (i * 32 + i*3), camera.center.Y + 150), Color.White);
                    }
                break;

                case 5:
                    spriteBatch.Draw(Game1.Textures["heartHalf"],
                        new Vector2(camera.center.X + 200 + 2 * 32 + 2 * 3,camera.center.Y + 150), Color.White);
                    for (int i = 0; i < CurrentHealth / 2; i++)
                    {
                        spriteBatch.Draw(Game1.Textures["heartFull"],
                            new Vector2(camera.center.X + 200 + (i * 32 + i * 3), camera.center.Y + 150), Color.White);
                    }
                break;
                
                case 4:
                    spriteBatch.Draw(Game1.Textures["heartEmpty"],
                        new Vector2(camera.center.X + 200 + 2 * 32 + 2 * 3, camera.center.Y + 150), Color.White);
                    for (int i = 0; i < CurrentHealth / 2; i++)
                    {
                        spriteBatch.Draw(Game1.Textures["heartFull"],
                            new Vector2(camera.center.X + 200 + (i * 32 + i * 3), camera.center.Y + 150), Color.White);
                    }
                break;

                case 3:
                    spriteBatch.Draw(Game1.Textures["heartEmpty"],
                        new Vector2(camera.center.X + 200 + 2 * 32 + 2 * 3, camera.center.Y + 150), Color.White);
                    spriteBatch.Draw(Game1.Textures["heartHalf"],
                        new Vector2(camera.center.X + 200 + 1 * 32 + 1 * 3, camera.center.Y + 150), Color.White);
                    spriteBatch.Draw(Game1.Textures["heartFull"],
                        new Vector2(camera.center.X + 200 + (0 * 32 + 0 * 3), camera.center.Y + 150), Color.White);
                break;
                
                case 2:
                    for (int i = 1 ; i < MaxHealth / 2; i++)
                    {
                        spriteBatch.Draw(Game1.Textures["heartEmpty"],
                            new Vector2(camera.center.X + 200 + (i * 32 + i * 3), camera.center.Y + 150), Color.White);
                    }
                    spriteBatch.Draw(Game1.Textures["heartFull"],
                       new Vector2(camera.center.X + 200 + (0 * 32 + 0 * 3), camera.center.Y + 150), Color.White);
                break;

                case 1:
                    for (int i = 1; i < MaxHealth / 2; i++)
                    { 
                        spriteBatch.Draw(Game1.Textures["heartEmpty"],
                            new Vector2(camera.center.X + 200 + (i * 32 + i * 3), camera.center.Y + 150), Color.White);
                    }
                    spriteBatch.Draw(Game1.Textures["heartHalf"],
                        new Vector2(camera.center.X + 200 + (0 * 32 + 0 * 3), camera.center.Y + 150), Color.White);
               break;
            }

        }

    }
}
