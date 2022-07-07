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
        private int level { get; set; }
        protected override int randDamage { get; set; }
        public override int healtPoint { get; set; }
        public override int minDamage { get; set; } 
        public override int maxDamage { get; set; } 
        enum classPlayer
        {
            archer=1,
            sniper,
            swordsman
        }

        public Player(string name,string typePlayer,string level,string minDamage,string maxDamage,string healtPoint)
        {
            this.name = name;
            this.typePlayer = typePlayer;
            this.level = int.Parse(level);
            this.minDamage = int.Parse(minDamage);
            this.maxDamage = int.Parse(maxDamage);
            this.healtPoint=int.Parse(healtPoint);

        }
        public void CreatePlater()
        {
            Console.WriteLine("Enter player name");
            name = Console.ReadLine();
            Console.Clear();
        }
        public void classPlayer1()
        {
            Console.WriteLine("Select player class ");
            Console.WriteLine();
           string[]massClassPlayer=Enum.GetNames(typeof(classPlayer));

                for (int i = 0; i < massClassPlayer.Length; i++)
                {
                    Console.WriteLine($"{i+1}) {massClassPlayer[i]}");
                }
                
            
            int select = int.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    typePlayer = Enum.GetName(typeof(classPlayer), 1);
                    break;
                case 2:
                    typePlayer = Enum.GetName(typeof(classPlayer),2);
                    break;
                case 3:
                    typePlayer = Enum.GetName(typeof(classPlayer),3);
                    break;
            }


        }

        public void PrintInfoPlayer()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write($"{name}\t{typePlayer}\tlvl.{level}\t\tDamage:{minDamage}-{maxDamage}\t\tHP:{healtPoint}");
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
            Console.WriteLine($" hp:{ monsters.healtPoint}");
            Console.ResetColor();
            Console.WriteLine();
        }


        public override void Attack(Player player, Monsters monsters)
        {
            randDamage = MathUtils.GetRandomDamage(minDamage, maxDamage); 
            monsters.healtPoint -= randDamage;
            
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
        public static Player GetPlayer()
        {
            string[] player = File.ReadAllLines(@"D:\Player.txt");
            int numberOfLines = player.Length;
            int randNumberPlayer = MathUtils.GetRandomNumber(numberOfLines);
            string strPlayer = player[randNumberPlayer];
            string[] playerProperties = strPlayer.Split(';');
            Player playerObj = new Player(playerProperties[0], playerProperties[1], playerProperties[2], playerProperties[3], playerProperties[4], playerProperties[5]);
            return playerObj;
        }
        
    }
}

