using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Controllers;

namespace Engine.Logic
{
    public static class CombatLogic
    {
        // Conditional Checks + Bools
        #region
        public static bool IsTargetFriendly(LivingEntity entity, LivingEntity target)
        {
            if(entity.MyPlayer == target.MyPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsTargetHostile(LivingEntity entity, LivingEntity target)
        {
            if (entity.MyPlayer != target.MyPlayer)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        // Calculations
        #region
        public static int CalculateDamageValue(LivingEntity attacker, LivingEntity target, int baseDamageValue)
        {
            int valueReturned = baseDamageValue;

            // Add attacker strength to damage value
            valueReturned += attacker.Strength;

            // Reduce damage value by targets dexterity
            valueReturned -= target.Dexterity;

            // Prevent damage going into negative
            if(valueReturned < 0)
            {
                valueReturned = 0;
            }

            return valueReturned;
        }
        #endregion

        // Handle Events
        #region
        public static void HandleDamage(LivingEntity target, int damageValue)
        {
            LivingEntityController.ModifyEntityCurrentHealth(target, -damageValue);

            if(target.CurrentHealth <= 0)
            {
                HandleDeath(target);
            }
        }
        public static void HandleDeath(LivingEntity entityKilled)
        {
            // Future implementation: Create and resolve on death events, for example.
            // Explode on death, damaging nearby characters
            // If entity killed is enemy, increase player score
            // etc

            // Remove from controller list
            LivingEntityController.RemoveEntityFromAllEntitiesList(entityKilled);

            // Remove from activation order
            TurnController.activationOrder.Remove(entityKilled);

            // Make entities tile available
            LivingEntityController.RemoveEntityFromLocation(entityKilled, entityKilled.Position);            

        }
        #endregion
    }
}
