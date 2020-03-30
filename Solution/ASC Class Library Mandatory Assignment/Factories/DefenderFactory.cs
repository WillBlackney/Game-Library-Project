using Engine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Factories
{
    public class DefenderFactory : CharacterFactory
    {
        public override Defender CreateDefender()
        {
            throw new NotImplementedException();
        }

        public override Enemy CreateEnemy()
        {
            throw new NotImplementedException();
        }
    }
}
