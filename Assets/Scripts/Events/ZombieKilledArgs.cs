using System;

public class ZombieKilledArgs : EventArgs
{
    public int TotalZombieKilled;

    public ZombieKilledArgs(int totalZombieKilled = 0)
    {
        TotalZombieKilled = totalZombieKilled;
    }
}
