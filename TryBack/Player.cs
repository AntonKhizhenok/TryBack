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
        protected override int lvl { get; set; } 
        protected override int randDamage { get; set; }
        public override int currentHealth { get; set; }
        public override int minDamage { get; set; } 
        public override int maxDamage { get; set; }
        public override int fullHealth { get; set;}
        public int chanceEscape;
        public int evasion;
        public double initialExperience { get; set; } = 0;
        public double experienceRequaired { get; set; } = 100;

        public Player(string name,string lvl,string typePlayer,string minDamage,string maxDamage,string currentHealth,string fullHealth,string chanceEscape,string evasion)
        {
            this.name = name;
            this.typePlayer = typePlayer;
            this.lvl = int.Parse(lvl);
            this.minDamage = int.Parse(minDamage);
            this.maxDamage = int.Parse(maxDamage);
            this.currentHealth = int.Parse(currentHealth);
            this.fullHealth = int.Parse(fullHealth);
            this.chanceEscape = int.Parse(chanceEscape);
            this.evasion = int.Parse(evasion);
        }
        
        public static Player CreatePlayer()
        {

            //crate name
            Console.WriteLine("Enter player name");
            string playerName = Console.ReadLine();
            Console.Clear();
            //read from file txt
            Console.WriteLine("Select player class");
            readClassPlayer();
            string[] playerClass = File.ReadAllLines(@"D:\PlayerClass.txt");
            int select = int.Parse(Console.ReadLine());
            string[] playerProperties = playerClass[select - 1].Split(';');
            Player playerObj = new Player(playerName,playerProperties[0], playerProperties[1], playerProperties[2], playerProperties[3],playerProperties[4], playerProperties[5], playerProperties[6], playerProperties[7]);
            return playerObj;
        }

        public static void readClassPlayer()
        {
            string[] playerClass1 = File.ReadAllLines(@"D:\PlayerClass.txt");
            for (int i = 0; i < playerClass1.Length; i++)
            {
                string[]PlayerProp=playerClass1[i].Split(';');
                Console.WriteLine($"{i+1}) {PlayerProp[1]}"); 
            }

        }

        public void WriteInfoPlayer()
        {
            StreamWriter writePlayer = new StreamWriter("D:\\Player.txt");
            writePlayer.WriteLine($"{name};{lvl};{typePlayer};{minDamage};{maxDamage};{currentHealth};{fullHealth};{chanceEscape};{evasion}");
            writePlayer.Close();
        }

        public static Player ReadDataPlayer()
        {
            string[] playerClass = File.ReadAllLines(@"D:\Player.txt");
            string[] playerProperties = playerClass[0].Split(';');
            Player readPlayer = new Player(playerProperties[0], playerProperties[1], playerProperties[2], playerProperties[3], playerProperties[4], playerProperties[5], playerProperties[6], playerProperties[7], playerProperties[8]);
            return readPlayer;
        }

        public void PrintInfoPlayer(Player player)
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write($"{name}\t{typePlayer}\tlvl.{lvl}\tDamage:{minDamage}-{maxDamage}\tHP:{player.fullHealth}\tescape chance:{chanceEscape}%\tevasion:{evasion}%\texpirience:{initialExperience}/{experienceRequaired}");
            Console.WriteLine();

        }
        public void InfoFightPlayer(Monsters monsters)
        {
            if (monsters.currentHealth >= 0)
            {
                Console.Write($"You hit the {monsters.name} for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{randDamage} damage");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write($"{monsters.name}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" hp:{ monsters.currentHealth}/{monsters.fullHealth}");
                Console.ResetColor();
            }
            else if (monsters.currentHealth<0)
            {
                Console.Write($"You hit the {monsters.name} for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{randDamage} damage");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        
        public override void Attack(Player player, Monsters monsters)
        {
            randDamage = MathUtils.GetRandomDamage(minDamage, maxDamage); 
            monsters.currentHealth -= randDamage;
        }

        public static void DeletePlayer()
        {
            StreamWriter sr = new StreamWriter("D:\\Player.txt", false);
            sr.Close();
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

        public void Experience(Player player,Monsters monster)
        {
            monster.expLvlUp(monster);
            initialExperience += monster.experience;
            if(initialExperience>=experienceRequaired)
            {
                lvl += 1;
                experienceRequaired *= 2.5;//difference in experience between levels
                if (typePlayer=="robber")
                {
                    player.fullHealth = (int)(player.fullHealth * 1.2);
                    minDamage += 1;
                    maxDamage += 2;
                    if(chanceEscape<75)
                    chanceEscape = chanceEscape + 1;
                    evasion = evasion + 1;
                }
                if (typePlayer == "warrior")
                {
                    player.fullHealth = (int)(player.fullHealth * 1.2)+10;
                    minDamage += 1;
                    maxDamage += 1;
                }
                if(typePlayer=="shooter")
                {
                    player.fullHealth = (int)(player.fullHealth * 1.2);
                    minDamage += 2;
                    maxDamage += 3;
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Congratulations!!!You have reached level {lvl}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }



    }
}

