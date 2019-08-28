using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class NetworkRotation : NetworkBehaviour
    {
        [SerializeField]
        private bool update = true;

        [SerializeField]
        private Transform avatar;

        [SerializeField]
        private int tickrate = 30;

        private bool updating = false;

        private void Awake()
        {
            if (avatar == null)
                avatar = this.transform;
        }

        public override void Synchronize(OscMessage message)
        {
            float x = message.GetFloat(1);
            float y = message.GetFloat(2);
            float z = message.GetFloat(3);

            this.avatar.rotation = Quaternion.Euler(new Vector3(x, y, z));
        }

        protected override void OnUpdated(NetworkBehaviourUpdatedArgs args)
        {
            base.OnUpdated(args);
        }

        private void Update()
        {
            if (update && !updating)
            {
                StartCoroutine(UpdateRotation());
            }
            else if (!update && updating)
            {
                StopCoroutine(UpdateRotation());
            }
        }

        private IEnumerator UpdateRotation()
        {
            updating = true;

            while (update)
            {
                SendRotation();
                yield return new WaitForSecondsRealtime(1 / tickrate);
            }

            updating = false;
        }

        private void SendRotation()
        {
            Vector3 avatarRotation = avatar.transform.rotation.eulerAngles;
            float x = avatarRotation.x;
            float y = avatarRotation.y;
            float z = avatarRotation.z;

            NetworkBehaviourUpdatedArgs args =
                new NetworkBehaviourUpdatedArgs("Rotation", x, y, z);

            OnUpdated(args);
        }
    }
}
