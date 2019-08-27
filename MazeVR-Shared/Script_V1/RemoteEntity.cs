using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public abstract class RemoteEntity : MonoBehaviour
    {
        public abstract int ID { get; }        
        public abstract void Synchronize(OscMessage message);
    }
}
