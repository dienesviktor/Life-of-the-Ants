using System;

namespace Codecool.LifeOfAnts;

public class Program
{
    public static void Main()
    {
        int colonySize = InputValidation("Colony size:", 15);
        int drones = InputValidation("Drones number:", 3);
        int workers = InputValidation("Workers number:", 3);
        int soldiers = InputValidation("Soldiers number:", 3);
        Simulation(colonySize, drones, workers, soldiers);
    }

    public static void Simulation(int colonySize, int drones, int workers, int soldiers)
    {
        Colony colony = new Colony(colonySize);
        colony.PlaceQueen();
        colony.GenerateAnts(drones, workers, soldiers);
        while (true)
        {
            Console.Clear();
            colony.Display();
            colony.Update();
        }
    }

    public static int InputValidation(string displayText, int defaultValue)
    {
        Console.WriteLine($"{displayText}:");
        int parsedValue;
        if (!int.TryParse(Console.ReadLine(), out parsedValue))
        {
            parsedValue = defaultValue;
        }
        return parsedValue;
    }
}