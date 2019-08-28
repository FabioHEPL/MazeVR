﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public class NetworkPosition : NetworkBehaviour
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

            this.avatar.position = new Vector3(x, y, z);
        }

        protected override void OnUpdated(NetworkBehaviourUpdatedArgs args)
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

            NetworkBehaviourUpdatedArgs args =
                new NetworkBehaviourUpdatedArgs("Position", x, y, z);

            OnUpdated(args);
        }
    }
}