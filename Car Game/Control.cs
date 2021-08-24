using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    public class Control
    {
        // инициализация объектов
        internal void Head()
        {
            View view = new View();
            view.Cover();
            //view.Song();
            Random rnd = new Random();
            Way game = new GameZone();
            int chance = 0;
            int speed = 160;
            Begin(ref view, ref rnd, ref game, ref chance, ref speed);
        }

        // реализация работы всей игры
        internal void Begin(ref View view, ref Random rnd, ref Way game, ref int chance, ref int speed)
        {
            while (true)
            {
                if (game.Collision(view, ref speed)) break;               
                view.ShowСonfines();
                view.PrintWayLine();
                view.PrintScore(game.Score);
                view.PrintLives(game.Lives);
                view.PrintSpeed(speed);
                AddObstacls(ref game, ref rnd, ref chance,8, 500);
                PrintObstacls(ref game, ref view);
                game.MoveObstacles();
                game.MoveCar();
                view.PrintObj(game.GetCarCoordinate(), ConsoleColor.Blue);
                Thread.Sleep(speed);
                Console.Clear();
                game.DeleteObstacle();
                game.Score++;
                chance++;
            }
            Begin(ref view, ref rnd, ref game, ref chance, ref speed);
        }

        // генерария объектов
        internal void AddObstacls(ref Way game, ref Random rnd, ref int chance, int rnd1, int rnd2)
        {
            if (chance % 4 == 0)
            {
                int random = rnd.Next(0, 100);
                uint coordinate = (uint)rnd.Next(32, 80);
                if (random >= 30)
                    game.AddObstacle(new Enemy(4, 4, coordinate, 3));
                else if (random < 30 && random > 11)
                    game.AddObstacle(new Bonus(4, 4, coordinate, 3));
                else if (random < 11 && random > 3)
                    game.AddObstacle(new Speed(4, 4, coordinate, 3));
                else if (random < 3)
                    game.AddObstacle(new HP(4, 4, coordinate, 3));
            }
        }

        // вывод всех объектов
        internal void PrintObstacls(ref Way game, ref View view)
        {
            for (int j = 0; j < game.obstacles.Count; j++)
            {
                ConsoleColor color = ConsoleColor.Red;
                if (typeof(HP) == game.obstacles[j].GetType())
                    color = ConsoleColor.Green;
                else if (typeof(Bonus) == game.obstacles[j].GetType())
                    color = ConsoleColor.Yellow;
                else if (typeof(Speed) == game.obstacles[j].GetType())
                    color = ConsoleColor.Magenta;
                view.PrintObj(game.obstacles[j].GetObstacleLocation(), color);
            }
        }
    }
}
