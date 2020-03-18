using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Player
    {
        public enum PlayerType { Human, AI};

        // Variables
        #region
        private int id;
        private string playerName;
        private PlayerType myPlayerType;
        #endregion

        // Properties
        #region
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        public PlayerType MyPlayerType
        {
            get { return myPlayerType; }
            set { myPlayerType = value; }
        }
        #endregion

        // Constructors
        #region
        public Player()
        {

        }
        public Player(int id, string playerName, PlayerType playerType)
        {
            ID = id;
            MyPlayerType = playerType;
            PlayerName = playerName;
        }
        #endregion

    }
}
