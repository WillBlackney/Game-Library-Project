using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Controllers;

namespace Engine.Controllers
{
    public static class WorldObjectController
    {
        public static void PlaceWorldObjectOnTile(WorldObject worldObject, Tile tile)
        {
            worldObject.Position = tile;
            tile.MyWorldObject = worldObject;
        }
        public static void RemoveWorldObjectFromTile(WorldObject worldObject, Tile tile)
        {
            worldObject.Position = null;
            tile.MyWorldObject = null;
        }
    }
}
