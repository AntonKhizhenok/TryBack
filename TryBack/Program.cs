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


        static void input(Player player,Monsters monsters)
        {
            int inputMenu = int.Parse(Console.ReadLine());
            switch (inputMenu)
            {
                case 1:

                    Player.GetInfoPlayer();
                    break;
                case 2:
                    Fight(player, monsters);
                    break;
            }
        }

        static void Fight(Player player, Monsters monsters)
        {
            int attOrRun = 0;
            Monsters.GetNewMonster();
            Player.GetInfoPlayer();
            while (monsters.isAlive())
            {
                if (player.isAlive())
                {
                    player.Attack(player, monsters);
                    Monsters.GetNewMonster();
                    monsters.Attack(player, monsters);
                    Player.GetInfoPlayer();
                    Console.WriteLine("attack or run away 1-attack, 2-run away");
                    switch (attOrRun)
                    {
                        case 1:
                            break;
                        case 2:
                            Monsters.GetNewMonster();
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

            
            PrintMenu();
            //input();
            

        }
    }
}
