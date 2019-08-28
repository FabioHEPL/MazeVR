using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Client
{
    public class InputManager : MonoBehaviour
    {
        public CustomInput[] inputs;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            foreach (CustomInput input in inputs)
            {
                input.Process();
            }
        }
    }
}
