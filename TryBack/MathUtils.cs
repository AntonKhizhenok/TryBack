using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryBack
{
     class MathUtils
    {

        public static Random random = new Random();
        public static int GetRandomNumber(int n)
        {
            return random.Next(0, n);
        }
        public static int GetRandomDamage(int minDamage,int maxDamage)
        {
            return random.Next(minDamage, maxDamage+1);
        }

    }
}
