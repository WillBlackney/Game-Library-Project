using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Item
    {
        // Item Effect enum declaration
        public enum ItemEffect { IncreasePower, IncreaseDefence, IncreaseHealth };

        // Variables
        #region
        private string itemName;
        private ItemEffect effect;
        private int effectValue;
        private Tile position;
        #endregion

        // Properties
        #region
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        public ItemEffect Effect
        {
            get { return effect; }
            set { effect = value; }
        }
        public int EffectValue
        {
            get { return effectValue; }
            set { effectValue = value; }
        }

        public Tile Position
        {
            get { return position; }
            set { position = value; }
        }

        #endregion

    }
}
