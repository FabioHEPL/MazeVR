using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    [CreateAssetMenu(fileName = "Rotate", menuName = "Operations/Rotate")]
    public class Rotate : Operation
    {
        public Selection selection;
        public float angle;

        public override void Execute()
        {
            GameObject[] gameObjects = selection.Elements;

            if (gameObjects.Length != 1)
                return;

            gameObjects[0].transform.Rotate(new Vector3(0f, angle, 0f));

            base.OnExecuted();
        }
    }
}
    