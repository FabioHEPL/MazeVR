using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class CompositeNetworkBehaviour : NetworkBehaviour
    {
        [SerializeField]
        protected NetworkBehaviourMap[] behaviourMaps;        

        public override void Synchronize(OscMessage message)
        {
            GetBehaviour(message.address).Synchronize(message);
        }

        protected NetworkBehaviour GetBehaviour(string name)
        {
            Debug.Log($"{name}");
            return this.behaviourMaps.FirstOrDefault(m => m.Identifier == name).Behaviour;
        }

        protected override void OnUpdated(NetworkBehaviourUpdatedArgs args)
        {
            base.OnUpdated(args);
        }

        protected void OnEnable()
        {
            foreach (NetworkBehaviourMap map in behaviourMaps)
            {
                map.Behaviour.Updated += Behaviour_Updated;                
            }
        }

        protected void OnDisable()
        {
            foreach (NetworkBehaviourMap map in behaviourMaps)
            {
                map.Behaviour.Updated -= Behaviour_Updated;
            }
        }

        protected void Behaviour_Updated(object sender, NetworkBehaviourUpdatedArgs args)
        {
            base.OnUpdated(args);
        }
    }
}
