using System;

namespace MazeVR.Server
{
    public interface IPlayer
    {
        event EventHandler<DeathArgs> Death;
    }

    public class DeathArgs : EventArgs
    {

    }

    public interface ITimer
    {
        event EventHandler<TimeOutArgs> TimeOut;

    }

    public class TimeOutArgs : EventArgs
    {
    }
}
