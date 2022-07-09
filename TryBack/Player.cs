using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryBack
{
    class Player : Creature
    {
        public string name { get; set; }
        private string typePlayer { get; set; }
        protected override int lvl { get; set; } 
        protected override int randDamage { get; set; }
        public override int currentHealth { get; set; }
        public override int minDamage { get; set; } 
        public override int maxDamage { get; set; }
        public override int fullHealth { get; set; }

        public Player(string name,string lvl,string typePlayer,string minDamage,string maxDamage,string currentHealth)
        {
            this.name = name;
            this.typePlayer = typePlayer;
            this.lvl = int.Parse(lvl);
            this.minDamage = int.Parse(minDamage);
            this.maxDamage = int.Parse(maxDamage);
            this.currentHealth = int.Parse(currentHealth);
            fullHealth = int.Parse(currentHealth);
        }


        public static Player CreatePlayer()
        {
            Console.WriteLine("Enter player name");
            string playerName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Select player class 1,2,3");
            string[] playerClass = File.ReadAllLines(@"D:\PlayerClass.txt");
            int select = int.Parse(Console.ReadLine());
            string[] playerProperties = playerClass[select - 1].Split(';');
            Player playerObj = new Player(playerName,playerProperties[0], playerProperties[1], playerProperties[2], playerProperties[3],playerProperties[4]);
            return playerObj;
        }
        public void WriteInfoPlayer()
        {
            StreamWriter sw = new StreamWriter("D:\\Player.txt");
            sw.WriteLine($"{name}\t{typePlayer}\tlvl.{lvl}\t\tDamage:{minDamage}-{maxDamage}\t\tHP:{currentHealth}");
            sw.Close();
        }

        public void PrintInfoPlayer()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write($"{name}\t{typePlayer}\tlvl.{lvl}\t\tDamage:{minDamage}-{maxDamage}\t\tHP:{currentHealth}");
            Console.WriteLine();

        }
        public void InfoFightPlayer(Monsters monsters)
        {
            Console.Write($"You hit the {monsters.typeMonster} for ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{randDamage} damage");
            Console.ResetColor();
            Console.WriteLine();
            Console.Write($"{monsters.name}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" hp:{ monsters.currentHealth}/{fullHealth}");
            Console.ResetColor();
            Console.WriteLine();
        }


        public override void Attack(Player player, Monsters monsters)
        {
            randDamage = MathUtils.GetRandomDamage(minDamage, maxDamage); 
            monsters.currentHealth -= randDamage;
            
        }

        public static void InfoPlayer()
        {
            String line;
                StreamReader arrPlayer = new StreamReader("D:\\Player.txt");
                line = arrPlayer.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = arrPlayer.ReadLine();
                }
                arrPlayer.Close();
        }



    }
}

