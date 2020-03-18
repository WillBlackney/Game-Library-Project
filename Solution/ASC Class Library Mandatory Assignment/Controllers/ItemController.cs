using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Libraries;

namespace Engine.Controllers
{
    public static class ItemController
    {
        // Gain items + apply items logic
        #region        
        public static void ApplyItemEffectToEntity(LivingEntity entity, Item item)
        {
            if(item.Effect == Item.ItemEffect.IncreaseHealth)
            {
                LivingEntityController.ModifyEntityCurrentHealth(entity, item.EffectValue);
            }
            else if (item.Effect == Item.ItemEffect.IncreaseStrength)
            {
                LivingEntityController.ModifyEntityStrength(entity, item.EffectValue);
            }
            else if (item.Effect == Item.ItemEffect.IncreaseDexterity)
            {
                LivingEntityController.ModifyEntityDexterity(entity, item.EffectValue);
            }
            
        }
        public static void HandleEntityPickingUpItem(LivingEntity entity, Item item)
        {
            ApplyItemEffectToEntity(entity, item);
            RemoveItemFromTile(item.Position, item);

        }
        #endregion

        // Creation logic
        #region
        public static Item CreateItemFromStringReference(string itemName)
        {
            Item data = ItemLibrary.GetItemDataByName(itemName);
            Item item = new Item(data);

            return item;
        }
        public static Item CreateItemFromItemData(Item data)
        {
            Item item = new Item(data);

            return item;
        }
        #endregion

        // Item interactions with world logic
        #region
        public static void PlaceItemOnTile(Tile location, Item item)
        {
            location.MyItem = item;
            item.Position = location;
        }
        public static void RemoveItemFromTile(Tile location, Item item)
        {
            item.Position = null;
            location.MyItem = null;
        }
    
        #endregion
    }
}
