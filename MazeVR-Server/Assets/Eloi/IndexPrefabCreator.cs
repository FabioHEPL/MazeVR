using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexPrefabCreator : MonoBehaviour
{
    public Transform root;
    public float moduleLength=4;
    [Range(0,19)]
    public int x, y;
    [Range(0, 3)]
    public int rotationDirection;

    public Transform m_parentWhereToCreate;
    public GroupOfGameObjects m_objectsToCreate;


    public Transform m_debugPoint;
    [HideInInspector] public  GameObject m_lastCreated;
    
    private void OnValidate()
    {
        MoveCursor(x, y);
    }

    private void MoveCursor(int x, int y)
    {
        m_debugPoint.localPosition = new Vector3(moduleLength / 2f + x * moduleLength, 0, moduleLength / 2f + y * moduleLength);
    }

    public void CreateRandomAtTargetPointInInspector()
    {
        CreateRandomAtTargetPoint(x, y);

    }
    public void CreateRandomAtTargetPoint(int x, int y)
    {
        MoveCursor(x, y);
        Quaternion rot = Quaternion.Euler(0, 90 * UnityEngine.Random.Range(0, rotationDirection + 1), 0);
        m_lastCreated  =(GameObject)  GameObject.Instantiate(GetRandomPrefabToCreate(), m_debugPoint.position, rot);
        m_lastCreated.transform.parent = m_parentWhereToCreate;
    }

    private UnityEngine.Object GetRandomPrefabToCreate()
    {
        if (m_objectsToCreate.m_prefabList.Length <= 0)
            throw new Exception("You neeeed to assign object to create ;)");
        return m_objectsToCreate.m_prefabList[UnityEngine.Random.Range(0, m_objectsToCreate.m_prefabList.Length)];
    }
}
