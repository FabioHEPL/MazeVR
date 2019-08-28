using MazeVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class NetworkLevel_Client : NetworkEntity
    {
        [SerializeField]
        private int id = 2;

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

        private void Awake()
        {

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
}