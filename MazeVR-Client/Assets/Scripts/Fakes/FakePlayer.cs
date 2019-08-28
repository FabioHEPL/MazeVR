using MazeVR.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayer : MonoBehaviour, Player
{
    public int health = 100;

    public int Health => health;

    public event EventHandler<DeathArgs> Death;

    public void DealDamage(int amount)
    {
        Debug.Log("je subis " + amount + " de degats");
        health -= amount;

        if (health <= 0)
        {
            Death?.Invoke(this, new DeathArgs());
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            DealDamage(10);
    }
}
