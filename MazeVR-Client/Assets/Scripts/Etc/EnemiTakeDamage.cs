using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class EnemiTakeDamage : MonoBehaviour
    {
        [SerializeField] int damage = 1;

        EnemiLifePoint enemiLifePoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Ennemi")
            {
                enemiLifePoint = other.gameObject.GetComponent<EnemiLifePoint>();
                enemiLifePoint.LifePoint = enemiLifePoint.LifePoint - damage;
            }
        }
    }
}