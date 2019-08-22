using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR_Shared
{
    public class Player_Demo : MonoBehaviour
    {
        [SerializeField]
        private float movementSpeed = 5;

        [SerializeField]
        private OSC osc;
        private bool running = false;

        private void Awake()
        {
            this.osc = FindObjectOfType<OSC>();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");

            if (inputHorizontal != 0f)
            {
                Translate(new Vector3(inputHorizontal, 0, 0));
                NetworkPositionUpdate();
            }

            if (inputVertical != 0f)
            {
                Translate(new Vector3(0, 0, inputVertical));
                NetworkPositionUpdate();
            }

            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                if (running)
                    running = false;
                else
                    running = true;
            }

            if (running)
            {
                Translate(new Vector3(0, 0, 20 * Time.deltaTime));
                NetworkPositionUpdate();
            }
        }

        private void NetworkPositionUpdate()
        {
            OscMessage message = new OscMessage();
            message.address = "/PositionUpdate";
            message.values.Add(transform.position.x);
            message.values.Add(transform.position.y);
            message.values.Add(transform.position.z);
            osc.Send(message);

            Debug.Log("sending position...");
        }

        private void Translate(Vector3 direction)
        {
            Vector3 movement = transform.TransformDirection(direction) * Time.deltaTime * movementSpeed;
            transform.position += movement;
        }
    }
}