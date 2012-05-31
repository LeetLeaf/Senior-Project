using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using com.Kyle.Keebler.Characters;
using com.Kyle.Keebler.Items;

namespace com.Kyle.Keebler.Map
{
    public class BeginingMap : MapBase
    {
        Enemy testCharacter;
        Enemy enemy2;
        Item basicSword;
        TileLayoutDataSource datasource;

        public BeginingMap(SpriteBatch spriteBatch, Rectangle mapBoundry) 
            : base(spriteBatch, mapBoundry)
        {
            
        }

        public override void LoadContent(Player player, MapBase theMap)
        {
            base.LoadContent(player,theMap);

            player.MapBoundry = MapBoundry;

            datasource = new TileLayoutDataSource(@"Map\BeginingMapTileLayout.csv", Game1.Textures["tiles"]);
            datasource.LoadContent();

            Texture2D playerTexture = Game1.Textures["player"];
            
            testCharacter = new Enemy(Game1.Textures["blackKnight"], new Vector2(250, 250),theMap,MapBoundry);
            enemy2 = new Enemy(Game1.Textures["blackKnight"], new Vector2(500, 500), theMap, MapBoundry);

            basicSword = new Sword("Basic Sword", Game1.Textures["sword"], new Vector2(200, 50), ItemType.Weapon);

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
            //if (!basicSword.IsPickedUp)
                basicSword.Draw(MapSpriteBatch);

            MapSpriteBatch.End();
        }
    }
}
