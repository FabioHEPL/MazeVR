using MazeVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkLevel : NetworkEntity
{
    [SerializeField]
    private int id = 2;

    [SerializeField]
    private Rotate rotateOperation;

    [SerializeField]
    private Swap swapOperation;

    public override int ID => this.id;

    public override void Synchronize(OscMessage message)
    {
        if (message.address.Equals("/Rotation"))
        {
            int tileId = message.GetInt(1);
            float rotationAngle = message.GetFloat(2);

            GameObject tile = transform.GetChild(tileId).gameObject;
            tile.transform.Rotate(new Vector3(0, rotationAngle, 0));
        }
        
        if (message.address.Equals("/Swap"))
        {
            int firstTileId = message.GetInt(1);
            int secondTileId = message.GetInt(2);

            GameObject first = transform.GetChild(firstTileId).gameObject;
            GameObject second = transform.GetChild(secondTileId).gameObject;
            Swap(first, second);
        }
    }

    protected override void OnUpdated(NetworkEntityUpdatedArgs args)
    {
        base.OnUpdated(args);
    }

    private void OnEnable()
    {
        rotateOperation.Executed += RotateOperation_Executed;
        swapOperation.Executed += SwapOperation_Executed;
    }

    private void OnDisable()
    {
        rotateOperation.Executed -= RotateOperation_Executed;
        swapOperation.Executed -= SwapOperation_Executed;
    }

    private void Awake()
    {
        
    }
       
    private void RotateOperation_Executed()
    {
      
        int tileId = rotateOperation.selection.Elements[0].transform.GetSiblingIndex();

        Debug.Log($"tileId : {tileId}, angle : {rotateOperation.angle}");
        NetworkEntityUpdatedArgs args = new NetworkEntityUpdatedArgs("Rotation", tileId, rotateOperation.angle);
        OnUpdated(args);
    }  

    private void SwapOperation_Executed()
    {
        int firstTileId = rotateOperation.selection.Elements[0].transform.GetSiblingIndex();
        int secondTileId = rotateOperation.selection.Elements[1].transform.GetSiblingIndex();
        Debug.Log($"firstId : {firstTileId}, secondId : {secondTileId}");

        NetworkEntityUpdatedArgs args = new NetworkEntityUpdatedArgs("Swap", firstTileId, secondTileId);
        OnUpdated(args);
    }

    private void Swap(GameObject first, GameObject second)
    {
        Vector3 firstPosition = first.transform.position;
        first.transform.position = second.transform.position;
        second.transform.position = firstPosition;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
