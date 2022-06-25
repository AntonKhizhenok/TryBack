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
        
            static void PrintMenu1()
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
            PrintMenu1();
            Monsters.PrintTxt();
            Monsters.GetNewMonster();
            
        }
    }
}
