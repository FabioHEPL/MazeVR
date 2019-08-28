using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RotateOnMySelf))]
public class RotateOnMySelfEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RotateOnMySelf myScript = (RotateOnMySelf)target;
        if (GUILayout.Button("Rotate"))
        {
            myScript. SetRotationWith( 1);
        }
        
    }

   
}