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

        enum TypeMonsters
        {
            Beer,
            Spider,
            Snake
        }
        

        public Monsters(string name, string _TypeMonsters,string lvl,string minDamage,string maxDamage,string currentHealth)
        {
            this.name=name;
            typeMonster=Enum.GetName(typeof(TypeMonsters), int.Parse(_TypeMonsters));
            this.lvl = int.Parse(lvl);
            this.minDamage = int.Parse(minDamage);
            this.maxDamage = int.Parse(maxDamage);
            this.currentHealth = int.Parse(currentHealth);
            fullHealth = int.Parse(currentHealth);


        }
        public void PrintMonster()
        {
            Console.Write("You have encountered ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine($"({typeMonster},lvl.{lvl}, dmg.{minDamage}-{maxDamage}, hp {currentHealth})"); 
            Console.WriteLine();
        }

        public void InfoFightMonster(Player player)
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
            Console.WriteLine();
        }


        public override void Attack(Player player, Monsters monsters)
        {
            randDamage = MathUtils.GetRandomDamage(minDamage, maxDamage);
            player.currentHealth -= randDamage;
            Console.WriteLine();
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
            Monsters monstersObj= new Monsters(monsterProperties[0],monsterProperties[1],monsterProperties[2],monsterProperties[3], monsterProperties[4], monsterProperties[5]);
            return  monstersObj;
        }
    }
    }
