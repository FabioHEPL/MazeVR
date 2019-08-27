using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR
{
    public abstract class LocalEntity : MonoBehaviour
    {
        public abstract int ID { get; }
        public event EventHandler<LocalEntityUpdatedArgs> Updated;

        protected virtual void OnUpdated(LocalEntityUpdatedArgs args)
        {
            Updated?.Invoke(this, args);
        }
    }
}
