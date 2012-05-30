using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler
{
    public class BeginingMap : MapBase
    {
        Enemy testCharacter;
        Enemy enemy2;
        Item basicSword;

        public BeginingMap(SpriteBatch spriteBatch, Rectangle mapBoundry) 
            : base(spriteBatch, mapBoundry)
        {
        }

        public override void LoadContent(Player player, MapBase theMap)
        {
            base.LoadContent(player,theMap);

            player.MapBoundry = MapBoundry;

            Texture2D playerTexture = Game1.Textures["player"];
            
            testCharacter = new Enemy(Game1.Textures["blackKnight"], new Vector2(250, 250),theMap,MapBoundry);
            enemy2 = new Enemy(Game1.Textures["blackKnight"], new Vector2(500, 500), theMap, MapBoundry);

            basicSword = new Sword("Basic Sword", Game1.Textures["sword"], new Vector2(200, 50), ItemType.Weapon);

            MovingElements.Add(player);
            MovingElements.Add(testCharacter);
            MovingElements.Add(enemy2);

            ItemsAvailable.Add(basicSword);
        }

        public override void Draw(GameTime gameTime)
        {
            MapSpriteBatch.Begin();
            userPlayer.Draw(MapSpriteBatch);
            testCharacter.Draw(MapSpriteBatch);
            enemy2.Draw(MapSpriteBatch);
            //if (!basicSword.IsPickedUp)
                basicSword.Draw(MapSpriteBatch);

            MapSpriteBatch.End();
        }
    }
}
