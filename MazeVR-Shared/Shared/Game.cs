using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace MazeVR.Shared
{
    public abstract class Game : MonoBehaviour
    {
        public event EventHandler<EndedArgs> Ended;

        protected virtual void OnEnded(EndedArgs args)
        {
            Ended?.Invoke(this, args);
        }

        public class EndedArgs : EventArgs
        {
            private EndGame endGame;
            public EndGame EndGame => this.endGame;

            public EndedArgs(EndGame endGame)
            {
                this.endGame = endGame;
            }
        }
    }
}
