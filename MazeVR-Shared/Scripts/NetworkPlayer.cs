using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class NetworkPlayer : NetworkEntity
    {
        [SerializeField]
        private int id = 1;

        [SerializeField]
        private GameObject avatar;

        [SerializeField]
        private int tickrate = 30;

        [SerializeField]
        private bool updating = false;

        [SerializeField]
        private bool update = true;

        public override int ID => this.id;

        public override void Synchronize(OscMessage message)
        {
            float x = message.GetFloat(1);
            float y = message.GetFloat(2);
            float z = message.GetFloat(3);
    
            avatar.transform.position = new Vector3(x, y, z);
        }

        protected override void OnUpdated(NetworkEntityUpdatedArgs args)
        {
            base.OnUpdated(args);
        }

        private void Update()
        {
            if (update && !updating)
            {
                StartCoroutine(UpdatePosition());
            }
            else if (!update && updating)
            {
                StopCoroutine(UpdatePosition());
            }
        }

        private IEnumerator UpdatePosition()
        {
            updating = true;

            while (update)
            {
                SendPosition();
                yield return new WaitForSecondsRealtime(1 / tickrate);
            }

            updating = false;
        }

        private void SendPosition()
        {
            Vector3 avatarPosition = avatar.transform.position;
            float x = avatarPosition.x;
            float y = avatarPosition.y;
            float z = avatarPosition.z;

            NetworkEntityUpdatedArgs args =
                new NetworkEntityUpdatedArgs("PlayerPosition", x, y, z);

            OnUpdated(args);
        }
    }
}

