using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
using Engine.Libraries;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        public static Item CreateEmptyItem()
        {
            Item newItem = new Item();
            return newItem;
        }
        public static Item CreateNewItemFromData(Item itemData)
        {
            Item newItem = new Item(itemData);
            return newItem;

        }
        public static Item CreateNewItemFromString(string itemName)
        {
            Item newItem = ItemLibrary.GetItemDataByName(itemName);
            return newItem;
        }
    }
}
