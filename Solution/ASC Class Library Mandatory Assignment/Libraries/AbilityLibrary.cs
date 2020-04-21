using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Libraries
{
    public static class AbilityLibrary
    {
        // Properties
        #region
        public static List<Ability> allAbilities;
        public static bool includeBasePackage;
        #endregion

        // Initialization + Set up
        #region
        public static void InitializeLibrary()
        {
            if (includeBasePackage)
            {
                PopulateAbilityLibraryWithBasePackage();
            }

        }
        public static void PopulateAbilityLibraryWithBasePackage()
        {
            // Move
            allAbilities.Add(
                new Ability("Move", 1, 0, 2, 0, 0,Ability.TargettingOptions.Tile
                ));

            // Strike
            allAbilities.Add(
                new Ability("Strike", 1, 0, 1, 5, 0, Ability.TargettingOptions.Enemies
                ));

            // Shoot
            allAbilities.Add(
                new Ability("Shoot", 1, 0, 3, 3, 0,Ability.TargettingOptions.Enemies
                ));

            // Heal
            allAbilities.Add(
                new Ability("Heal", 2, 2, 3, 10, 0, Ability.TargettingOptions.AlliesAndSelf
                ));
        }
        #endregion

        // Get Data 
        #region
        public static Ability GetAbilityByName(string name)
        {
            Ability abilityReturned = null;

            // Search all abilities list for the ability
            foreach (Ability ability in allAbilities)
            {
                if(ability.AbilityName == name)
                {
                    abilityReturned = ability;
                    break;
                }
            }

            // if a matching ability was not found, throw a nully
            if(abilityReturned == null)
            {
                throw new NullReferenceException();
            }

            // return the ability;
            return abilityReturned;
        }
        #endregion
    }
}
