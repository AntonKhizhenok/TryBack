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
        private string name { get; set; }
        private string typeMonster{ get; set; }
        protected override int damage { get; set; }
        public override int healtPoint { get; set; }

        enum TypeMonsters
        {
            Beer,
            Spider,
            Snake
        }

        public Monsters(string name, string _TypeMonsters,string damage,string healtPoint)
        {
            this.name=name;
            typeMonster=Enum.GetName(typeof(TypeMonsters), int.Parse(_TypeMonsters));
            this.damage = int.Parse(damage);
            this.healtPoint =int.Parse(healtPoint);
            Console.WriteLine("\t\t\tINFO OF RANDOM MONSTER");
            Console.WriteLine($"Name:{name}\tTypeMonster:{typeMonster}\tDamage:{damage}\tHealtPoint:{healtPoint}");
            Console.WriteLine();
        }


        public override void Attack(Player player, Monsters monsters)
        {
            player.healtPoint -= monsters.damage;
        }

        public static void PrintTxt()
        {
            String line;
            StreamReader arrMonster = new StreamReader("D:\\Test.txt");
            line = arrMonster.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = arrMonster.ReadLine();
            }
            arrMonster.Close();
            //Console.ReadLine();
            
        }
        public static void GetNewMonster()
        {
            string[] monsters = File.ReadAllLines(@"D:\Test.txt");
            int numberOfLines = monsters.Length-1;
            int randNumber=MathUtils.GetRandomNumber(numberOfLines);
            string strMonster = monsters[randNumber];
            string[] monsterProperties = strMonster.Split(';');
            new Monsters(monsterProperties[0],monsterProperties[1],monsterProperties[2],monsterProperties[3]);
        }
    }
    }
