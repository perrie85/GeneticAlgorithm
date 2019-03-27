using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Heredity
    {   //this function makes new chromosomes from the existing ones
        public static List<Chromosome> HeredityFunc(List<Chromosome> pop,double mutVal)
        {
            List<Chromosome> popYoung = new List<Chromosome>();
            Random s1 = new Random();
            while (popYoung.Count < pop.Count)
            {
                int popc = pop.Count;
                int parent1 = s1.Next(0, popc);
                int parent2 = s1.Next(0, popc);
                while (parent1 == parent2)
                    parent1 = s1.Next(0, pop.Count);
                double herVal = Math.Round(s1.NextDouble(), 4);
                //Heredity functions for x and y genes
                double geneX = herVal * pop[parent1].GeneX + (1 - herVal) * pop[parent2].GeneX;
                double geneY = (1 - herVal) * pop[parent1].GeneY + herVal * pop[parent2].GeneY;
                Chromosome chroNew = new Chromosome(geneX, geneY);
                chroNew = Mutation.MutationFunc(chroNew,mutVal);
                popYoung.Add(chroNew);
            }
            //merges young and old population as it will continue from the better ones
            List<Chromosome> popAll = new List<Chromosome>();
            for (int i = 0; i < pop.Count; i++)
            {
                popAll.Add(pop[i]);
                popAll.Add(popYoung[i]);
            }

            return popAll;
        }
    }
}
