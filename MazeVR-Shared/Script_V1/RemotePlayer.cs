using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public class RemotePlayer : RemoteEntity
    { 

        [SerializeField]
        private int id = 1;

        public override int ID => this.id;

        public override void Synchronize(OscMessage message)
        {
            float x = message.GetFloat(1);
            float y = message.GetFloat(2);
            float z = message.GetFloat(3);

            transform.position = new Vector3(x, y, z);
        }       
    }
}
