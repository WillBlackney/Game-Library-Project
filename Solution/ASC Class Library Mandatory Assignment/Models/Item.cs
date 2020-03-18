using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Item
    {
        // Item Effect enum declaration
        public enum ItemEffect { IncreaseStrength, IncreaseDexterity, IncreaseHealth };

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

        // Constructors
        #region
        // First constructor used by AbilityLibrary to create initial ability data object
        public Item(string name, ItemEffect effect, int effectValue)
        {
            ItemName = name;
            Effect = effect;
            EffectValue = effectValue;
        }
        // Second constructor used to create an ability from library data. This is the ability used by entities
        public Item(Item data)
        {
            ItemName = data.ItemName;
            Effect = data.Effect;
            EffectValue = data.EffectValue;
        }
        #endregion
    }
}
