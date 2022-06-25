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
        private string name;
        private string typePlayer;
        private int level;
        protected override int damage { get; set; }
        public override int healtPoint { get; set; }
 
        public Player(string name,string typePlayer,string level,string damage,string healtPoint)
        {
            this.name = name;
            this.typePlayer = typePlayer;
            this.level = int.Parse(level);
            this.damage = int.Parse(damage);
            this.healtPoint=int.Parse(healtPoint);
            Console.WriteLine($"\t\t\t\tPLAYER CHARACTERISTIC");
            Console.WriteLine($"Name:{name}\tTypePlayer:{typePlayer}\tLevel:{level}\t\tDamage:{damage}\tHealtPoint:{healtPoint}");
            Console.WriteLine();
        }
        
        public override void Attack(Player player, Monsters monsters)
        {
            monsters.healtPoint -= player.damage;
        }

        public static void InfoPlayer()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader arrPlayer = new StreamReader("D:\\Player.txt");
                //Read the first line of text
                line = arrPlayer.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = arrPlayer.ReadLine();
                }
                //close the file
                arrPlayer.Close();
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
        public static void GetInfoPlayer()
        {
            string[] player = File.ReadAllLines(@"D:\Player.txt");
            int numberOfLines = player.Length - 1;
            int randNumberPlayer = MathUtils.GetRandomNumber(numberOfLines);
            string strPlayer = player[randNumberPlayer];
            string[] playerProperties = strPlayer.Split(';');
            new Player(playerProperties[0], playerProperties[1], playerProperties[2], playerProperties[3], playerProperties[4]);
            
        }

       
        
        
       

    }
}

