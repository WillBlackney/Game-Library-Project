using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using System.Linq;

namespace Engine.Controllers
{
    
    public static class TurnController
    {
        public static List<LivingEntity> activationOrder;
        public static int currentTurnCycle;

        public static void StartNewTurnCycle()
        {
            CalculateTurnOrder();
        }
        public static void CalculateTurnOrder()
        {
            // Each character makes their turn order roll
            foreach(LivingEntity entity in LivingEntityController.allLivingEntities)
            {
                RollForTurnOrder(entity);
            }

            // order the activation order list by which characters had the highest intiative rolls
            activationOrder.OrderBy(entity => entity.CurrentTurnOrderRoll).ToList();
            activationOrder.Reverse();
        }
        public static void RollForTurnOrder(LivingEntity entity)
        {
            // the roll is equal to the characters initiative stat, plus
            // a random number between 1 and 3
            entity.CurrentTurnOrderRoll = entity.Initiative + new Random().Next(1, 3);
        }
    }

    
}
