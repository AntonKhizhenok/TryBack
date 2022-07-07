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
        public abstract int healtPoint { get; set; }
        public abstract int minDamage { get; set; }
        public abstract int maxDamage { get; set; }
        public abstract void Attack(Player player, Monsters monsters);



        public bool isAlive()
        {
                return healtPoint > 0;
        }
        
        
        
    }
}
