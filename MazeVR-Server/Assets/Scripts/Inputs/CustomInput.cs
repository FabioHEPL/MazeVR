using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Custom Input", menuName = "Custom Inputs/Custom Input")]
public class CustomInput : ScriptableObject
{
    public KeyCode key;
    public Operation operation;

    public virtual void Process()
    {
        if (Input.GetKeyDown(key))
            operation.Execute();
    }
}
