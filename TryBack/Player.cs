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
        enum classPlayer
        {
            archer=1,
            sniper,
            swordsman
        }

        public Player(string name,string typePlayer,string level,string damage,string healtPoint)
        {
            this.name = name;
            this.typePlayer = typePlayer;
            this.level = int.Parse(level);
            this.damage = int.Parse(damage);
            this.healtPoint=int.Parse(healtPoint);

        }
        public void CreatePlater()
        {
            Console.WriteLine("Enter name player!!!");
            name = Console.ReadLine();
            Console.Clear();
        }
        public void classPlayer1()
        {
            Console.WriteLine("Select player class (1,2,3)");
            Console.WriteLine();
           string[]massClassPlayer=Enum.GetNames(typeof(classPlayer));
            foreach (string item in massClassPlayer)
            {
                Console.WriteLine(item);
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
        public void PrintPlayer()
        {
            Console.WriteLine();
            Console.WriteLine($"\t\tINFO OF PLAYER!!!");
            Console.WriteLine($"{name}\t{typePlayer}\tlvl.{level}\t\tDamage: {randDamage}\t\t HP:{healtPoint}");
            Console.WriteLine();
            randDamage = damage;
        }

        public void PrintInfoPlayer()
        {
            minDamage = MinDamage();
            maxDamage = MaxDamage();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"PLAYER CHARACTERIES!!!");
            Console.WriteLine();
            Console.Write($"{name}\t{typePlayer}\tlvl.{level}\t\tBasic damage:{damage} (Min:{minDamage}-Max:{maxDamage})\t\tHP:{healtPoint}");
            Console.WriteLine();
            Console.ReadLine();
        }
        public void InfoFightPlayer(Monsters monsters)
        {
            Console.WriteLine($"You hit the {monsters.typeMonster} for {randDamage} damage");
            Console.WriteLine($"{monsters.typeMonster} hp:{monsters.healtPoint}");
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

