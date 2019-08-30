using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class Vulnerable : MonoBehaviour
    {
        public event Action Hit;

        [SerializeField]
        private Health health;

        [SerializeField]
        private string toTag = "Default";

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
            if (other.CompareTag(toTag))
            {
                Debug.Log("hit from weapon !");
                Weapon weapon = other.GetComponent<Weapon>();
                OnHit(weapon);
            }
        }

        private void OnHit(Weapon weapon)
        {
            Debug.Log($"decrease {weapon.Damage}");
            health.Decrease(weapon.Damage);
            this.Hit?.Invoke();

        }
    }
}