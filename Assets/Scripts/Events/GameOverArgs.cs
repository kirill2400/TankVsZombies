using System;

public class GameOverArgs : EventArgs
{
    public readonly int ZombieKilled;
    public readonly float TimeSurvived;

    public GameOverArgs(int zombieKilled = 0, float timeSurvived = 0f)
    {
        ZombieKilled = zombieKilled;
        TimeSurvived = timeSurvived;
    }
}
