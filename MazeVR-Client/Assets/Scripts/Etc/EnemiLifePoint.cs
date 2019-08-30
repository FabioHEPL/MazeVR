using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeVR.Server
{
    public class EnemiLifePoint : MonoBehaviour
    {
        [SerializeField] int lifePoint = 10;

        public int LifePoint
        {
            get
            {
                return lifePoint;
            }

            set
            {
                lifePoint = value;
            }
        }

        private void Update()
        {
            if (lifePoint < 0)
            {
                lifePoint = 0;
            }
        }
    }
}
