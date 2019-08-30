using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public static class NetworkDebug
    {
        public static void Log(object message)
        {
            Debug.Log("[Network] " + message);
        }
    }
}
