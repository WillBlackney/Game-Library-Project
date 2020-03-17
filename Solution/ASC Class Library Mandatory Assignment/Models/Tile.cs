using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Tile
    {
        // Variables
        #region
        private World myWorld;
        private Point gridPosition;
        #endregion

        // Properties
        #region
        
        public World MyWorld
        {
            get{ return myWorld; }
            set { myWorld = value; }
        }
        public Point GridPosition
        {
            get { return gridPosition; }
            set { gridPosition = value; }
        }
        #endregion

        // Constructors
        #region
        public Tile(int x, int y)
        {
            GridPosition = new Point(x, y);
        }
        #endregion
    }
}
