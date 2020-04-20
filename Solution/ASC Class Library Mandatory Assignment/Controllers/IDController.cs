using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Controllers
{
    public static class IDController
    {
        public static Dictionary<int, object> allIdObjects;
        public static int currentID = 0;

        public static void AddObjectToIdDictionary(object t)
        {
            allIdObjects.Add(GetUniqueID(), t);
        }

        public static int GetUniqueID()
        {
            // this should be the only means in which a unique ID number is created and assigned to an object
            // creating + assigned ID's outside this method will cause persistency errors
            // by incrementing the global 'currentID' value by 1 on each call, this method guarantees a unique ID.

            currentID++;
            return currentID;
        }


    }
}
