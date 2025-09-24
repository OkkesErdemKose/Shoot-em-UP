using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones
{
    internal static class RandomHelpers
    {
        public static int Rnd(int a, int b)
        {
            int result;

            Random rnd = new Random();
            result = rnd.Next(a, b);

            return result;
        }
    }
}
