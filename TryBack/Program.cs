using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryBack
{
    class Program
    {

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("\t\tMenu game");
            Console.WriteLine("1.View hero stats ");
            Console.WriteLine("2.Fight the monsters");
            Console.WriteLine("3.View inventory");
            Console.WriteLine("4.exit from the game");
        }


        static void input(Player player1, Monsters monsters1)
        {
            int inputMenu = int.Parse(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:
                    player1.PrintInfoPlayer();
                    Console.Write("Exit to menu game??? (1-yes): ");
                    int comeMenu = int.Parse(Console.ReadLine());
                    switch (comeMenu)
                    {
                        case 1:
                            PrintMenu();
                            input(player1, monsters1);
                            break;
                    }
                    break;
                case 2:
                    Fight(player1, monsters1);
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        static void Fight(Player player1, Monsters monsters1)
        {
            while (monsters1.isAlive())
            {
                if (player1.isAlive())
                {
                    player1.Attack(player1, monsters1);
                    monsters1.Attack(player1, monsters1);
                    player1.PrintPlayer();
                    monsters1.PrintMonster();
                    if (player1.isAlive() == false)
                    {
                        Console.WriteLine("YOU DEAD!!!!!((((");
                        Console.Write("Exit to menu game??? (1-exit):");
                        int inputNumber1 = int.Parse(Console.ReadLine());
                        switch (inputNumber1)
                        {
                            case 1:
                                PrintMenu();
                                input(player1,monsters1);
                                break;
                        }
                        break;
                    }
                    if (monsters1.isAlive() == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("MOSTER DEAD:D))))))");
                        Console.WriteLine("Exit to menu game??? (1-exit)");
                        int inputNumber2 = int.Parse(Console.ReadLine());
                        switch (inputNumber2)
                        {
                            case 1:
                                PrintMenu();
                                input(player1, monsters1);
                                break;
                        }
                        break;
                    }
                    Console.Write("Attack or run away 1-attack, 2-run away:");
                    int attOrRun = int.Parse(Console.ReadLine());
                    switch (attOrRun)
                    {
                        case 1:
                            break;
                        case 2:
                            int randNum = MathUtils.GetRandomNumber(2);
                            Console.WriteLine();
                            Console.WriteLine("50/50 chance run away:" + randNum);
                            Console.WriteLine();
                            switch (randNum)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.WriteLine("Bruh...Player run away\n");
                                    Console.WriteLine("NEW MONSTER");
                                    monsters1 = Monsters.GetMonster();
                                    Console.WriteLine();
                                    break;
                            }
                            break;
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Player player2=Player.GetPlayer();
            Monsters monsters2 = Monsters.GetMonster();
            PrintMenu();
            input(player2,monsters2);
            Console.ReadLine();
        }
    }
}
