using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(IndexPrefabCreator))]
public class IndexPrefabCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        IndexPrefabCreator myScript = (IndexPrefabCreator)target;
        GUILayout.Space(40);
        if (GUILayout.Button("Create One Random"))
        {
            myScript.CreateRandomAtTargetPointInInspector();
        }
        if (GUILayout.Button("Destroy last"))
        {
            DestroyImmediate(myScript.m_lastCreated, true);

        }
        GUILayout.Space(40);

        if (GUILayout.Button("Create All map random"))
        {
            for (int x = 0; x < 20; x++)
            {
                for (int y = 0; y < 20; y++)
                {

                    myScript.CreateRandomAtTargetPoint(x, y);
                }

            }

        }
       
        if (GUILayout.Button("Destroy all"))
        {

            ChildrenDestroyer.DestroyChildren(myScript.m_parentWhereToCreate);

        }
    }
}