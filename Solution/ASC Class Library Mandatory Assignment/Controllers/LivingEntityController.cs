using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Controllers
{
    public static class LivingEntityController
    {
        // Variables + Properties
        #region
        public static List<LivingEntity> allLivingEntities;
        #endregion

        // Entity initial creation logic
        #region
        public static LivingEntity CreateLivingEntity(string className, Tile startPosition, Player owner)
        {
            LivingEntity entity = new LivingEntity();
            SetEntityPlayerOwner(entity, owner);
            AddEntityToAllEntitiesList(entity);
            PlaceEntityAtLocation(entity, startPosition);
            BuildEntityPropertiesFromClassNameString(entity, className);            
            AbilityController.RunAbilitySetupOnEntity(entity, className);

            return entity;
        }
        public static void PlaceEntityAtLocation(LivingEntity entity, Tile location)
        {
            entity.Position = location;
        }
        public static void SetEntityPlayerOwner(LivingEntity entity, Player owner)
        {
            entity.MyPlayer = owner;
        }
        public static void AddEntityToAllEntitiesList(LivingEntity entity)
        {
            allLivingEntities.Add(entity);
        }
        public static void BuildEntityPropertiesFromClassNameString(LivingEntity entity, string className)
        {
            if(className == "Human Warrior")
            {
                BuildCharacterPropertiesAsHumanWarrior(entity);
            }
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
    }
}
