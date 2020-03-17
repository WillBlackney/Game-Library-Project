using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Logic
{
    public static class CombatLogic
    {
        // Conditional Checks + Bools
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
    }
}
