using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        private LayerMask enemyLayerMask;

        [SerializeField]
        private int damage;

        public int Damage => this.damage;

        public event Action Hit;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"{this.name} collided with {other.name}");
        }
    }
}
