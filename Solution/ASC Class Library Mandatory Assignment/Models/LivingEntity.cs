using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Models
{
    public class LivingEntity
    {
        // Variables
        #region
        private int currentHealth;
        private string myClass;
        private int mobility;
        private int initiative;
        private int currentTurnOrderRoll;
        private int currentActionPoints;
        private Tile position;
        private List<Ability> myAbilities;
        private Player myPlayer;
        
        #endregion

        // Properties
        #region
        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        public int Mobility
        {
            get { return mobility; }
            set { mobility = value; }
        }
        public int Initiative
        {
            get { return initiative; }
            set { initiative = value; }
        }
        public int CurrentActionPoints
        {
            get { return currentActionPoints; }
            set { currentActionPoints = value; }
        }
        public int CurrentTurnOrderRoll
        {
            get { return currentTurnOrderRoll; }
            set { currentTurnOrderRoll = value; }
        }
        public string MyClass
        {
            get { return myClass; }
            set { myClass = value; }
        }
        public Tile Position
        {
            get { return position; }
            set { position = value; }
        }
        public List<Ability> MyAbilities
        {
            get { return myAbilities; }
            set { myAbilities = value; }
        }
        public Player MyPlayer
        {
            get { return myPlayer; }
            set { myPlayer = value; }
        }
        #endregion

        // Constructors
        public LivingEntity(Tile position, Player player)
        {
            Position = position;
            MyPlayer = player;
        }
        public LivingEntity()
        {

        }

    }
}
