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
        private int damage1;
        private int healtPoint1;
        enum TypeMonsters
        {
            Beer,
            Spider,
            Snake
        }

      

        public Monsters(string Name, string _TypeMonsters,string Damage,string HealtPoint)
        {
            name=Name;
            typeMonster=Enum.GetName(typeof(TypeMonsters), int.Parse(_TypeMonsters));
           damage1 = int.Parse(Damage);
           healtPoint1 =int.Parse(HealtPoint);
          
            
        }
        Random random1 = new Random();
        public override int damage { get => damage1; set => damage = damage1; }
        public override int healtPoint { get => healtPoint; set => healtPoint = healtPoint1; }
        

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
