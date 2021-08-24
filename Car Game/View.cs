using System;
using static System.Console;
using System.Collections.Generic;

namespace Game
{

    class View : UserInterface
    {
        //private System.Media.SoundPlayer player;

        private string[] CarInterface = new string[4];


        // инициализирует массив (внешний вид всех объектов)
        public View()
        {
            CarInterface[0] = "=--=";
            CarInterface[1] = "|++|";
            CarInterface[2] = "|++|";
            CarInterface[3] = "=--=";
        }

        // выводит сплошную линию 
        override public void PrintWayLine()
        {
            ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < WindowHeight; i++)
            {
                SetCursorPosition(58, i);
                Write("|");
            }
        }

        // вывод объекта
        override public void PrintObj(KeyValuePair<uint, uint> location, ConsoleColor color)
        {
            ForegroundColor = color;

            for (int i = 0; i < CarInterface.Length; i++)
            {
                SetCursorPosition((int)location.Key, (int)location.Value - i);
                Write(CarInterface[i]);
            }
        }

        // вывод информации о жизнеспособности пользовательской машины
        override public void PrintLives(int Lives)
        {
            SetCursorPosition(1, 2);
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"+-----------------+\n" +
                      $" | Жизни -         |\n" +
                      $" +-----------------+");
            SetCursorPosition(11, 3);
            Write(Lives);
        }

        // вывод информации о счете
        override public void PrintScore(long Score)
        {
            SetCursorPosition(1, 6);
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"+-----------------+\n" +
                      $" | Счет -          |\n" +
                      $" +-----------------+");
            SetCursorPosition(11, 7);
            Write(Score);
        }

        // вывод информации о скорости
        override public void PrintSpeed(int speed)
        {
            SetCursorPosition(1, 10);
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine($"+-----------------+\n" +
                      $" | Скорость -      |\n" +
                      $" +-----------------+");
            SetCursorPosition(15, 11);
            Write(200 - speed);
        }

        // вывод рисунка сообщающий о паузе
        public override void StopRunGrafiiti()
        {         
            string[] pauseG = new string[9];
            pauseG[0] = " 1101010          01         10        01    1101010    10110010100";
            pauseG[1] = " 10     01       0001        00        11   10      01  00         ";
            pauseG[2] = " 01     10      11  10       11        00   01          11         ";
            pauseG[3] = " 01     10     10    01      10        10   01          1011001    ";
            pauseG[4] = " 1001001      00 1010 01     01        11    01001101   11         ";
            pauseG[5] = " 10          10        10    11        01          01   00         ";
            pauseG[6] = " 11         10          00   00        01   10     10   01         ";
            pauseG[7] = " 00        10            00    01010110      1101010    10110010100";
            pauseG[8] = "====================================================================";
            ForegroundColor = ConsoleColor.DarkBlue;
            for(int i =  0;i < pauseG.Length;i++)
            {
                SetCursorPosition(27, 10 + i);
                WriteLine(pauseG[i]);
            }
        }

        // вывод дороги (ограничений)
        override public void ShowСonfines()
        {
            string way = " ";
            for (int i = 0; i < WindowHeight; i++)
            {
                BackgroundColor = ConsoleColor.Blue;
                SetCursorPosition(31, i);
                Write(way);

                SetCursorPosition((int)((WindowWidth / 1.4) - 1), i);
                Write(way);
            }
            BackgroundColor = ConsoleColor.Black;
        }

        // заставка игры
        override public void Cover()
        {
            BufferHeight = WindowHeight = 45;
            BufferWidth = WindowWidth = 120;
            PrintObj(new KeyValuePair<uint, uint>(0,3),ConsoleColor.Red);
            SetCursorPosition(0, 4);
            Write("враг");
            PrintObj(new KeyValuePair<uint, uint>(10,3), ConsoleColor.Yellow);
            SetCursorPosition(10, 4);
            Write("бонус");
            PrintObj(new KeyValuePair<uint, uint>(20,3), ConsoleColor.Blue);
            SetCursorPosition(21, 4);
            Write("ты");
            PrintObj(new KeyValuePair<uint, uint>(30, 3), ConsoleColor.Green);
            SetCursorPosition(28, 4);
            Write("здоровье");
            PrintObj(new KeyValuePair<uint, uint>(40, 3), ConsoleColor.Magenta);
            SetCursorPosition(38, 4);
            Write("скорость");
            SplashScreen();
            ReadKey();
        }

        // название игры
        override public void SplashScreen()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("\n\n\n\n\n\n\n");
            WriteLine("        1101010          11         1101010            1101010           11          00 1111  1111      10110010100\n" +
                      "       10     01        0001        01     10         00     10         0000         1110   01    01    01         \n" +
                      "      01               11  11       10     01        11                11  01        10     11    01    11         \n" +
                      "      01              10    01      1101010          00               01    01       01     00    11    1011001    \n" +
                      "      00             00 0101 00     00   01          11   101010     00 1101 11      01     10    00    01         \n" +
                      "      10            10        01    00    11         00       10    11        10     11     00    10    11         \n" +
                      "       11     10   00          10   01     10         10     11    01          11    00     10    01    00         \n" +
                      "        0010110   10            00  11      00         1101010    11            11   01     11    10    10110010100\n" +
                      "     ===============================================================================================================\n");
            ForegroundColor = ConsoleColor.Blue;
            //SetCursorPosition(46, 25);
            //Write("музыка - Geralt and Zoltan Combat");
            SetCursorPosition(46, 26);
            Write(" Играть - нажмите любую клавишу");
        }

        // играет музыку
        //override public void Song()
        //{
        //    player = new System.Media.SoundPlayer(@"Geralt and Zoltan Combat.wav");
        //    player.PlayLooping();
        //}

        // останавливает музыку
        //override public void StopPlaySong()
        //{
        //    player.Stop();
        //}

        // вывод информации об окончании игры
        override public void EndGameGraffiti()
        {
            WriteLine("  1101010          11         00 1111  1111    10110010100        1001010   01              10  10110010100  1101010   \n" +
                      " 00     10        0000        1110   01    01  01                01     01   10            01   10           00     11 \n" +
                      "11               11  01       10     11    01  11               01       01   01          10    10           11     01 \n" +
                      "00              01    01      01     00    11  1011001          00       11    11        00     1011001      1101010   \n" +
                      "11   101010    00 1101 11     01     10    00  01               11       00     11      11      01           01   10   \n" +
                      "00       10   11        10    11     00    10  11               10       01      01    11       11           10    01  \n" +
                      " 10     11   01          11   00     10    01  00                00     11        01  01        01           10     00 \n" +
                      "  1101010   11            11  01     11    10  10110010100        0100101          0101         10110010100  11      10\n" +
                      "=======================================================================================================================\n");
        }


    }
}
