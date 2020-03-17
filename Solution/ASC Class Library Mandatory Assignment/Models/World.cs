using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class World
    {
        // Variables
        #region
        private Dictionary<Point, Tile> tiles;
        private int xLength;
        private int yLength;
        #endregion

        // Properties
        #region
        public Dictionary<Point, Tile> Tiles
        {
            get { return tiles; }
            set { tiles = value; }
        }
        public int XLength
        {
            get { return xLength; }
            private set { xLength = value; }                
        }
        public int YLength
        {
            get { return yLength; }
            private set { yLength = value; }
        }
        #endregion

        // Constructors
        #region
        public World(int _xLength, int _yLength)
        {
            XLength = _xLength;
            YLength = _yLength;
        }
        #endregion
    }
}
