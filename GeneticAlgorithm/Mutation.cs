using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Mutation
    {
        public static Chromosome MutationFunc(Chromosome newBorn,double mutVal)
        {
            Random newBornMutVal = new Random();
            if (mutVal>newBornMutVal.NextDouble())
            {
                if (newBornMutVal.Next(0,1)==0)
                {
                    if (newBornMutVal.Next(0, 1) == 0)
                    {
                        newBorn.GeneX += newBornMutVal.NextDouble();
                    }
                    else
                    {
                        newBorn.GeneX -= newBornMutVal.NextDouble();
                    }
                }
                else
                {
                    if (newBornMutVal.Next(0, 1) == 0)
                    {
                        newBorn.GeneY += newBornMutVal.NextDouble();
                    }
                    else
                    {
                        newBorn.GeneY -= newBornMutVal.NextDouble();
                    }
                }
            }
            else
            {

            }

            return newBorn;
        }
    }
}
