using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Highlight", menuName = "Effects/Highlight")]
public class Highlight : ScriptableObject
{    
    [SerializeField]
    private Material material;

    public Material Material => material;

    private Material initial;
    private Renderer renderer;

    public void Apply(GameObject gameObject)
    {
        renderer = gameObject.transform.GetChild(0).GetComponent<Renderer>();
        initial = renderer.material;
        renderer.material = material;
    }

    public void Undo()
    {
        renderer.material = initial;
    }

    public void Initialise(Material material)
    {
        this.material = material;
    }

}

