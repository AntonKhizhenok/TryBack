using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TryBack
{
    class Player:Creature
    {
        private string Name;
        private string TypePlayer;

        Random random = new Random();
        public override int healtPoint { get => healtPoint; set => healtPoint=100; }
        public override int damage { get => damage; set => random.Next(damage, damage + 5); }

        public override void Attack(Player player, Monsters monsters)
        {
               monsters.healtPoint -= player.damage;
        }

        public void InfoPlayer()
        {
            Name = "Garford";
            TypePlayer = "Лучник";
            
        }
        private void PrintTxt()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter playerData = new StreamWriter("D:\\Test.txt");
                //Write a line of text
                playerData.WriteLine("Hello World!!");
                //Write a second line of text
                playerData.WriteLine("From the StreamWriter class");
                //Close the file
                playerData.Close();
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
        
       

    }
}

