using System;
using Codecool.LifeOfAnts.Util;

namespace Codecool.LifeOfAnts.Ants;

public abstract class Ant
{
    public Position AntPosition { get; set; }
    protected Random Random { get; }
    protected static int Counter { get; set; }

    public Ant(Position position)
    {
        AntPosition = position;
        Random = new Random();
        Counter = Random.Next(50, 101);
    }

    public abstract void Act(int width);

    public abstract string ToString();
}