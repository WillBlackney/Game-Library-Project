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
        private WorldObject myWorldObject;
        private LivingEntity myEntity;
        private Item myItem;
        private bool isWalkable;
        #endregion

        // Properties
        #region

        public World MyWorld
        {
            get { return myWorld; }
            set { myWorld = value; }
        }
        public Point GridPosition
        {
            get { return gridPosition; }
            set { gridPosition = value; }
        }
        public WorldObject MyWorldObject
        {
            get { return myWorldObject; }
            set { myWorldObject = value; }
        }
        public LivingEntity MyEntity
        {
            get { return myEntity; }
            set { myEntity = value; }
        }
        public Item MyItem
        {
            get { return myItem; }
            set { myItem = value; }
        }
        public bool IsOccupied()
        {
            if (myEntity != null ||
                myWorldObject != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsWalkable
        {
            get { return isWalkable; }
            set { isWalkable = value; }
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
