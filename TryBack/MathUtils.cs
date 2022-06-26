using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBack
{
    class MathUtils
    {
        public static int GetRandomNumber(int n)
        {
            Random random = new Random();
            return random.Next(0, n);
        }
        public static int GetRandomDamage(int damage,int value)
        {
            Random randomDamage = new Random();
            return randomDamage.Next(damage - value, damage + value);
        }
    }
}
