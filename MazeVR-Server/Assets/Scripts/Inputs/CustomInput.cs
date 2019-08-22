using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomInput : ScriptableObject
{
    public KeyCode key;
    public Operation operation;

    public void Process()
    {
        if (Input.GetKeyDown(key))
            operation.Execute();
    }
}
