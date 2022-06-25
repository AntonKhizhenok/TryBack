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
        private string name;
        private string typeMonster;
        enum TypeMonsters
        {
            Beer,
            Spider,
            Snake
        }
        protected override int damage { get; set; }
        protected override int healtPoint { get; set ; }
        
        public Monsters(string name, string _TypeMonsters,string damage,string healtPoint)
        {
            this.name=name;
            typeMonster=Enum.GetName(typeof(TypeMonsters), int.Parse(_TypeMonsters));
            this.damage = int.Parse(damage);
            this.healtPoint =int.Parse(healtPoint);
        }

        public override void Attack(Player player, Monsters monsters)
        {
            player.healtPoint -= monsters.damage;
        }

        public static void PrintTxt()
        {
            
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader arrMonster = new StreamReader("D:\\Test.txt");
                //Read the first line of text
                line = arrMonster.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = arrMonster.ReadLine();
                }
                //close the file
                arrMonster.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
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
