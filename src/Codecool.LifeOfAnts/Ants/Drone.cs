using System;
using Codecool.LifeOfAnts.Util;

namespace Codecool.LifeOfAnts.Ants;

public class Drone : Ant
{
    private static int _dronesNum = 0;
    private readonly int _currentDrone;
    private bool _status;
    private int _tempCounter;

    public Drone(Position position) : base(position)
    {
        _status = false;
        _dronesNum++;
        _currentDrone = _dronesNum;
    }

    public override void Act(int width)
    {

        if (_status is false)
        {
            if (AntPosition.X < width / 2 - 1)
            {
                AntPosition = new Position(AntPosition.X + 1, AntPosition.Y);
            }
            else if ((AntPosition.X > width / 2 + 1))
            {
                AntPosition = new Position(AntPosition.X - 1, AntPosition.Y);
            }
            else if (AntPosition.Y < width / 2 - 1)
            {
                AntPosition = new Position(AntPosition.X, AntPosition.Y + 1);
            }
            else if (AntPosition.Y > width / 2 + 1)
            {
                AntPosition = new Position(AntPosition.X, AntPosition.Y - 1);
            }
            else
            {
                if (Counter <= 0)
                {
                    Counter = new Random().Next(50, 101);
                    _status = true;
                    _tempCounter = Counter;
                }
                else
                {
                    Random r = new Random();
                    int rowOrCol = r.Next(0, 2) == 0 ? 0 : 1;
                    int[] values = { 0, width - 1 };
                    if (rowOrCol == 0)
                    {
                        AntPosition = new Position(values[r.Next(0, 2)], r.Next(0, width - 1));
                    }
                    else
                    {
                        AntPosition = new Position(r.Next(0, width - 1), values[r.Next(0, 2)]);
                    }
                }
                Talk();
            }
        }
        else
        {
            if (_tempCounter - 10 >= Counter)
            {
                _status = false;
                Random r = new Random();
                int rowOrCol = r.Next(0, 2) == 0 ? 0 : 1;
                int[] values = { 0, width - 1 };
                if (rowOrCol == 0)
                {
                    AntPosition = new Position(values[r.Next(0, 2)], r.Next(0, width - 1));
                }
                else
                {
                    AntPosition = new Position(r.Next(0, width - 1), values[r.Next(0, 2)]);
                }
            }
        }
    }

    public override string ToString()
    {
        return "D ";
    }

    public void Talk()
    {
        if (_status)
        {
            Console.WriteLine($"Drone {_currentDrone}: HALLELUJAH");
        }
        else
        {
            Console.WriteLine($"Drone {_currentDrone}: :(");
        }
    }
}