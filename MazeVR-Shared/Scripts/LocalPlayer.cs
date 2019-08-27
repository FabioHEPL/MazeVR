﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class LocalPlayer : LocalEntity
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

        protected override void OnUpdated(LocalEntityUpdatedArgs args)
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
            LocalEntityUpdatedArgs args =
                new LocalEntityUpdatedArgs("PlayerPosition", avatar.transform.position.x,
                    avatar.transform.position.y, avatar.transform.position.z);

            OnUpdated(args);
        }
    }
}
