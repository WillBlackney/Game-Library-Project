using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.AStarPathfinding
{
    public class Node
    {
        // Location Properties
        #region
        public Point GridPosition { get; private set; }
        public Tile TileRef { get; private set; }
        //public Vector2 WorldPosition { get; set; }
        public Node Parent { get; private set; }
        #endregion

        // AStar Scoring Properties
        #region
        public int G { get; set; }
        public int H { get; set; }
        public int F { get; set; }
        #endregion

        // Logic
        #region
        public Node(Tile tileRef)
        {
            TileRef = tileRef;
            GridPosition = tileRef.GridPosition;

        }
        public void CalcValues(Node parent, Node goal, int gCost)
        {
            Parent = parent;
            G = parent.G + gCost;
            H = ((Math.Abs(GridPosition.X - goal.GridPosition.X)) + Math.Abs((goal.GridPosition.Y - GridPosition.Y))) * 10;
            F = G + H;
        }
        #endregion

    }
}
