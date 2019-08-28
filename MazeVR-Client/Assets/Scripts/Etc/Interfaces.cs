using System;

namespace MazeVR.Server
{
    public interface Player
    {
        void DealDamage(int amount);
        event EventHandler<DeathArgs> Death;
        int Health { get; }
    }

 
}