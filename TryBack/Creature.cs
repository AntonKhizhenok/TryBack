using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBack
{
    abstract class Creature
    {
        
        protected abstract int damage { get; set;}
        protected abstract int healtPoint { get; set; }
        public abstract void Attack(Player player,Monsters monsters);
        public bool isAlive()
        {
                return healtPoint <= 0;
        }
        
        
        
    }
}
