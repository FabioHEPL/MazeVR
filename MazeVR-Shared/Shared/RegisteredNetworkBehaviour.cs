using UnityEngine;

namespace MazeVR.Shared
{
    [System.Serializable]
    public class RegisteredNetworkBehaviour
    {
        [SerializeField]
        private int id;
        public int ID => id;

        [SerializeField]
        private NetworkBehaviour behaviour;
        public NetworkBehaviour Behaviour => behaviour;

        public RegisteredNetworkBehaviour(NetworkBehaviour behaviour, int id)
        {
            this.id = id;
            this.behaviour = behaviour;
        }
    }
}