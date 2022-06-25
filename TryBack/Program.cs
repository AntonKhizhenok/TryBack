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



        static void Main(string[] args)
        {

            PrintMenu();
            Console.WriteLine();
            Player.InfoPlayer();
            Console.WriteLine();
            Player.GetInfoPlayer();
            Console.WriteLine();
            Monsters.PrintTxt();
            Console.WriteLine();
            Monsters.GetNewMonster();
           
        }
    }
}
