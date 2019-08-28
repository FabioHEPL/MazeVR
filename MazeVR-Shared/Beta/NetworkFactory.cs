using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class NetworkFactory : NetworkEntity
    {
        public NetworkFactory(GameObject gameObject)
          : base(gameObject)
            { }

        public override int ID => throw new NotImplementedException();

        public override void Synchronize(NetworkUpdate update)
        {
            throw new NotImplementedException();
        }

        public override void Update(NetworkUpdate update)
        {
            throw new NotImplementedException();
        }

        public Network Network { get; }
    }
}
