using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class MobHitBehaviour : NetworkBehaviour
    {
        public override void Synchronize(OscMessage message)
        {
            switch (message.address)
            {
                case "Hit":
                    OnHit(message);
                    break;
            }
        }

        private void OnHit(OscMessage message)
        {
            Debug.Log("mob got it");
        }
    }
}