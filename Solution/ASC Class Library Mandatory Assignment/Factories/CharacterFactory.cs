using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;

namespace Engine.Factories
{
    public abstract class CharacterFactory
    {
        public abstract Defender CreateDefender();
        public abstract Enemy CreateEnemy();
    }
}
