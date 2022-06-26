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
                    player1.PrintPlayer();
                    break;
                case 2:
                    Fight(player1, monsters1);
                    break;
            }
        }

        static void Fight(Player player1, Monsters monsters1)
        {
            int attOrRun = 0;
            Monsters.GetMonster();
            Player.GetPlayer();
            while (monsters1.isAlive())
            {
                if (player1.isAlive())
                {
                    player1.Attack(player1, monsters1);
                    Monsters.GetMonster();
                    monsters1.Attack(player1, monsters1);
                    Player.GetPlayer();
                    Console.WriteLine("attack or run away 1-attack, 2-run away");
                    switch (attOrRun)
                    {
                        case 1:
                            break;
                        case 2:
                            Monsters.GetMonster();
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Game Over!!!!!((((");
                }
            }
        }




        static void Main(string[] args)
        {
            Player player2=Player.GetPlayer();
            Monsters monsters2 = Monsters.GetMonster();
            PrintMenu();
            input(player2,monsters2);
            

        }
    }
}
