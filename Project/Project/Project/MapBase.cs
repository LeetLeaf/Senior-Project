using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler
{
    public class MapBase
    {
        //public List<IMoveable> EnemyPlayers { get; set; }
        //public List<Character> NonEnemyNpcs { get; set; }
        public List<IMoveable> MovingElements { get; set; }
        public List<IRenderable> ImmovableObjects { get; set; }
        public List<Item> ItemsAvailable { get; set; }
        public Player userPlayer;

        public Entrance MainEntrance { get; set; }
        public List<Entrance> Exits { get; set; }

        public SpriteBatch MapSpriteBatch{get;set;}

        public Rectangle MapBoundry { get; protected set; }


        public MapBase(SpriteBatch spriteBatch, Rectangle mapBoundry)
        {
            MapSpriteBatch = spriteBatch;
            MovingElements = new List<IMoveable>();
            ImmovableObjects = new List<IRenderable>();
            ItemsAvailable = new List<Item>();
            MainEntrance = new Entrance();
            Exits = new List<Entrance>();

            MapBoundry = mapBoundry;
        }

        public virtual void LoadContent(Player player)
        {
            userPlayer = player;

        }

        public virtual void Draw(GameTime gameTime)
        {
        }
    }
}
