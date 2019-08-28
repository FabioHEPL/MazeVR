using System;
using UnityEngine;


namespace MazeVR.Shared
{
    public class MobCreatedArgs : EventArgs
    {
        private GameObject mob;
        public GameObject Mob => mob;

        public MobCreatedArgs(GameObject mob)
        {
            this.mob = mob;
           
        }
    }
}