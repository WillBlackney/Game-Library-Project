using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Libraries
{
    public static class ItemLibrary
    {
        // Properties
        #region
        public static List<Item> allItems;
        public static bool includeBasePackage;
        #endregion

        // Initialization + Setup
        #region
        public static void InitializeLibrary()
        {
            if (includeBasePackage)
            {
                PopulateItemLibraryWithBasePackage();
            }
        }
        public static void PopulateItemLibraryWithBasePackage()
        {
            // TO DO: create base items that come with the library here
        }
        #endregion

        // Get Data
        #region
        public static Item GetItemDataByName(string name)
        {
            Item itemReturned = null;

            foreach(Item item in allItems)
            {
                if(item.ItemName == name)
                {
                    itemReturned = item;
                    break;
                }
            }

            if(itemReturned == null)
            {
                throw new NullReferenceException();
            }

            return itemReturned;
        }
        public static Item GetRandomItemData()
        {
            Item itemReturned = null;

            itemReturned = allItems[new Random().Next(0, allItems.Count)];

            if(itemReturned == null)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                return itemReturned;
            }
        }
        #endregion
    }
}
