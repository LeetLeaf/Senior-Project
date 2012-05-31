using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler
{
    public class TileManager
    {
        public List<Tile> TileList { get; set; }

        public TileManager(Texture2D Texture)
        {
            TileList = new List<Tile>();
            Tile grass = new Tile("grass",Texture, false,new Vector2(0,0)); TileList.Add(grass);
            Tile dirt = new Tile("dirt", Texture, false, new Vector2(1, 0)); TileList.Add(dirt);
            Tile grassDirt1 = new Tile("grassDirt1", Texture, false, new Vector2(2, 0)); TileList.Add(grassDirt1);
            Tile grassDirt2 = new Tile("grassDirt2", Texture, false, new Vector2(3, 0)); TileList.Add(grassDirt2);
            Tile tallGrass = new Tile("tallGrass", Texture, false, new Vector2(4, 0)); TileList.Add(tallGrass);
            Tile gravel = new Tile("gravel", Texture, false, new Vector2(5, 0)); TileList.Add(gravel);
            Tile cliff = new Tile("cliff", Texture, true, new Vector2(6, 0)); TileList.Add(cliff);
            Tile stoneWall = new Tile("stoneWall", Texture, true, new Vector2(7, 0)); TileList.Add(stoneWall);
            Tile stoneWallTop = new Tile("stoneWallTop", Texture, true, new Vector2(8, 0)); TileList.Add(stoneWallTop);
        }
    }   
}
