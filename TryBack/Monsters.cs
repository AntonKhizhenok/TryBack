using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryBack
{
    class Monsters : Creature
    {
        public string name { get; set; }
        public string typeMonster { get; set; }
        protected override int randDamage { get; set; }
        public override int currentHealth { get; set; }
        public override int minDamage { get; set; }
        public override int maxDamage{ get; set; }
        public override int fullHealth { get; set; }
        protected override int lvl { get; set; }
        public int experience { get; set; }
        public string rarityMonster { get; set; }

        enum TypeMonsters
        {
            Beer,
            Spider,
            Snake
        }
        enum RarityMonster
        {
            Common,
            Uncommon,
            Rare,
            Epic,
            Legendary,
            Mythic
        }

        public Monsters(string name, string _TypeMonsters,string lvl,string minDamage,string maxDamage,string currentHealth,string _rarityMonster,string experience)
        {
            this.name=name;
            typeMonster=Enum.GetName(typeof(TypeMonsters), int.Parse(_TypeMonsters));
            this.lvl = int.Parse(lvl);
            this.minDamage = int.Parse(minDamage);
            this.maxDamage = int.Parse(maxDamage);
            this.currentHealth = int.Parse(currentHealth);
            fullHealth = int.Parse(currentHealth);
            rarityMonster= Enum.GetName(typeof(RarityMonster), int.Parse(_rarityMonster));
            this.experience = int.Parse(experience);
        }

        public void SpawnMonster()
        {

        }

        public  void expLvlUp(Monsters monsters)
        {
            monsters.experience = monsters.experience * monsters.lvl;
        }

        public void PrintMonster()
        {
            Console.Write("You have encountered ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.Write($"({typeMonster},lvl.{lvl}, dmg.{minDamage}-{maxDamage}, hp {currentHealth}, rarityMonster:");
            if (rarityMonster=="Common")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"rarityMonster: {rarityMonster})");
                Console.ResetColor();
            }
            else if(rarityMonster=="Uncommon")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{rarityMonster}");
                Console.ResetColor();
                Console.WriteLine(")");
            }
            else if (rarityMonster == "Rare")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{rarityMonster}");
                Console.ResetColor();
                Console.WriteLine(")");
            }
            else if (rarityMonster == "Epic")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{rarityMonster}");
                Console.ResetColor();
                Console.WriteLine(")");
            }
            else if (rarityMonster == "Legendary")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{rarityMonster}");
                Console.ResetColor();
                Console.WriteLine(")");
            }
            else if (rarityMonster == "Mithic")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{rarityMonster}");
                Console.ResetColor();
                Console.WriteLine(")");
            }
            Console.WriteLine();
        }

        public void InfoFightMonster(Player player)
        {
            if (player.currentHealth >= 0)
            {
                Console.Write($"{name} hit You for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{randDamage} damage");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write($"{player.name} ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"hp:{player.currentHealth}/{player.fullHealth}");
                Console.ResetColor();
            }
            else if (player.currentHealth<0)
            {
                Console.Write($"{name} hit You for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{randDamage} damage");
                Console.ResetColor();
            }
            Console.WriteLine();
        }


        public override void Attack(Player player, Monsters monsters)
        {
            randDamage = MathUtils.GetRandomDamage(minDamage, maxDamage);
            player.currentHealth -= randDamage;
            Console.WriteLine();
        }

        public void Evasion(Player player1, Monsters monsters1)
        {
            int randEvasion = MathUtils.GetRandomNumber(101);
            if (randEvasion > player1.evasion)
            {
                monsters1.Attack(player1, monsters1);
            }
            else if (randEvasion <= player1.evasion)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("you dodged the monster's attack");
                Console.ResetColor();
                Console.WriteLine();
                monsters1.randDamage = 0;
            }
        }

        public static void PrintTxt()
        {
            String line;
            StreamReader arrMonster = new StreamReader("D:\\Monster.txt");
            line = arrMonster.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = arrMonster.ReadLine();
            }
            arrMonster.Close();
            
        }
        public static Monsters GetMonster()//созднаие монстра
        {
            string[] monsters = File.ReadAllLines(@"D:\Monster.txt");
            int numberOfLines = monsters.Length;
            int randNumber=MathUtils.GetRandomNumber(numberOfLines);
            string strMonster = monsters[randNumber];
            string[] monsterProperties = strMonster.Split(';');
            Monsters monstersObj= new Monsters(monsterProperties[0],monsterProperties[1],monsterProperties[2],monsterProperties[3], monsterProperties[4], monsterProperties[5], monsterProperties[6], monsterProperties[7]);
            return  monstersObj;
        }
    }
    }
