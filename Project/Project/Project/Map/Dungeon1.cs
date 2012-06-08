using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Kyle.Keebler.Characters;
using com.Kyle.Keebler.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace com.Kyle.Keebler.Map
{
    public class Dungeon1 : MapBase
    {
        Enemy testCharacter;
        Enemy enemy2;
        Item basicSword;
        TileLayoutDataSource datasource;
        TileManager MapTiles;
        Chest swordChest;
        TextBox textBox;

        public int TimeText { get; set; }
        public bool TextCheck { get; set; }

        private bool swordCheck = false;

        public Dungeon1(SpriteBatch spriteBatch, Rectangle mapBoundry)
            : base(spriteBatch, mapBoundry)
        {
            MapBoundry = mapBoundry;
        }
        public override void LoadContent(Player player, MapBase theMap)
        {
            base.LoadContent(player, theMap);

            player.MapBoundry = MapBoundry;

            MapTiles = new DungeonTiles(Game1.Textures["dungeonTiles"]);

            datasource = new TileLayoutDataSource(@"Map\Dungeon1TileLayout.csv", MapTiles);
            datasource.LoadContent();

            Texture2D playerTexture = Game1.Textures["player"];

            textBox = new TextBox(Game1.gameFont, Game1.Textures["textBox"]);

            testCharacter = new Enemy(Game1.Textures["blackKnight"], new Vector2(175, 350), theMap, MapBoundry);
            enemy2 = new Enemy(Game1.Textures["blackKnight"], new Vector2(550, 350), theMap, MapBoundry);


            basicSword = new Sword("Basic Sword", Game1.Textures["sword"], new Vector2(200, 300), ItemType.Weapon, true);

            swordChest = new Chest(basicSword, new Vector2(400, 200), Game1.Textures["chest"]);

            MovingElements.Add(player);
            MovingElements.Add(testCharacter);
            MovingElements.Add(enemy2);
            ImmovableObjects.AddRange(datasource.GetCollisionTiles());
            ImmovableObjects.Add(swordChest);
            ItemsAvailable.Add(basicSword);

        }
        public override void Update(GameTime gameTime)
        {
            if (!TextCheck)
            {
                foreach (IMoveable moveElement in this.MovingElements)
                {
                    foreach (IRenderable staticObject in this.ImmovableObjects)
                    {
                        if (moveElement.Collide(staticObject.CollisionRec))
                        {
                            //TODO: What to do here
                        }
                    }


                    foreach (IMoveable otherElement in this.MovingElements.Where(
                    m => !m.Equals(moveElement) &&
                    m.CanCollide))
                    {
                        if (moveElement.Collide(otherElement.CollisionRec))
                        {
                            moveElement.CollisionAction(otherElement);

                        }
                    }

                    foreach (Item item in this.ItemsAvailable)
                    {
                        if (moveElement.Collide(item.CollisionRec) && item.CanCollide)
                        {
                            moveElement.CollisionActionItem(item);
                        }
                    }

                    foreach (IRenderable staticObject in this.ImmovableObjects)
                    {
                        if (moveElement.Collide(staticObject.CollisionRec))
                        {
                            //moveElement.CanMove = false;
                            Character character = moveElement as Character;
                            //character.BoundryCollisionReverse(staticObject.CollisionRec);
                            character.KnockBack(Utilities.FlipDirection(Utilities.DirectionTo(staticObject, character)), 2);
                            moveElement.CollisionAction(staticObject);
                        }
                    }

                    if (moveElement is Player)
                    {
                        moveElement.Update(gameTime);
                    }

                }
                foreach (Item item in this.ItemsAvailable)
                {
                    item.Update(gameTime);
                }

                if (basicSword.IsPickedUp)
                {
                    testCharacter.Update(gameTime);
                    enemy2.Update(gameTime);
                    if (!swordCheck)
                    {
                        swordCheck = true;
                        TextCheck = true;
                        TimeText = 2000;
                    }
                }
            }
            TimeText -= gameTime.ElapsedGameTime.Milliseconds;
            if (TimeText < 0)
            {
                TextCheck = false;
            }
        }
        public override void Draw(GameTime gameTime)
        {
            MapSpriteBatch.Begin();
            datasource.Draw(MapSpriteBatch);
            swordChest.Draw(MapSpriteBatch);
            //userPlayer.Draw(MapSpriteBatch);
            testCharacter.Draw(MapSpriteBatch);
            enemy2.Draw(MapSpriteBatch);

            if (userPlayer.CharacterDirection == Direction.North && userPlayer.Attacking)
            {
                basicSword.Draw(MapSpriteBatch);
                userPlayer.Draw(MapSpriteBatch);
            }
            else
            {
                userPlayer.Draw(MapSpriteBatch);

                if ((userPlayer.Attacking && basicSword.IsPickedUp) || (!basicSword.IsPickedUp && !basicSword.InChest))
                {
                    basicSword.Draw(MapSpriteBatch);
                }
            }
            if (basicSword.IsPickedUp && TextCheck)
            {
                textBox.Draw(MapSpriteBatch, "You got the sword now defeat the enemys!!");
            }
            MapSpriteBatch.End();
        }

    }
}
