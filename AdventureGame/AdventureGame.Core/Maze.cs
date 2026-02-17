using AdventureGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventureGame.Core
{
    public class Maze
    {
        public int width { get; set; }
        public int height { get; set; }
        public char symbol { get; set; }

        // the actual maze is a 2D array of characters.
        public char[,] tiles { get; set; }

        Random random = new();

        public Maze(int width, int height)
        {
            this.width = width;
            this.height = height;
            tiles = new char[width, height];

            CreateTiles();
            PlaceOutsideWalls();
        }

        // CreateTiles() initializes the maze with blank tiles based on width and height.
        public void CreateTiles ()
        {
            for (int x = 0;  x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = '.';
                }
            }
        }

        // PlaceOutsideWalls() sets each outside tile of the maze grid to a wall.
        public void PlaceOutsideWalls ()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || y == 0 || x == (width - 1) || y == (height - 1))
                        tiles[x, y] = '#';
                }
            }
        }

        // PlacePlayer() sets the player's location equal to the player symbol.
        public void PlacePlayer (Player player)
        {
            tiles[player.xPos, player.yPos] = '@';
        }
        
        // PlaceExit() assigns a random tile as the exit after checking to ensure that tile is blank.
        public void PlaceExit ()
        {
            while (true)
            {
                int randomRow = random.Next(1, height - 1);
                int randomCol = random.Next(1, width - 1);

                if (tiles[randomRow, randomCol] == '.')
                { 
                    tiles[randomRow, randomCol] = 'E';
                    break;
                }   
            }
        }

        // PlaceMonster() checks to make sure a random tile is blank, and then assigns the monster symbol to that tile.
        public void PlaceMonster ()
        {
            while (true)
            {
                int randomRow = random.Next(1, height - 1);
                int randomCol = random.Next(1, width - 1);

                if (tiles[randomRow, randomCol] == '.')
                {
                    tiles[randomRow, randomCol] = 'M';
                    break;
                }


            }
            
        }

        // PlaceInsideWalls() creates a hardcoded number of randomized walls inside the maze, calls CheckAround()
        // to make sure there is still a path around the random tiles.
        public void PlaceInsideWalls ()
        {
            int wallCount = 0;
            while (wallCount < 5)
            {
                int randomRow = random.Next(1, height - 1);
                int randomCol = random.Next(1, width - 1);
                if (tiles[randomRow, randomCol] == '.' && CheckAround(randomRow, randomCol) == true)
                {
                    tiles[randomRow, randomCol] = '#';
                    wallCount++;
                }
            }

        }

        // CheckAround() counts how many tiles around the random tile are occupied, returns true if at least one of the tiles around
        // the tile is empty.
        public bool CheckAround (int row, int column)
        {
            int numOccupied = 0;
            int threshold = 3;

            if (tiles[row + 1, column] != '.')
                numOccupied++;
            if (tiles[row, column + 1] != '.')
                numOccupied++;
            if (tiles[row - 1, column] != '.')
                numOccupied++;
            if (tiles[row, column - 1] != '.')
                numOccupied++;

            return (numOccupied >= threshold) ? false : true;

        }

        // PlacePotion() picks a random tile and checks to make sure that tile is empty before setting it to the potion symbol.
        public void PlacePotion ()
        {
            while (true)
            {
                int randomRow = random.Next(1, height - 1);
                int randomCol = random.Next(1, width - 1);
                if (tiles[randomRow, randomCol] == '.')
                {
                    tiles[randomRow, randomCol] = 'P';
                    break;
                }
            }
        }

        // PlaceWeapon() picks a random tile and checks to make sure that tile is empty before setting it to the weapon symbol.
        public void PlaceWeapon()
        {
            while (true)
            {
                int randomRow = random.Next(1, height - 1);
                int randomCol = random.Next(1, width - 1);
                if (tiles[randomRow, randomCol] == '.')
                {
                    tiles[randomRow, randomCol] = 'W';
                    break;
                }
            }
        }
    }
}
    

