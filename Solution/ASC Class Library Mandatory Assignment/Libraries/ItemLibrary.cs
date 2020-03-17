using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Libraries
{
    public static class ItemLibrary
    {
        public static List<Item> allItems;

        public static Item GetItemByName(string name)
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
    }
}
