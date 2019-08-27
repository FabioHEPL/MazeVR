using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class NetworkMob : NetworkEntity
    {
        [SerializeField]
        private int id = 10;

        [SerializeField]
        private int tickrate = 30;

        [SerializeField]
        private bool updating = false;

        [SerializeField]
        private bool update = true;

        public override int ID => this.id;

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
            NetworkEntityUpdatedArgs args =
                new NetworkEntityUpdatedArgs("MobPosition", transform.position.x,
                    transform.position.y, transform.position.z);

            OnUpdated(args);
        }

        public override void Synchronize(OscMessage message)
        {
            throw new NotImplementedException();
        }
    }
}
