using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroupOfObject", menuName = "Maze VR/Group of Objects", order = 1)]
public class GroupOfGameObjects : ScriptableObject{
    public GameObject[] m_prefabList;
}