using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using System.Data;
using System.Data.OleDb;
using System.IO;
using Microsoft.Xna.Framework;

namespace com.Kyle.Keebler.Map
{
    
    public class TileLayoutDataSource
    {
        private string datasource;
        private SpriteBatch spriteBatch;
        private int pixelMultiplier;
        private TileManager MapTiles;
        private List<Tile> TileList;

        DataSet data = new DataSet();
        //800x600
        //50x37.5
        public TileLayoutDataSource(string resource, TileManager MapTiles)
        {
            pixelMultiplier = 16;
            this.MapTiles = MapTiles;
            TileList = new List<Tile>();

            datasource = resource;
            
            //string file = System.IO.Path.GetFileName(resource);
            FileInfo fi = new FileInfo(resource);
            OleDbConnection excelConnection = new OleDbConnection
            (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fi.DirectoryName + ";Extended Properties=Text;");
            OleDbCommand cmd = new OleDbCommand(string.Format("SELECT * FROM [{0}]",fi.Name), excelConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            excelConnection.Open();
            data = new DataSet();
            adapter.Fill(data);
            excelConnection.Close(); excelConnection.Dispose(); excelConnection = null;
            cmd.Dispose(); cmd = null;
            adapter.Dispose(); adapter = null;

        }

        public void LoadContent()
        {
            int TileIndex; 
            for (int i = 0; i < data.Tables[0].Rows.Count; i++)
            {
                for (int j = 0; j < data.Tables[0].Columns.Count; j++)
                {
                    TileIndex = Convert.ToInt32(data.Tables[0].Rows[i][j]);

                    Tile currentTile = MapTiles.TileList[TileIndex].Clone() as Tile;
                    
                    currentTile.Position = new Vector2(j * pixelMultiplier, i * pixelMultiplier);
                    //TileIndex = (int)data.Tables[0].Rows[i][j];
                    //MapTiles.TileList[TileIndex].Draw(sprite);
                    TileList.Add(currentTile);
                    /*
                    MapTiles.TileList[TileIndex].Texture,
                       new Vector2(j * pixelMultiplier, i * pixelMultiplier),
                       MapTiles.TileList[TileIndex].renderFrame(),
                       Color.White)
                     */
                }
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            foreach (Tile tile in TileList)
            {
                tile.Draw(sprite);
            }
        }

        internal IEnumerable<IRenderable> GetCollisionTiles()
        {
            return TileList.Where(t => t.CanCollide);

            //List<IRenderable> CollisionTiles = new List<IRenderable>();
            //foreach(Tile tile in TileList)
            //{
            //        if (tile.CanCollide)
            //        {
            //            CollisionTiles.Add(tile);
            //        }
            //}
            //return CollisionTiles;
        }
    }
}
