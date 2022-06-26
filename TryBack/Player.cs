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
        protected override int damage { get; set; }
        public override int healtPoint { get; set; }
        public override int minDamage { get; set; }
        public override int maxDamage { get; set ; }


        public Player(string name,string typePlayer,string level,string damage,string healtPoint)
        {
            this.name = name;
            this.typePlayer = typePlayer;
            this.level = int.Parse(level);
            this.damage = int.Parse(damage);
            this.healtPoint=int.Parse(healtPoint);

        }
        public void PrintPlayer()
        {
            minDamage = MinDamage();
            maxDamage = MaxDamage();
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\t\tINFO OF PLAYER!!!");
            Console.WriteLine($"Name:{name}\tTypePlayer:{typePlayer}\tLevel:{level}\t\tBasic damage:{damage} Random Damage: {randDamage} (Min:{minDamage}-Max:{maxDamage})\t\tHealtPoint:{healtPoint}");
            Console.WriteLine();
            randDamage = damage;
        }

        public void PrintInfoPlayer()
        {
            minDamage = MinDamage();
            maxDamage = MaxDamage();
            Console.WriteLine();
            Console.WriteLine($"\t\t\t\t\t\tPLAYER CHARACTERIES!!!");
            Console.WriteLine($"Name:{name}\tTypePlayer:{typePlayer}\tLevel:{level}\t\tBasic damage:{damage} (Min:{minDamage}-Max:{maxDamage})\t\tHealtPoint:{healtPoint}");
            Console.WriteLine();
        }

        public override int MinDamage()
        {
            return MathUtils.MinDamage(damage, 5);
        }
        public override int MaxDamage()
        {
            return MathUtils.MaxDamage(damage, 5);
        }

        public override void Attack(Player player, Monsters monsters)
        {
            randDamage = MathUtils.GetRandomDamage(damage, 5);
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
            Player playerObj = new Player(playerProperties[0], playerProperties[1], playerProperties[2], playerProperties[3], playerProperties[4]);
            return playerObj;
        }
        
    }
}

