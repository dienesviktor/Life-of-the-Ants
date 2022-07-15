using System;

namespace Codecool.LifeOfAnts.Util;

public class RandomHelper
{
    private readonly Random _random = new();

    public Position GetRandomPosition(int colonySize)
    {
        while (true)
        {
            int x = _random.Next(0, colonySize);
            int y = _random.Next(0, colonySize);
            Position position = new Position(x, y);
            if (position.X != colonySize / 2 && position.Y != colonySize / 2)
            {
                return position;
            }
        }
    }
}