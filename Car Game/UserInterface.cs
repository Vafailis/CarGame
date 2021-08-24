using System;
using System.Collections.Generic;

namespace Game
{
    abstract class UserInterface
    {
        abstract public void PrintSpeed(int speed);

        abstract public void PrintWayLine();

        abstract public void PrintObj(KeyValuePair<uint, uint> location, ConsoleColor color);

        abstract public void PrintScore(long Score);

        abstract public void PrintLives(int Lives);

        abstract public void ShowСonfines();

        abstract public void Cover();

        abstract public void SplashScreen();

        //abstract public void Song();

        //abstract public void StopPlaySong();

        abstract public void StopRunGrafiiti();

        abstract public void EndGameGraffiti();
    }
}
