using System.Linq;
using Codecool.LifeOfAnts.Util;

namespace Codecool.LifeOfAnts.Ants;

public class Queen : Ant
{
    public Queen(Position position) : base(position)
    {
    }

    public override void Act(int width)
    {
    }

    public override string ToString()
    {
        return "Q ";
    }

    public void Count(int steps)
    {
        foreach (int value in Enumerable.Range(0, steps))
        {
            Counter--;
        }
    }

}