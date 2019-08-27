using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class MobFactory : MonoBehaviour
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

}
