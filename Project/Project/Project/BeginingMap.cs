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
        Item basicSword;

        public BeginingMap(SpriteBatch spriteBatch) : base(spriteBatch)
        {
        }

        public override void LoadContent(Player player)
        {
            base.LoadContent(player);

            player.MapBoundry = MapBoundry;

            Texture2D playerTexture = Game1.Textures["player"];
            
            testCharacter = new Enemy(Game1.Textures["blackKnight"], new Vector2(250, 250),player,MapBoundry);
            basicSword = new Sword("Basic Sword", Game1.Textures["sword"], new Vector2(200, 50), ItemType.Weapon);

            MovingElements.Add(player);
            MovingElements.Add(testCharacter);

            ItemsAvailable.Add(basicSword);
        }

        public override void Draw(GameTime gameTime)
        {
            MapSpriteBatch.Begin();
            userPlayer.Draw(MapSpriteBatch);
            testCharacter.Draw(MapSpriteBatch);
            if (!basicSword.IsPickedUp)
                basicSword.Draw(MapSpriteBatch);

            MapSpriteBatch.End();
        }
    }
}
