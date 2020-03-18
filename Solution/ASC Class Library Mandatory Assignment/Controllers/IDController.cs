using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Controllers
{
    public class IDController
    {
        public static Dictionary<int, object> allIdObjects;
        public static int currentID = 0;

        public static void AddObjectToIdDictionary(object t)
        {
            allIdObjects.Add(GetUniqueID(), t);
        }

        public static int GetUniqueID()
        {
            currentID++;
            return currentID;
        }


    }
}
