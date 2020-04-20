using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Controllers;


namespace Engine.Factories
{
    public static class LivingEntityFactory
    {
        public static LivingEntity CreateLivingEntity(Tile position, Player player)
        {
            LivingEntity entity = new LivingEntity(position, player);
            return entity;
        }
        public static LivingEntity CreateLivingEntity()
        {
            LivingEntity entity = new LivingEntity();
            return entity;
        }



    }
}
