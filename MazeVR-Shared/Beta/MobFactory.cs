using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class MobFactoryBehaviour : MonoBehaviour
    {
        [SerializeField]
        private GameObject mobPrefab;

        public GameObject CreateMob(Vector3 position)
        {
            GameObject mob = GameObject.Instantiate(mobPrefab, position, Quaternion.identity);
            OnMobCreated(new MobCreatedArgs(mob));

            return mob;
        }

        private void OnMobCreated(MobCreatedArgs args)
        {
            this.Created?.Invoke(this, args);
        }

        public event EventHandler<MobCreatedArgs> Created;
    }

    public class MobCreatedArgs : EventArgs
    {
        private GameObject mob;
        public GameObject Mob => mob;

        public MobCreatedArgs(GameObject mob)
        {
            this.mob = mob;
        }
    }
}
