using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : MonoBehaviour
{
    [SerializeField]
    private Transform subject;

    [SerializeField]
    private Transform identity;

    [SerializeField]
    private float smoothFactor = 90;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if (identity != null)
        {
            this.transform.position = identity.position;
            this.transform.rotation = identity.rotation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, subject.transform.rotation, smoothFactor * Time.deltaTime);
    }
}
