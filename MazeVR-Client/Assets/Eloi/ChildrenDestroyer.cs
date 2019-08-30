using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenDestroyer : MonoBehaviour
{
    public Transform m_targetToFluch;
    private void Start()
    {
        DestroyChildren(m_targetToFluch);
        
    }

    public static void DestroyChildren(Transform target)
    {
       int childCount = target.childCount;
        for (int i = childCount-1; i >=0; i--)
        {
            DestroyImmediate( target.GetChild(i).gameObject, true);
        }


    }
}
