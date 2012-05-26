using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Kyle.Keebler
{
    public class MapBase
    {
        public List<IMoveable> EnemyPlayers { get; set; }
        public List<Character> NonEnemyNpcs { get; set; }
        public List<IRenderable> ImmovableObjects { get; set; }

        public Entrance MainEntrance { get; set; }
        public List<Entrance> Exits { get; set; }
    }
}
