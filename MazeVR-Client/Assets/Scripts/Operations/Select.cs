using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Select : Operation
{
    [SerializeField]
    private Selection selection;
    [SerializeField]
    private LayerMask layer;

    public override void Execute()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layer))
        {
            selection.Include(hit.collider.gameObject);
        }
    }
}