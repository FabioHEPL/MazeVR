using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour
{
    public event Action Hit;

    [SerializeField]
    private Health health;

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
        if (other.CompareTag("Weapon"))
        {
            Weapon weapon = other.GetComponent<Weapon>();
            OnWeaponHit(weapon);
        }
    }

    private void OnWeaponHit(Weapon weapon)
    {        
        health.Decrease(weapon.Damage);

    }

    private void OnCollisinEnter(Collider other)
    {

    }
}
