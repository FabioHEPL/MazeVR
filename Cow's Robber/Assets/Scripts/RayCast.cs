using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private RayCast myhit = new RayCast();

    void Start()
    {
        
    }

    void Update()
    {

        myhit = Camera.main.ScreenPointToRay(input.);

    }
}
