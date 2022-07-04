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
            Console.WriteLine("Menu game");
            Console.WriteLine();
            Console.WriteLine("1.View hero stats ");
            Console.WriteLine("2.Fight the monsters");
            Console.WriteLine("3.View inventory");
            Console.WriteLine("Exit from the game (Esc)");
        }


        static void input(Player player1, Monsters monsters1)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    {
                        player1.PrintInfoPlayer();
                        PrintMenu();
                        input(player1, monsters1);
                        break;
                    }
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    {
                        Console.Clear();
                        if (player1.isAlive() == false)
                        {
                            Console.WriteLine("Player dead((");
                            Console.ReadLine();
                            PrintMenu();
                            input(player1, monsters1);

                        }
                        else if (player1.isAlive())
                        {
                            Fight(player1, monsters1);
                        }
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        return;
                    }
            }
        }

        static void Fight(Player player1, Monsters monsters1)
        {
            monsters1=Monsters.GetMonster();  //getNewMonster
            player1.PrintPlayer();
            monsters1.PrintMonster();
            while (monsters1.isAlive())
            {
                if (player1.isAlive())
                {
                    player1.Attack(player1, monsters1);
                    monsters1.Attack(player1, monsters1);
                    if (player1.isAlive() == false)
                    {
                        Console.WriteLine("YOU DEAD!!!!!((((");
                        Console.ReadLine();
                        PrintMenu();
                        input(player1, monsters1);

                    }
                    if (monsters1.isAlive() == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("MOSTER DEAD:D))))))");
                        Console.ReadLine();
                        PrintMenu();
                        input(player1, monsters1);
                    }
                    player1.InfoFightPlayer(monsters1);
                    monsters1.InfoFightMonster(player1);
                    player1.PrintPlayer();
                    monsters1.PrintMonster();
                    Console.Write("(a)ttack/(r)un away:");
                    string attOrRun = Console.ReadLine();
                    switch (attOrRun)
                    {
                        case "a":
                            break;
                        case "r":
                            int randNum = MathUtils.GetRandomNumber(2);
                            Console.WriteLine();
                            Console.WriteLine("50/50 chance run away");
                            Console.WriteLine();
                            switch (randNum)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Bruh...Player run away\n");
                                    Console.WriteLine("NEW MONSTER");
                                    Console.WriteLine();
                                    Fight(player1, monsters1);
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
            player2.CreatePlater();
            player2.classPlayer1();
            PrintMenu();
            input(player2,monsters2);
            Console.ReadLine();
        }
    }
}
