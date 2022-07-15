using System;
using System.Collections.Generic;
using System.Linq;
using Codecool.LifeOfAnts.Ants;
using Codecool.LifeOfAnts.Util;

namespace Codecool.LifeOfAnts;

public class Colony
{
    private int _colonySize;
    private List<Ant> _ants;
    private RandomHelper _random;

    public Colony(int width)
    {
        _colonySize = width;
        _ants = new();
        _random = new RandomHelper();
    }

    public void PlaceQueen()
    {
        Queen queen = new Queen(new Position(_colonySize / 2, _colonySize / 2));
        _ants.Add(queen);
    }

    public void GenerateAnts(int droneNum, int workerNum, int soldierNum)
    {
        foreach (int value in Enumerable.Range(0, droneNum))
        {
            Drone drone = new Drone(_random.GetRandomPosition(_colonySize));
            _ants.Add(drone);
        }
        foreach (int value in Enumerable.Range(0, workerNum))
        {
            Worker worker = new Worker(_random.GetRandomPosition(_colonySize));
            _ants.Add(worker);
        }
        foreach (int value in Enumerable.Range(0, soldierNum))
        {
            Soldier soldier = new Soldier(_random.GetRandomPosition(_colonySize));
            _ants.Add(soldier);
        }
    }

    public void Display()
    {
        for (int row = 0; row < _colonySize; row++)
        {
            for (int col = 0; col < _colonySize; col++)
            {
                Console.Write(GetAntRepresentation(row, col) ?? ". ");
            }
            Console.WriteLine();
        }
    }

    public string GetAntRepresentation(int row, int col)
    {
        foreach (Ant ant in _ants)
        {
            if (ant.AntPosition.X == row && ant.AntPosition.Y == col)
            {
                return ant.ToString();
            }
        }
        return null;
    }

    public void Update()
    {
        int steps = 0;
        foreach (Ant ant in _ants)
        {
            ant.Act(_colonySize);
            if (ant is Drone)
            {
                Drone drone = (Drone)ant;
            }
            steps++;
        }
        foreach (Ant ant in _ants)
        {
            if (ant is Queen)
            {
                Queen queen = (Queen)ant;
                queen.Count(steps - 1);
            }
        }
        string input = Console.ReadLine();
        if (input.ToUpper() == "Q" || input.ToUpper() == "EXIT")
        {
            Environment.Exit(0);
        }
    }
}