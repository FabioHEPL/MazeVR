using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class RemoteMob : RemoteEntity
    {
        [SerializeField]
        private GameObject avatar;

        [SerializeField]
        private Vulnerable avatar;

        [SerializeField]
        private int id = 10;


        public override int ID => this.id;

        public override void Synchronize(OscMessage message)
        {
            float x = message.GetFloat(1);
            float y = message.GetFloat(2);
            float z = message.GetFloat(3);

            avatar.transform.position = new Vector3(x, y, z);
        }       
    }
}
