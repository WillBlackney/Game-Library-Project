using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Libraries;
using System.Linq;

namespace Engine.Controllers
{
    
    public static class TurnController
    {
        // Properties + Variables
        #region
        public static List<LivingEntity> activationOrder;
        public static LivingEntity entityCurrentlyActivated;
        public static int currentTurnCycle;
        public static int itemsCreatedOnTurnCycleStart;
        #endregion

        // Turn Cycle Logic
        #region
        public static void StartNewTurnCycle()
        {
            ClearActivationOrder();
            AddAllEntitiesToActivationOrder();
            ResetAllEntityPropertiesOnTurnCycleStart();
            CreateItemsOnTurnCycleStart(itemsCreatedOnTurnCycleStart);
            CalculateActivationOrder();
        }
        public static void CreateItemsOnTurnCycleStart(int itemsToCreate)
        {
            for (int i = 0; i < itemsToCreate; i++)
            {
                // Get a random valid spawn location for the item
                Tile spawnLocation = WorldController.GetAllValidNewItemLocationTiles(WorldController.currentWorld)
                    [new Random().Next(0, WorldController.GetAllValidNewItemLocationTiles(WorldController.currentWorld).Count)];

                // Create a new random item
                Item newRandomItem = ItemController.CreateItemFromItemData(ItemLibrary.GetRandomItemData());

                // Place item at the spawn location
                ItemController.PlaceItemOnTile(spawnLocation, newRandomItem);
            }

        }
        public static void ResetAllEntityPropertiesOnTurnCycleStart()
        {
            foreach (LivingEntity entity in activationOrder)
            {
                entity.HasAlreadyActivated = false;
            }
        }
        #endregion

        // Calculate activation order
        #region
        public static void CalculateActivationOrder()
        {
            // Each character makes their turn order roll
            foreach(LivingEntity entity in LivingEntityController.allLivingEntities)
            {
                RollForActivationOrder(entity);
            }

            // order the activation order list by which characters had the highest intiative rolls
            activationOrder.OrderBy(entity => entity.CurrentTurnOrderRoll).ToList();
            activationOrder.Reverse();
        }
        public static void RollForActivationOrder(LivingEntity entity)
        {
            // the roll is equal to the characters initiative stat, plus
            // a random number between 1 and 3
            entity.CurrentTurnOrderRoll = entity.Initiative + new Random().Next(1, 3);
        }
        public static LivingEntity GetNextEntityToActivate()
        {
            LivingEntity entityReturned = null;
            for (int index = 0; index < activationOrder.Count; index++)
            {
                if (activationOrder[index].HasAlreadyActivated == false)
                {
                    entityReturned = activationOrder[index];
                    break;
                }
            }

            return entityReturned;
        }
        public static void ClearActivationOrder()
        {
            activationOrder.Clear();
        }
        public static void AddAllEntitiesToActivationOrder()
        {
            activationOrder.AddRange(LivingEntityController.allLivingEntities);
        }
        #endregion

        // Entity activation logic
        #region
        public static void ActivateEntity(LivingEntity entity)
        {
            entityCurrentlyActivated = entity;
            entity.HasAlreadyActivated = true;
        }
        public static void HandleEntityActivationEnd(LivingEntity entity)
        {
            // If all entities have activated, start a new turn cycle
            if (HaveAllEntitiesActivatedThisTurnCycle())
            {
                StartNewTurnCycle();
            }

            // Otherwise, activate the next entity in the turn order queue
            else
            {
                ActivateEntity(GetNextEntityToActivate());
            }
        }
        #endregion

        // Conditional checks + bools
        #region
        public static bool HaveAllEntitiesActivatedThisTurnCycle()
        {
            bool boolReturned = true;

            foreach(LivingEntity entity in activationOrder)
            {
                if(entity.HasAlreadyActivated == false)
                {
                    boolReturned = false;
                    break;
                }
            }

            return boolReturned;
        }
        #endregion

    }


}
