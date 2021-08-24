using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace Game
{
    class GameZone : Way
    {
        
        public GameZone() : base() { }

        // добавление объектов в лист(объекты наследники класса Obstacle)
        public override void AddObstacle(Obstacle obj)
        {
            obstacles.Add(obj);
        }

        // удаление объекта при выходе за грань консоли
        public override void DeleteObstacle()
        {
            if (obstacles.Count != 0 && obstacles.First().AxisY == Console.WindowHeight - 1)
                obstacles.Remove(obstacles.First());
        }

        // движение всех объектов
        public override void MoveObstacles()
        {
            for (int i = 0; i < obstacles.Count; i++)
                if (obstacles[i].AxisY + 1 <= Console.WindowHeight) 
                    obstacles[i].Move();
        }

        // движение пользователя
        public override void MoveCar()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKey move = Console.ReadKey().Key;
                if (move == ConsoleKey.RightArrow && user.AxisX + 2 < 82)
                    user.Right();
                else if (move == ConsoleKey.LeftArrow && user.AxisX - 2 > 31)
                    user.Left();
                else if (move == ConsoleKey.Escape)
                {
                    Console.Clear();
                    obstacles.Clear();
                    StopRun();
                    Console.ReadKey();
                }
            }
        }

        // геттер координат пользователя
        public override KeyValuePair<uint, uint> GetCarCoordinate()
        {
            return user.GetMachineLocation();
        }

        // вывод граффити остановки игры
        private void StopRun()
        {
            View view = new View();
            view.StopRunGrafiiti();
        }

        // работа с методами ShowScore(ref long record), NewRecord()
        private void EndGame(View view)
        {
            Console.Clear();
            long record = ReadScoreFromFile("Record.txt");
            if (record > Score)
                ShowScore(ref record);
            else
                NewRecord();

            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.Red;
            //view.StopPlaySong();
            view.EndGameGraffiti();
            Console.ReadLine();
            Environment.Exit(0);
        }

        // вывод информации о счете
        private void ShowScore(ref long record)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(50, 25);
            Console.WriteLine($"рекорд: {record}");
            Console.SetCursorPosition(51, 27);
            Console.Write($"счет - {Score}");
        }

        // вывод информации о счете
        private void NewRecord()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(52, 25);
            Console.Write($"!!! НОВЫЙ РЕКОРД - {Score} !!!");
            SaveScoreInFile("Record.txt");
        }

        // запись нового рекорда в файл
        private void SaveScoreInFile(in string filename)
        {
            using (StreamWriter file = new StreamWriter(filename))
            {
                file.Write(Convert.ToString(Score));
            }
        }

        // считывание ЧИСЛА из файла
        private long ReadScoreFromFile(in string filename)
        {
            long Record;
            using (StreamReader file = new StreamReader(filename))
            {
                Record = Convert.ToInt64(file.ReadToEnd());
            }
            return Record;
        }

        // столкновение пользователя с объектами
        public override bool Collision(View view, ref int speed)
        {
            foreach (Obstacle obs in obstacles)
            {
                if (((obs.AxisX >= user.AxisX && obs.AxisX <= user.AxisX + user.Width - 1) || (obs.AxisX <= user.AxisX && obs.AxisX + obs.Width - 1 >= user.AxisX))
                && ((obs.AxisY >= user.AxisY && obs.AxisY <= user.AxisY + user.Height - 1) || (obs.AxisY <= user.AxisY && obs.AxisY + obs.Height - 1 >= user.AxisY)))
                {
                    if (obs.GetType() == typeof(HP))
                    {
                        Lives++;
                        obstacles.Remove(obs);
                        break;
                    }
                    else if (obs.GetType() == typeof(Enemy))
                    {
                        if (Lives > 1)
                        {
                            if (Score - 200 < 0) 
                                Score = 0;
                            else Score -= 200;

                            obstacles.Clear();

                            if (200 - speed > 20) 
                                speed += 10;
                            Lives--;
                            return true;
                        }
                        EndGame(view);
                        break;
                    }
                    else if (obs.GetType() == typeof(Speed))
                    {
                        if (speed > 40) speed -= 10;                       
                        obstacles.Remove(obs);
                        break;
                    }
                    else
                    {
                        Score += 100;
                        obstacles.Remove(obs);
                        break;
                    }
                }
            }
            return false;
        }

    }
}
