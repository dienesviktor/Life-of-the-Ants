using System;
using Codecool.LifeOfAnts.Util;

namespace Codecool.LifeOfAnts.Ants;

public class Worker : Ant
{
    public Worker(Position position) : base(position)
    {

    }

    public override void Act(int width)
    {
        Random r = new Random();
        int enumLength = Enum.GetNames(typeof(Direction)).Length;
        Direction direction = (Direction) r.Next(enumLength);
        switch (direction)
        {
            case Direction.North:
                if (AntPosition.X > 0 && (AntPosition.X - 1 != width / 2 || AntPosition.Y != width / 2))
                {
                    AntPosition = new Position(AntPosition.X - 1, AntPosition.Y);
                }

                break;
            case Direction.South:
                if (AntPosition.X < width - 1 && (AntPosition.X + 1 != width / 2 || AntPosition.Y != width / 2))
                {
                    AntPosition = new Position(AntPosition.X + 1, AntPosition.Y);
                }

                break;
            case Direction.East:
                if (AntPosition.Y < width - 1 && (AntPosition.X != width / 2 || AntPosition.Y + 1 != width / 2))
                {
                    AntPosition = new Position(AntPosition.X, AntPosition.Y + 1);
                }

                break;
            case Direction.West:
                if (AntPosition.Y > 0 && (AntPosition.X != width / 2 || AntPosition.Y - 1 != width / 2))
                {
                    AntPosition = new Position(AntPosition.X, AntPosition.Y - 1);
                }

                break;
        }
    }


    public override string ToString()
    {
        return "W ";
    }

}