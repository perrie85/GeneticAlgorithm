using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Selection
    {
        public static List<Chromosome> Tournament(List<Chromosome> pop)
        {
            Random s1 = new Random();
            int contender1 = s1.Next(0, pop.Count );
            int contender2 = s1.Next(0, pop.Count );
            while (contender1 == contender2)
            {
                contender1 = s1.Next(0, pop.Count);
            }
            if (pop[contender1].targetFuncRes< pop[contender2].targetFuncRes)
            {
                pop.RemoveAt(contender2);
            }
            else if (pop[contender1].targetFuncRes > pop[contender2].targetFuncRes)
            {
                pop.RemoveAt(contender1);
            }
            return pop;
        }
    }
}
