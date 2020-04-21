using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using Engine.Models;
using Engine.Controllers;


namespace Engine.AStarPathfinding
{
    public static class AStar
    {
        private static Dictionary<Point, Node> nodes;


        // Create a node for every tile in the game
        private static void CreateNodes()
        {
            // Create a new dictionary
            nodes = new Dictionary<Point, Node>();

            // Loop through all tiles in the game
            foreach (Tile tile in WorldController.GetAllTilesFromWorldDictionary(WorldController.currentWorld))
            {
                // Add the node to the node dictionary
                nodes.Add(tile.GridPosition, new Node(tile));
            }
        }

        public static Stack<Node> GetPath(Point start, Point goal)
        {
            if (nodes == null)
            {
                CreateNodes();
            }

            World world = WorldController.currentWorld;

            HashSet<Node> openList = new HashSet<Node>();

            HashSet<Node> closedList = new HashSet<Node>();

            Stack<Node> finalPath = new Stack<Node>();
            Node currentNode = nodes[start];

            openList.Add(currentNode);

            while (openList.Count > 0)
            {

                for (int x = -1; x <= 1; x++)
                {

                    for (int y = -1; y <= 1; y++)
                    {
                        Point neighbourPos = new Point(currentNode.GridPosition.X - x, currentNode.GridPosition.Y - y);
                        Tile tile = WorldController.GetTileFromPointReference(neighbourPos, world);

                        if (WorldController.IsPointInBounds(neighbourPos, world) && tile.IsWalkable && tile.IsOccupied() == false &&
                            neighbourPos != currentNode.GridPosition)
                        {
                            int gCost = 0;
                            if (Math.Abs(x - y) == 1)
                            {
                                gCost = 10;
                            }
                            else
                            {
                                gCost = 14;
                            }

                            Node neighbour = nodes[neighbourPos];


                            if (openList.Contains(neighbour))
                            {
                                if (currentNode.G + gCost < neighbour.G)
                                {
                                    neighbour.CalcValues(currentNode, nodes[goal], gCost);
                                }
                            }

                            else if (!closedList.Contains(neighbour))
                            {
                                openList.Add(neighbour);
                                neighbour.CalcValues(currentNode, nodes[goal], gCost);
                            }
                        }

                    }
                }

                openList.Remove(currentNode);
                closedList.Add(currentNode);

                if (openList.Count > 0)
                {
                    // Sort the list by F values, then select the first from the list
                    currentNode = openList.OrderBy(n => n.F).First();
                }

                if (currentNode == nodes[goal])
                {
                    while (currentNode.GridPosition != start)
                    {
                        finalPath.Push(currentNode);
                        currentNode = currentNode.Parent;
                    }
                    break;
                }
            }

            return finalPath;
        }

        // Prevents entities moving diagonally between two other entities / world objects
        private static bool ConnectedDiagonally(Node currentNode, Node neighbourNode, World world)
        {
            Point direction = neighbourNode.GridPosition - currentNode.GridPosition;
            Point first = new Point(currentNode.GridPosition.X + direction.X, currentNode.GridPosition.Y);
            Point second = new Point(currentNode.GridPosition.X, currentNode.GridPosition.Y + direction.Y);


            if (WorldController.IsPointInBounds(first, world) && !WorldController.GetTileFromPointReference(first, world).IsWalkable)
            {
                return false;
            }


            if (WorldController.IsPointInBounds(second, world) && !WorldController.GetTileFromPointReference(second, world).IsWalkable)
            {
                return false;
            }


            else
            {
                return true;
            }
            
        }
    }
}

