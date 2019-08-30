using MazeVR.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class MobHitBehaviour : NetworkBehaviour
    {
        [SerializeField]
        private Rigidbody _rigidbody;

        [SerializeField]
        private Vector3 hitTrajectory;

        private void Awake()
        {
            this._rigidbody = GetComponent<Rigidbody>();
        }

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
            Fallback();
        }

        private void Fallback()
        {
            _rigidbody.AddForce(-transform.forward + hitTrajectory, ForceMode.Impulse);
        }
    }
}