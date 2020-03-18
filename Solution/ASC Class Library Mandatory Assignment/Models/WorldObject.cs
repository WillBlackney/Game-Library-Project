using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class WorldObject
    {
        // Variables
        #region
        private string objectName;
        private Tile position;
        private bool blocksLoS;
        private bool preventsMovement;
        #endregion

        // Properties
        #region
        public string ObjectName
        {
            get { return objectName; }
            set { objectName = value; }
        }
        public Tile Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool BlocksLoS
        {
            get { return blocksLoS; }
            set { blocksLoS = value; }
        }
        public bool PreventsMovement
        {
            get { return preventsMovement; }
            set { preventsMovement = value; }
        }
        #endregion

        // Constructors
        #region
        public WorldObject()
        {

        }
        public WorldObject(string name, Tile position, bool blocksLoS, bool preventsMovement)
        {
            ObjectName = objectName;
            Position = position;
            BlocksLoS = blocksLoS;
            PreventsMovement = preventsMovement;
        }
        #endregion
    }
}
