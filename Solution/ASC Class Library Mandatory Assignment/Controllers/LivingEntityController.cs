using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Factories;

namespace Engine.Controllers
{
    public static class LivingEntityController
    {
        // Variables + Properties
        #region
        public static List<LivingEntity> allLivingEntities;
        #endregion

        // Entity creation + intial property set up logic
        #region
        public static LivingEntity CreateLivingEntity(string className, Tile startPosition, Player owner)
        {
            LivingEntity entity = LivingEntityFactory.CreateLivingEntity(startPosition, owner);
            SetEntityPlayerOwner(entity, owner);
            AddEntityToAllEntitiesList(entity);
            PlaceEntityAtLocation(entity, startPosition);
            BuildEntityPropertiesFromClassNameString(entity, className);            
            AbilityController.RunAbilitySetupOnEntity(entity, className);

            return entity;
        }
        public static void BuildEntityPropertiesFromClassNameString(LivingEntity entity, string className)
        {
            if (className == "Human Warrior")
            {
                BuildCharacterPropertiesAsHumanWarrior(entity);
            }
        }
        public static void AddEntityToAllEntitiesList(LivingEntity entity)
        {
            allLivingEntities.Add(entity);
        }
        public static void PlaceEntityAtLocation(LivingEntity entity, Tile location)
        {
            entity.Position = location;
            location.MyEntity = entity;
        }        
        public static void SetEntityPlayerOwner(LivingEntity entity, Player owner)
        {
            entity.MyPlayer = owner;
        }
        #endregion

        // Entity removal
        #region
        public static void RemoveEntityFromLocation(LivingEntity entity, Tile location)
        {
            entity.Position = null;
            location.MyEntity = null;
        }
        public static void RemoveEntityFromAllEntitiesList(LivingEntity entity)
        {
            if (allLivingEntities.Contains(entity))
            {
                allLivingEntities.Remove(entity);
            }
        }
        #endregion

        // Modify Entity Stats
        #region
        public static void ModifyEntityCurrentHealth(LivingEntity entity, int healthGainedOrLost)
        {
            entity.CurrentHealth += healthGainedOrLost;            
        }
        public static void ModifyEntityStrength(LivingEntity entity, int strengthGainedOrLost)
        {
            entity.Strength += strengthGainedOrLost;
        }
        public static void ModifyEntityDexterity(LivingEntity entity, int dexterityGainedOrLost)
        {
            entity.Dexterity += dexterityGainedOrLost;
        }
        #endregion

        // Build entity from specific data preset logic
        #region
        public static void BuildCharacterPropertiesAsHumanWarrior(LivingEntity entity)
        {
            // Set base properties
            entity.CurrentHealth = 40;
            entity.CurrentActionPoints = 0;
            entity.Mobility = 2;
            entity.Initiative = 3;
            entity.MyClass = "Human Warrior";
        }
        public static void BuildCharacterPropertiesAsHumanPriest(LivingEntity entity)
        {
            // Set base properties
            entity.CurrentHealth = 40;
            entity.CurrentActionPoints = 0;
            entity.Mobility = 2;
            entity.Initiative = 3;
            entity.MyClass = "Human Priest";
        }
        public static void BuildCharacterPropertiesAsHumanArcher(LivingEntity entity)
        {
            // Set base properties
            entity.CurrentHealth = 40;
            entity.CurrentActionPoints = 0;
            entity.Mobility = 2;
            entity.Initiative = 3;
            entity.MyClass = "Human Archer";
        }
        #endregion

        // Turn + Activation related
        #region
        public static void EntityOnActivationStart(LivingEntity entity)
        {
            ReduceAllAbilityCooldownsOnActivationStart(entity);
            GainActionPointsOnActivationStart(entity);
        }        
        public static void ReduceAllAbilityCooldownsOnActivationStart(LivingEntity entity)
        {
            foreach(Ability ability in entity.MyAbilities)
            {
                if(ability.CurrentCooldown > 0)
                {
                    ability.CurrentCooldown -= 1;
                }
            }
        }
        public static void GainActionPointsOnActivationStart(LivingEntity entity)
        {
            // Entities always gain 2 action points at the start of their turn
            entity.CurrentActionPoints += 2;

            // Prevent gain action points over the max limit
            if(entity.CurrentActionPoints > entity.MaximumActionPoints)
            {
                entity.CurrentActionPoints = entity.MaximumActionPoints;
            }
        }
        #endregion
    }
}
