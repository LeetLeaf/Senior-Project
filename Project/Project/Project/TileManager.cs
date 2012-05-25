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
            Tile grass = new Tile(Texture, false); TileList.Add(grass);
            Tile dirt = new Tile(Texture, false); TileList.Add(dirt);
            Tile grassDirt1 = new Tile(Texture, false); TileList.Add(grassDirt1);
            Tile grassDirt2 = new Tile(Texture, false); TileList.Add(grassDirt2);
            Tile tallGrass = new Tile(Texture, false); TileList.Add(tallGrass);
            Tile gravel = new Tile(Texture, false); TileList.Add(gravel);
            Tile cliff = new Tile(Texture, true); TileList.Add(cliff);
            Tile stoneWall = new Tile(Texture, true); TileList.Add(stoneWall);
            Tile stoneWallTop = new Tile(Texture, true); TileList.Add(stoneWallTop);
        }

    }   
}
