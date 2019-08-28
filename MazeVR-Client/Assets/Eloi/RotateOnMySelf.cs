using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnMySelf : MonoBehaviour
{
    
    public void SetRotationWith(int rotationType)
    {
        transform.localRotation *= Quaternion.Euler(0, 90f * rotationType, 0);
       
    }
}
