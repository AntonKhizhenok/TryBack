﻿using System;
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
        public string typeMonster { get; set; }
        protected override int damage { get; set; }
        protected override int randDamage { get; set; }
        public override int healtPoint { get; set; }
        public override int minDamage { get; set; }
        public override int maxDamage{ get; set; }
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

        }
        public void PrintMonster()
        {
            Console.WriteLine();
            Console.WriteLine("\t\tINFO OF MONSTER");
            Console.WriteLine($"{name}\t {typeMonster}\t\t\tDamage:{MinDamage()}-{MaxDamage()}\t\tHP:{healtPoint}");
            Console.WriteLine();
            randDamage = damage;
        }
        public override int MinDamage()
        {
            return MathUtils.MinDamage(damage, 5);
        }
        public override int MaxDamage()
        {
            return MathUtils.MaxDamage(damage, 5);
        }

        public void InfoFightMonster(Player player)
        {
            Console.WriteLine($"{typeMonster} hit the {player.name} for {randDamage} damage");
            Console.WriteLine();
            Console.WriteLine($"{player.name} hp:{player.healtPoint}");
        }


        public override void Attack(Player player, Monsters monsters)
        {
            minDamage = MathUtils.MinDamage(damage, 3);
            maxDamage = MathUtils.MaxDamage(damage, 3);
            randDamage=MathUtils.GetRandomDamage(damage, 3);
            player.healtPoint -= randDamage;
            Console.WriteLine();
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
            
        }
        public static Monsters GetMonster()
        {
            string[] monsters = File.ReadAllLines(@"D:\Test.txt");
            int numberOfLines = monsters.Length;
            int randNumber=MathUtils.GetRandomNumber(numberOfLines);
            string strMonster = monsters[randNumber];
            string[] monsterProperties = strMonster.Split(';');
            Monsters monstersObj= new Monsters(monsterProperties[0],monsterProperties[1],monsterProperties[2],monsterProperties[3]);
            return  monstersObj;
        }
    }
    }
