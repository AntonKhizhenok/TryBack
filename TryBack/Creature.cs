using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBack
{
    abstract class Creature
    {
        protected abstract int randDamage { get; set; }
        public abstract int currentHealth { get; set; }
        public abstract int fullHealth { get; set; }
        public abstract int minDamage { get; set; }
        public abstract int maxDamage { get; set; }
        protected abstract int lvl { get; set; }
        public abstract void Attack(Player player, Monsters monsters);



        public bool isAlive()
        {
                return currentHealth > 0;
        }

        
        
        
    }
}
