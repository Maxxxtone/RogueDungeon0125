using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueDungeon0125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            int playerHealth = 100, maxHealth = 100, gold = 0,
                posX = 0, posY = 0;
            //для карты
            int mapWidth = 10, mapHeight = 10, playerInputPosition = 15, 
                hudCursorPosition = 13;
            // вывод игрового поля
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            // вывод персонажа
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(posX, posY);
            Console.Write("H");
            Console.ResetColor();
            Console.SetCursorPosition(0, hudCursorPosition);
            // вывод строки состояния
            Console.WriteLine($"♥️[{playerHealth}/{maxHealth}] ${gold, -5}");

            // передвижение игрока
            while (true)
            {
                Console.SetCursorPosition(0, playerInputPosition);
                Console.Write("Двинуться: ");
                var key = Console.ReadKey();
                int stepX = 0, stepY = 0;
                switch (key.Key)
                {
                    case ConsoleKey.D:
                        if (posX / 2 == mapWidth - 1)
                            continue;
                        stepX = 2;
                        break;
                    case ConsoleKey.A:
                        if (posX == 0)
                            continue;
                        stepX = -2;
                        break;
                    case ConsoleKey.W:
                        if (posY == 0)
                            continue;
                        stepY = -1;
                        break;
                    case ConsoleKey.S:
                        if (posY == mapHeight - 1)
                            continue;
                        stepY = 1;
                        break;
                }
                Console.SetCursorPosition(posX, posY);
                Console.Write("#");
                // меняем позицию
                posX += stepX;
                posY += stepY;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(posX, posY);
                Console.Write("H");
                Console.ResetColor();
            }
        }
    }
}
