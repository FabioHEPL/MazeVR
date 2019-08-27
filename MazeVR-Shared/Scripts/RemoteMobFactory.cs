using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class RemoteMobFactory : RemoteEntity
    {
        [SerializeField]
        private int id = 4;

        public override int ID => this.id;

        public GameObject mobPrefab;

        [SerializeField]
        private Network network;

        private void Awake()
        {
            this.network = GameObject.FindObjectOfType<Network>();
        }

        public override void Synchronize(OscMessage message)
        {
            if (message.address.Equals("/Created"))
            {

                Vector3 mobPosition = Vector3.zero;

                mobPosition.x = message.GetFloat(1);
                mobPosition.y = message.GetFloat(2);
                mobPosition.z = message.GetFloat(3);

                GameObject mob = CreateMob(mobPosition);

                RemoteEntity entity = mob.GetComponent<RemoteEntity>();


                network.Register_Remote(entity);
            }
        }

        public GameObject CreateMob(Vector3 position)
        {
            return GameObject.Instantiate(mobPrefab, position, Quaternion.identity);
        }
    }
}
