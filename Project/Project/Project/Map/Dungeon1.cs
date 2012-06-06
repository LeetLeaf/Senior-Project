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

            testCharacter = new Enemy(Game1.Textures["blackKnight"], new Vector2(250, 250), theMap, MapBoundry);
            enemy2 = new Enemy(Game1.Textures["blackKnight"], new Vector2(250, 350), theMap, MapBoundry);

            basicSword = new Sword("Basic Sword", Game1.Textures["sword"], new Vector2(200, 300), ItemType.Weapon);

            MovingElements.Add(player);
            MovingElements.Add(testCharacter);
            MovingElements.Add(enemy2);
            ImmovableObjects.AddRange(datasource.GetCollisionTiles());
            ItemsAvailable.Add(basicSword);

        }

        public override void Draw(GameTime gameTime)
        {
            MapSpriteBatch.Begin();
            datasource.Draw(MapSpriteBatch);
            userPlayer.Draw(MapSpriteBatch);
            testCharacter.Draw(MapSpriteBatch);
            enemy2.Draw(MapSpriteBatch);
            if (userPlayer.Attacking || !basicSword.IsPickedUp)
            {
                basicSword.Draw(MapSpriteBatch);
            }
            MapSpriteBatch.End();
        }
    }
}
