using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.AStarPathfinding;
using Engine.Controllers;

namespace Engine.Logic
{
    public static class MovementLogic
    {
        // Conditional checks + bools
        public static bool IsLocationMoveable(Tile location)
        {
            // This methods check if a tile is able to be moved on to by a living entity

            if(location.IsWalkable && !location.IsOccupied())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Movement + Pathing
        public static void MoveEntity(LivingEntity entity, Tile destination)
        {
            // This method handles all logic and events related to moving an entity from its
            // current location to a new one

            // Set up
            bool hasCompletedMovement = false;

            // Generate path from entity's current position to the destination
            Stack<Node> path = AStar.GetPath(entity.Position.GridPosition, destination.GridPosition);

            while (hasCompletedMovement == false)
            {
                // Get next tile on the path
                Tile nextLocationOnPath = path.Pop().TileRef;

                // remove entity from its current location
                LivingEntityController.RemoveEntityFromLocation(entity, entity.Position);

                // place entity at next location
                LivingEntityController.PlaceEntityAtLocation(entity, nextLocationOnPath);

                // Resolve events related to moving onto a new location
                // for example, moved onto a tile with an item, pick up the item
                OnNewLocationMovedTo(entity, nextLocationOnPath);

                // if we have reached the final tile in the path, resolve the movement event.
                if(entity.Position == destination)
                {
                    hasCompletedMovement = true;
                }
            }
        }
        public static void OnNewLocationMovedTo(LivingEntity entity, Tile newLocation)
        {
            // This method resolves all events related to an entity moving onto a new tile 
            // e.g. if an item is on the location, pick it up
            // e.g. if this tile is on fire, take damage from stepping on it, etc

            if (WorldController.DoesTileContainAnItem(newLocation))
            {
                ItemController.HandleEntityPickingUpItem(entity, newLocation.MyItem);
            }
        }
    }
}
