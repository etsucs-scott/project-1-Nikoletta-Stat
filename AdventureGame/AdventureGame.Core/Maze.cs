using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Maze
    {
        public int width { get; }
        public int height { get; }
        public MazeTile[,] tiles { get; }
        public Random random = new Random();

        // CreateTiles() initializes the maze with blank tiles based on width and height.
        public void CreateTiles ()
        {
            for (int x = 0;  x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new MazeTile();
                }
            }
        }

        public void PlaceOutsideWalls ()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == (width - 1) || y == (height - 1))
                        tiles[x, y].isWall = true;
                }
            }
        }





    }
}
    