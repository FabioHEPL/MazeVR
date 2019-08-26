using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MazeVR.Scripts
{
    public class SpawnMobRemote : NetworkOperation
    {
        [SerializeField]
        private GameObject mobPrefab;        

        [SerializeField]
        protected int id;

        public override int ID => this.id;

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
