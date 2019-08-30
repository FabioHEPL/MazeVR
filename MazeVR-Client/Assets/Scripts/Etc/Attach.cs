using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attach : MonoBehaviour
{
    [SerializeField]
    private Transform to;    

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = to;
        this.GetComponent<Camera>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
