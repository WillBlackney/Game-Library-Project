using System;
using System.Collections.Generic;
using Engine.Models;
using Engine.Logic;
using System.Linq;

namespace Engine.Controllers
{
    public static class WorldController
    {
        // Properties + Variables
        #region
        public static World currentWorld;
        #endregion

        // World Creation Logic
        #region
        public static void SetWorldObjectAsCurrentWorld(World world)
        {
            currentWorld = world;
        }
        public static World CreateNewWorld(int xSize, int ySize)
        {
            // Create blank world object
            World world = new World(xSize, ySize);

            // Create tiles
            for(int xPositions = 0; xPositions < xSize; xPositions++) // x positions
            {
                for (int yPositions = 0; yPositions < ySize; yPositions++) // y positions
                {
                    PlaceTileInWorld(xPositions, yPositions, world);
                }
            }

            return world;
        }
        public static Tile PlaceTileInWorld(int xPosition, int yPosition, World worldParent)
        {
            // Create new tile
            Tile tile = new Tile(xPosition, yPosition);

            // Connect tile and world references together
            tile.MyWorld = worldParent;
            worldParent.Tiles.Add(tile.GridPosition, tile);

            return tile;
        }
        #endregion

        // Conditional checks + bools
        #region
        public static bool IsTileAInRangeOfTileB(Tile a, Tile b, int range)
        {
            int distance = GetDistanceBetweenTwoLocations(a, b);

            if (distance <= range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsPointInBounds(Point position, World world)
        {
            return position.X >= 0 && position.Y >= 0 && position.X < world.XLength && position.Y < world.YLength;
        }
        public static bool DoesTileContainAnItem(Tile tile)
        {
            if(tile.MyItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        // Get tiles world data logic
        #region
        public static List<Tile> GetAllValidMoveableTilesForEntities(World world)
        {
            // This method checks every tile in a world object, and returns all tiles
            // that a living entity is able to move onto and over

            List<Tile> tilesReturned = new List<Tile>();

            foreach (Tile tile in GetAllTilesFromWorldDictionary(world))
            {
                if (MovementLogic.IsLocationMoveable(tile))
                {
                    tilesReturned.Add(tile);
                }
            }

            return tilesReturned;
        }
        public static List<Tile> GetAllValidNewItemLocationTiles(World world)
        {
            // This method checks every tile in a world object, and returns all tiles
            // that would be a valid location to create a new item.

            List<Tile> tilesReturned = new List<Tile>();

            foreach (Tile tile in GetAllTilesFromWorldDictionary(world))
            {
                if (MovementLogic.IsLocationMoveable(tile) &&
                    tile.MyItem == null)
                {
                    tilesReturned.Add(tile);
                }
            }

            return tilesReturned;
        }
        public static Tile GetWorldCentreTile(World world)
        {
            Tile centreTile = null;

            int xCenter = world.XLength / 2;
            int yCentre = world.YLength / 2;

            foreach (Tile tile in GetAllTilesFromWorldDictionary(world))
            {
                if (tile.GridPosition.X == xCenter &&
                   tile.GridPosition.Y == yCentre)
                {
                    centreTile = tile;
                    break;
                }
            }

            return centreTile;
        }
        public static List<Tile> GetAllTilesFromWorldDictionary(World world)
        {
            List<Tile> listReturned = new List<Tile>();

            for (int index = 0; index < world.Tiles.Count; index++)
            {
                listReturned.Add(world.Tiles.ElementAt(index).Value);
            }

            return listReturned;
        }
        public static Tile GetTileFromPointReference(Point point, World world)
        {
            Tile tileReturned = null;

            for (int index = 0; index < currentWorld.Tiles.Count; index++)
            {
                if (world.Tiles.ElementAt(index).Value.GridPosition == point)
                {
                    tileReturned = world.Tiles.ElementAt(index).Value;
                    break;
                }
            }

            return tileReturned;
        }
        public static int GetDistanceBetweenTwoLocations(Tile a, Tile b)
        {
            // get absolute difference in both x and y axis'
            int yDistance = (int)MathF.Abs(a.GridPosition.X - b.GridPosition.X);
            int xDistance = (int)MathF.Abs(a.GridPosition.Y - b.GridPosition.Y);

            // return the largest distance value (x or y?)
            if (xDistance >= yDistance)
            {
                return xDistance;
            }
            else
            {
                return yDistance;
            }

        }
        #endregion
    }
}
