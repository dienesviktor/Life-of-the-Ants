using Codecool.LifeOfAnts.Util;

namespace Codecool.LifeOfAnts.Ants
{
    public class Soldier : Ant
    {
        private int _steps;

        public Soldier(Position position) : base(position)
        {
            _steps = 0;
        }

        public override void Act(int width)
        {
            switch (_steps)
            {
                case 0:
                    if (AntPosition.X > 0 && (AntPosition.X - 1 != width / 2 || AntPosition.Y != width / 2))
                    {
                        AntPosition = new Position(AntPosition.X - 1, AntPosition.Y);
                    }
                    _steps++;
                    break;
                case 1:
                    if (AntPosition.Y < width - 1 && (AntPosition.X != width / 2 || AntPosition.Y + 1 != width / 2))
                    {
                        AntPosition = new Position(AntPosition.X, AntPosition.Y + 1);
                    }
                    _steps++;
                    break;
                case 2:
                    if (AntPosition.X < width - 1 && (AntPosition.X + 1 != width / 2 || AntPosition.Y != width / 2))
                    {
                        AntPosition = new Position(AntPosition.X + 1, AntPosition.Y);
                    }
                    _steps++;
                    break;
                case 3:
                    if (AntPosition.Y > 0 && (AntPosition.X != width / 2 || AntPosition.Y - 1 != width / 2))
                    {
                        AntPosition = new Position(AntPosition.X, AntPosition.Y - 1);
                    }
                    _steps = 0;
                    break;
            }
        }
        public override string ToString()
        {
            return "S ";
        }
    }
}