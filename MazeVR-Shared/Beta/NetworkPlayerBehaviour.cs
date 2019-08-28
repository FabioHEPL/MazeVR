using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Beta
{
    public class NetworkPlayerBehaviour : NetworkBehaviour
    {
        public override NetworkEntity Entity => this.player;
        private Player player = null;
        
        private void Awake()
        {
            if (player == null)
                player = new Player(this.gameObject);
        }

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

        public override void OnNetworkUpdate(NetworkUpdate update)
        {
            float x = update.Message.GetFloat(1);
            float y = update.Message.GetFloat(2);
            float z = update.Message.GetFloat(3);

            avatar.transform.position = new Vector3(x, y, z);
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

            player.Update(new NetworkUpdate("Position", x, y, z));
        }
    }
}

