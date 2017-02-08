using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public static class RandomGenerator
    {
        public static Random GetRandom(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = string.Empty;
            int seed = int.MinValue;
            char last = '0';
            foreach (char character in name)
            {
                double add = Math.Pow(character, last) % int.MaxValue;
                seed += (int)add;
                last = character;
            }
            return new Random(seed);
        }
    }
}
