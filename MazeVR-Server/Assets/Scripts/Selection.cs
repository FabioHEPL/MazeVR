using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private KeyCode rotateLeftKey;
    [SerializeField]
    private KeyCode rotateRightKey;
    [SerializeField]
    private KeyCode swapKey;

    private float rotationAngle = 90f;

    private Camera raycastCamera;

    // DEBUG:
    [SerializeField]
    private GameObject[] elements;

    [SerializeField]
    private Material highlightMaterial;

    [SerializeField]
    private Material[] elementsMatieralsBuffer;

    [SerializeField]
    private int selectionLength = 0;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        this.elements = new GameObject[2];
        this.elementsMatieralsBuffer = new Material[2];
        this.raycastCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(raycastCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, layerMask))
            {
                Select(hit.collider.gameObject);
            }
        }

        if (Input.GetKeyDown(rotateLeftKey))
        {
            RotateLeft();
        }

        if (Input.GetKeyDown(rotateRightKey))
        {
            RotateRight();
        }

        if (Input.GetKeyDown(swapKey))
        {
            Swap();
        }
    }

    public void RotateLeft()
    {
        if (selectionLength != 1)
            return;

        this.elements[0].transform.Rotate(new Vector3(0f, -rotationAngle, 0));

        Deselect();
    }

    public void RotateRight()
    {
        if (selectionLength != 1)
            return;

        this.elements[0].transform.Rotate(new Vector3(0f, rotationAngle, 0));

        Deselect();
    }

    public void Swap()
    {
        if (selectionLength != 2)
            return;

        GameObject first = this.elements[0];
        GameObject second = this.elements[1];

        Vector3 firstPosition = first.transform.position;
        first.transform.position = second.transform.position;
        second.transform.position = firstPosition;

        Deselect();
    }

    public void Select(GameObject gameObject)
    {
        if (selectionLength % elements.Length == 0)
        {
            Deselect();
            selectionLength = 1;
        }
        else
        {
            selectionLength++;
        }
      
        this.elements[selectionLength - 1] = gameObject;
        HighlightMaterial(gameObject);
    }

    public void Deselect()
    {
        ResetMaterial();
        selectionLength = 0;
    }

    private void HighlightMaterial(GameObject gameObject)
    {
        Renderer renderer = GetGameObjectRenderer(gameObject);
        this.elementsMatieralsBuffer[selectionLength - 1]
            = renderer.material;
        renderer.material = highlightMaterial;
    }

    private void ResetMaterial()
    {
        for (int i = 0; i < selectionLength; i++)
        {
            Renderer renderer = GetGameObjectRenderer(this.elements[i]);
            renderer.material = this.elementsMatieralsBuffer[i];
        }
    }

    private Renderer GetGameObjectRenderer(GameObject gameObject)
    {
        GameObject meshGameObject = gameObject.transform.GetChild(0).gameObject;
        return meshGameObject.GetComponent<Renderer>();
    }
}



