﻿using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Libraries;
using Engine.Logic;


namespace Engine.Controllers
{
    public static class AbilityController
    {
        // Conditional Checks
        #region
        // First method used for checking abilities that target entities (strike, shoot etc)
        public static bool IsAbilityUseValid(LivingEntity caster, Ability abilityUsed, LivingEntity target)
        {
            // Ability must pass all 3 checks to be a valid move
            bool passedApCheck = false;
            bool passedInRangeCheck = false;
            bool passedTargetValidityCheck = false;

            // Check that the target location is in range
            if (IsTargetInRangeOfCaster(target, caster, abilityUsed.Range))
            {
                passedInRangeCheck = true;
            }

            // Check if caster actually has enough action points to pay for the ability
            if(HasEnoughActionPoints(caster, abilityUsed))
            {
                passedApCheck = true;
            }

            // Check that the selected target is a valid target for the ability
            // e.g. you cant shoot your allies, you cant heal an enemy, you cant move ontop of another character, etc
            if(IsTargetOfAbilityValid(caster, target, abilityUsed))
            {
                passedTargetValidityCheck = true;
            }

            // were all 3 checks succesful?
            if(passedInRangeCheck &&
               passedApCheck &&
               passedTargetValidityCheck)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        // Second overload method used for checking abilities that target tiles (Move for example)
        public static bool IsAbilityUseValid(LivingEntity caster, Ability abilityUsed, Tile targetTile)
        {
            // Ability must pass both checks to be a valid move
            bool passedApCheck = false;
            bool passedInRangeCheck = false;

            // Check if caster actually has enough action points to pay for the ability
            if (HasEnoughActionPoints(caster, abilityUsed))
            {
                passedApCheck = true;
            }

            // Check that the target location is in range
            if (WorldController.IsTileAInRangeOfTileB(caster.Position, targetTile, abilityUsed.Range))
            {
                passedInRangeCheck = true;
            }

            // both checks succesful? if so, return true
            if(passedApCheck &&
                passedInRangeCheck)
            {
                return true;
            }
            else
            {
                return false;
            }


            // TO DO: implement code that checks if the targetTile is unoccupied when using 'Move'

        }
        public static bool HasEnoughActionPoints(LivingEntity entity, Ability abilityUsed)
        {
            if (entity.CurrentActionPoints >= abilityUsed.ActionPointCost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsTargetInRangeOfCaster(LivingEntity target, LivingEntity caster, int range)
        {
            return WorldController.IsTileAInRangeOfTileB(target.Position, caster.Position, range);
        }
        public static bool IsTargetOfAbilityValid(LivingEntity caster, LivingEntity target, Ability abilityUsed)
        {
            if(caster == target &&
                (abilityUsed.ValidTargets == Ability.TargettingOptions.Self ||
                 abilityUsed.ValidTargets == Ability.TargettingOptions.AlliesAndSelf)
                )
            {
                return true;
            }

            else if(caster != target &&
                    CombatLogic.IsTargetFriendly(caster, target) &&
                    (abilityUsed.ValidTargets == Ability.TargettingOptions.Allies ||
                     abilityUsed.ValidTargets == Ability.TargettingOptions.AlliesAndSelf))
            {
                return true;
            }

            else if(CombatLogic.IsTargetHostile(caster, target) &&
                    abilityUsed.ValidTargets == Ability.TargettingOptions.Enemies)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        // Set up abilities + teach abilities to entities logic
        #region
        public static void TeachAbilityToLivingEntity(LivingEntity entity, string abilityName)
        {
            // Create a duplicate ability from the ability data in ability library
            // DONT USE THE ABILITY IN THE LIBRARY

            // Get ability data
            Ability data = AbilityLibrary.GetAbilityByName(abilityName);

            // Create a duplicate ability from data
            Ability newAbility = new Ability(data);

            entity.MyAbilities.Add(newAbility);


        }      
        public static void RunAbilitySetupOnEntity(LivingEntity entity, string className)
        {
            if(className == "Human Warrior")
            {
                TeachEntityHumanWarriorAbilities(entity);
            }
            else if (className == "Human Archer")
            {
                TeachEntityHumanArcherAbilities(entity);
            }
            else if (className == "Human Priest")
            {
                TeachEntityHumanPriestAbilities(entity);
            }
        }
        #endregion

        // Class specific ability package set up
        #region
        public static void TeachEntityHumanWarriorAbilities(LivingEntity entity)
        {
            TeachAbilityToLivingEntity(entity, "Move");
            TeachAbilityToLivingEntity(entity, "Strike");
        }
        public static void TeachEntityHumanArcherAbilities(LivingEntity entity)
        {
            TeachAbilityToLivingEntity(entity, "Move");
            TeachAbilityToLivingEntity(entity, "Shoot");
        }
        public static void TeachEntityHumanPriestAbilities(LivingEntity entity)
        {
            TeachAbilityToLivingEntity(entity, "Move");
            TeachAbilityToLivingEntity(entity, "Heal");
        }
        #endregion

        // Ability usage
        #region
        public static void OnAbilityUsedStart(LivingEntity entity, Ability ability)
        {
            // Pay for action point cost
            entity.CurrentActionPoints -= ability.ActionPointCost;

            // Set on cooldown
            ability.CurrentCooldown = ability.BaseCooldown;
        }
        public static void OnAbilityUsedFinished(LivingEntity entity, Ability ability)
        {
            // User implementation
            // this method is called at the end of an ability usage
            // put ability relevant code here that you want triggered post ability usage
            // e.g. "After you successfully perform a melee attack, gain 5 health"
        }
        public static void PerformAbility(LivingEntity caster, Ability abilityUsed, LivingEntity target = null, Tile targetTile = null)
        {
            // pay action point cost, set ability on cooldown, etc
            OnAbilityUsedStart(caster, abilityUsed);

            // Perform ability based on its name
            if (abilityUsed.AbilityName == "Move")
            {
                PerformMove(caster, targetTile);
            }
            else if (abilityUsed.AbilityName == "Strike")
            {
                PerformStrike(caster, target, abilityUsed);
            }
            else if (abilityUsed.AbilityName == "Shoot")
            {
                PerformShoot(caster, target, abilityUsed);
            }
            else if (abilityUsed.AbilityName == "Heal")
            {
                PerformHeal(target, abilityUsed);
            }

            // Resolve ability action (pay action point cost, set ability on cooldown, etc)
            OnAbilityUsedFinished(caster, abilityUsed);

        }
        #endregion

        // Perform specific abilities logic
        #region
        public static void PerformMove(LivingEntity caster, Tile destination)
        {
            MovementLogic.MoveEntity(caster, destination);
        }
        public static void PerformStrike(LivingEntity caster, LivingEntity target, Ability abilityUsed)
        {
            // Calculate the damage
            int damageValue = CombatLogic.CalculateDamageValue(caster, target, abilityUsed.PrimaryValue);

            // Create damage event
            CombatLogic.HandleDamage(target, damageValue);
        }
        public static void PerformShoot(LivingEntity caster, LivingEntity target, Ability abilityUsed)
        {
            // Calculate the damage
            int damageValue = CombatLogic.CalculateDamageValue(caster, target, abilityUsed.PrimaryValue);

            // Create damage event
            CombatLogic.HandleDamage(target, damageValue);
        }
        public static void PerformHeal(LivingEntity target, Ability abilityUsed)
        {
            // Modify health
            LivingEntityController.ModifyEntityCurrentHealth(target, abilityUsed.PrimaryValue);

        }
        #endregion

    }
}
