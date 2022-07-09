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
       
        static void Main(string[] args)
        {
            Console.WriteLine("new game or continue current game? 1,2");
            int newOrCont = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (newOrCont)
            {
                case 1:
                    Game.Start();
                    break;
                case 2:
                    Game.Continue();
                    break;
            }
        }
    }
}
