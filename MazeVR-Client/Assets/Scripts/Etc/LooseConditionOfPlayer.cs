using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class LooseConditionOfPlayer : MonoBehaviour
    {
        [SerializeField] int lifePointCharater = 1;
        [SerializeField] GameObject playerLose;

        void Update()
        {
            if (lifePointCharater == 0)
            {
                playerLose.SetActive(true);
            }

            if (lifePointCharater < 0)
            {
                lifePointCharater = 0;
            }
        }
    }
}