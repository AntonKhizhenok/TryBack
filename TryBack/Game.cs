using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBack
{
    static class Game
    {

        public static void Start()
        {
            Player player = Player.CreatePlayer();
            PrintMenu();
            input(player);
        }
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu game");
            Console.WriteLine();
            Console.WriteLine("1.View hero stats ");
            Console.WriteLine("2.Fight the monsters");
            Console.WriteLine("3.View inventory");
            Console.WriteLine("Exit from the game (Esc)");
        }


        public static void input(Player player1)
        {
            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    {
                        player1.PrintInfoPlayer();
                        Console.WriteLine("Use ENTER to continie");
                        var MenuKey = Console.ReadKey();
                        switch (MenuKey.Key)
                        {
                            case ConsoleKey.Enter:
                                PrintMenu();
                                input(player1);
                                break;
                        }
                        break;
                    }
                case ConsoleKey.NumPad2:
                case ConsoleKey.D2:
                    {
                        Console.Clear();
                        if (player1.isAlive() == false)
                        {
                            Console.WriteLine("You dead(");
                            Console.ReadLine();
                            PrintMenu();
                            input(player1);

                        }
                        else if (player1.isAlive())
                        {
                            Monsters monsters1 = Monsters.GetMonster();
                            Fight(player1, monsters1);
                        }
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        Save(player1);
                        Exit();
                        break;
                    }

            }
        }
        public static void Fight(Player player1, Monsters monsters1)
        {
            monsters1 = Monsters.GetMonster();  //getNewMonster
            monsters1.PrintMonster();
            while (monsters1.isAlive())
            {
                if (player1.isAlive())
                {
                    Console.Write("(a)ttack/(r)un away(50%):");
                    string attOrRun = Console.ReadLine();
                    switch (attOrRun)
                    {
                        case "a":
                            break;
                        case "r":
                            int randNum = MathUtils.GetRandomNumber(2);
                            Console.WriteLine();
                            switch (randNum)
                            {
                                case 0:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("You failed to escape");
                                    Console.ResetColor();
                                    break;
                                case 1:
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("You have run away successfully\n");
                                    Console.ResetColor();
                                    Fight(player1, monsters1);
                                    break;
                            }
                            break;
                    }
                    player1.Attack(player1, monsters1);
                    monsters1.Attack(player1, monsters1);
                    if (player1.isAlive() == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("YOU DEAD");
                        Console.ResetColor();
                        Console.WriteLine();
                        Console.WriteLine("Use ENTER to continie");
                        var PlayerDeadKey = Console.ReadKey();
                        switch (PlayerDeadKey.Key)
                        {
                            case ConsoleKey.Enter:
                                PrintMenu();
                                input(player1);
                                break;
                        }
                    }
                    if (monsters1.isAlive() == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"{monsters1.name} is dead");
                        Console.ResetColor();
                        Console.WriteLine("Use ENTER to continie");
                        var MonsterDeadKey = Console.ReadKey();
                        switch (MonsterDeadKey.Key)
                        {
                            case ConsoleKey.Enter:
                                PrintMenu();
                                input(player1);
                                break;
                        }
                    }
                    player1.InfoFightPlayer(monsters1);
                    monsters1.InfoFightMonster(player1);
                }
            }
        }
        public static void Save(Player player)
        {
            player.WriteInfoPlayer();
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
