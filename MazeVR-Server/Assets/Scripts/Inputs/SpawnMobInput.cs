﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawn Mob Input", menuName = "Custom Inputs/Spawn Mob")]
public class SpawnMobInput : CustomInput
{
    public KeyCode secondKey;

    [SerializeField]


    public override void Process()
    {
        if (Input.GetKeyDown(key))
            operation.Execute();
    }
}