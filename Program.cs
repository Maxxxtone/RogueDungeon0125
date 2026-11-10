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
            // интерактивные объекты
            int goldX, goldY, trapX, trapY;

            Random rnd = new Random();

            goldX = rnd.Next(0, mapWidth);
            goldY = rnd.Next(0, mapHeight);
            trapX = rnd.Next(0, mapWidth);
            trapY = rnd.Next(0, mapHeight);

            // обработка позиций при спавне
            if (goldX == 0 && goldY == 0)
            {
                goldX += 1;
            }
            if (trapX == 0 && trapY == 0)
            {
                trapY += 1;
            }
            if (goldX == trapX && goldY == trapY)
            {
                // уберем что-либо
                trapX = trapY = -1;
            }

            // вывод игрового поля
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    //TODO: выделить цветом ловушки / золото
                    if (goldX == j && goldY == i)
                        Console.Write("$ ");
                    else if (trapX == j && trapY == i)
                        Console.Write("X ");
                    else
                        Console.Write("# ");
                }
                Console.WriteLine();
            }
            // вывод персонажа
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(posX, posY);
            Console.Write("H");
            Console.ResetColor();

            // передвижение игрока
            while (true)
            {
                // вывод строки состояния
                Console.SetCursorPosition(0, hudCursorPosition);
                Console.WriteLine($"♥️[{playerHealth}/{maxHealth}] ${gold,-5}");
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
                    case ConsoleKey.Escape:
                        return;
                }
                Console.SetCursorPosition(posX, posY);
                Console.Write("#");
                // меняем позицию
                posX += stepX;
                posY += stepY;
                // поднятие монетки
                if (posX / 2 == goldX && posY == goldY)
                {
                    gold += 10;
                    goldX = goldY = -1;
                }
                // наступили на ловушку
                else if(posX/2 == trapX && posY == trapY)
                {
                    playerHealth -= 10;
                    trapX = trapY = -1;
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(posX, posY);
                Console.Write("H");
                Console.ResetColor();
            }
        }
    }
}
