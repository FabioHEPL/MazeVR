using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    [CreateAssetMenu(fileName = "Swap", menuName = "Operations/Swap")]
    public class Swap : Operation
    {
        public Selection selection;

        public override void Execute()
        {
            GameObject[] gameObjects = selection.Elements;

            if (gameObjects.Length != 2)
                return;

            GameObject first = gameObjects[0];
            GameObject second = gameObjects[1];

            Vector3 firstPosition = first.transform.position;
            first.transform.position = second.transform.position;
            second.transform.position = firstPosition;

            base.OnExecuted();
        }
    }
}