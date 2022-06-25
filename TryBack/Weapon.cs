using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBack
{
    abstract class Weapon : Item
    {
        protected abstract int Damage { get; }
        public string meleeWeapon;
        public string rangedWeapon;
    }
}
