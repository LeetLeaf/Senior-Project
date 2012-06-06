using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace com.Kyle.Keebler.Map
{
    public class DungeonTiles : TileManager
    {

        public DungeonTiles (Texture2D Texture)
            :base(Texture)
        {
            TileList = new List<Tile>();
            Tile gravel = new Tile("gravel",Texture, false,new Vector2(0,0)); TileList.Add(gravel);
            Tile wallDownToGravel = new Tile("wallDownToGravel", Texture, true, new Vector2(1, 0)); TileList.Add(wallDownToGravel);
            Tile wallDown = new Tile("wallDown", Texture, true, new Vector2(2, 0)); TileList.Add(wallDown);
            Tile cornerTopRight = new Tile("cornerTopRight", Texture, true, new Vector2(3, 0)); TileList.Add(cornerTopRight);
            Tile cornerTopLeft = new Tile("cornerTopLeft", Texture, true, new Vector2(4, 0)); TileList.Add(cornerTopLeft);
            Tile wallDownCeiling = new Tile("wallDownCeiling", Texture, true, new Vector2(5, 0)); TileList.Add(wallDownCeiling);
            Tile cornerTopRightCeiling = new Tile("cornerTopRightCeiling", Texture, true, new Vector2(6, 0)); TileList.Add(cornerTopRightCeiling);
            Tile cornerTopLeftCeiling = new Tile("cornerTopLeftCeiling", Texture, true, new Vector2(7, 0)); TileList.Add(cornerTopLeftCeiling);
            Tile cornerDownRightCeiling = new Tile("cornerDownRightCeiling", Texture, true, new Vector2(8, 0)); TileList.Add(cornerDownRightCeiling);
            Tile cornerDownLeftCeiling = new Tile("cornerDownLeftCeiling", Texture, true, new Vector2(9, 0)); TileList.Add(cornerDownLeftCeiling);
            Tile wallRightToGravel = new Tile("wallRightToGravel", Texture, true, new Vector2(10, 0)); TileList.Add(wallRightToGravel);
            Tile cornerDownRight = new Tile("cornerDownRight", Texture, true, new Vector2(11, 0)); TileList.Add(cornerDownRight);
            Tile cornerDownLeft = new Tile("cornerDownLeft", Texture, true, new Vector2(12, 0)); TileList.Add(cornerDownLeft);
            Tile cornerDownLeftToGravel = new Tile("cornerDownLeftToGravel", Texture, true, new Vector2(13, 0)); TileList.Add(cornerDownLeftToGravel);
            Tile cornerDownRightToGravel = new Tile("cornerDownRightToGravel", Texture, true, new Vector2(14, 0)); TileList.Add(cornerDownRightToGravel);
            Tile cornerTopRightToGravel = new Tile("cornerTopRightToGravel", Texture, true, new Vector2(15, 0)); TileList.Add(cornerTopRightToGravel);
            Tile cornerTopLeftToGravel = new Tile ("cornerTopLeftToGravel", Texture,true,new Vector2(16,0)); TileList.Add(cornerTopLeftToGravel);
            Tile wallLeftCeiling = new Tile("wallLeftCeiling", Texture, true, new Vector2(17,0)); TileList.Add(wallLeftCeiling);
            Tile wallTopCeiling = new Tile("wallTopCeiling", Texture, true, new Vector2(18,0)); TileList.Add(wallTopCeiling);
            Tile rightCeiling = new Tile("rightCeiling", Texture, true,new Vector2(19,0)); TileList.Add(rightCeiling);
            Tile leftCeiling = new Tile("leftCeiling", Texture, true, new Vector2(20,0)); TileList.Add(leftCeiling);
            Tile ceiling = new Tile ("ceiling", Texture, true, new Vector2(21,0)); TileList.Add(ceiling);
            Tile wallLeftToGravel = new Tile("wallLeftToGravel", Texture, true, new Vector2(22,0)); TileList.Add(wallLeftToGravel);
            Tile wallRightCeiling = new Tile("wallRightCeiling", Texture, true, new Vector2(23,0)); TileList.Add(wallRightCeiling);
            Tile wallLeft = new Tile("wallLeft", Texture, true, new Vector2(24, 0)); TileList.Add(wallLeft);
            Tile wallRight = new Tile("wallRight", Texture, true, new Vector2(25, 0)); TileList.Add(wallRight);
            Tile wallTop = new Tile("wallTop", Texture, true, new Vector2(26, 0)); TileList.Add(wallTop);
            Tile wallTopToGravel = new Tile("wallTopToGravel", Texture, true, new Vector2(27, 0)); TileList.Add(wallTopToGravel);
        }
    }
}
