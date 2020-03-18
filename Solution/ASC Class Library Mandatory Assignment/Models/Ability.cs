using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class Ability
    {
        public enum TargettingOptions { Self, Allies, AlliesAndSelf, Enemies, Tile }

        // Variables
        #region
        private string abilityName;
        private int actionPointCost;
        private int baseCooldown;
        private int currentCooldown;
        private int range;
        private int primaryValue;
        private int secondaryValue;
        private TargettingOptions validTargets;
        #endregion

        // Properties
        #region
        public string AbilityName
        {
            get { return abilityName; }
            set { abilityName = value; }
        }
        public int ActionPointCost
        {
            get { return actionPointCost; }
            set { actionPointCost = value; }
        }
        public int BaseCooldown
        {
            get { return baseCooldown; }
            set { baseCooldown = value; }
        }
        public int CurrentCooldown
        {
            get { return currentCooldown; }
            set { currentCooldown = value; }
        }
        public int Range
        {
            get { return range; }
            set { range = value; }
        }
        public int PrimaryValue
        {
            get { return primaryValue; }
            set { primaryValue = value; }
        }
        public int SecondaryValue
        {
            get { return secondaryValue; }
            set { secondaryValue = value; }
        }
        public TargettingOptions ValidTargets
        {
            get { return validTargets; }
            set { validTargets = value; }
        }
        #endregion

        // Constructors
        #region
        // First constructor used by ItemLibrary to create initial ability data object
        public Ability(string abilityName, int actionPointCost, int baseCooldown, int range,
            int primaryValue, int secondaryValue, TargettingOptions validTargets)
        {
            AbilityName = abilityName;
            ActionPointCost = actionPointCost;
            BaseCooldown = baseCooldown;
            currentCooldown = 0;
            Range = range;
            PrimaryValue = primaryValue;
            SecondaryValue = secondaryValue;
            ValidTargets = validTargets;
        }
        // Second constructor used to create an item from library data. This is the item that is placed in the world
        public Ability(Ability data)
        {
            AbilityName = data.AbilityName;
            ActionPointCost = data.ActionPointCost;
            BaseCooldown = data.BaseCooldown;
            currentCooldown = 0;
            Range = data.Range;
            PrimaryValue = data.PrimaryValue;
            SecondaryValue = data.SecondaryValue;
            ValidTargets = data.ValidTargets;
        }
        #endregion
    }
}
