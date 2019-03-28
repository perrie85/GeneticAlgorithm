using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorithm
{
    class Chromosome
    {
        private double geneX, geneY;
        public double targetFuncRes;
        //this constructor is for generating the first population
        public Chromosome()
        {
            Random generator = new Random();
            geneX = Math.Round((generator.NextDouble() * 20)-10, 4);
            geneY = Math.Round((generator.NextDouble() * 20) - 10, 4);
                
            targetFuncRes = Math.Round((0.26 * (Math.Pow(geneX, 2) + Math.Pow(geneY, 2)) - 0.48 * geneX * geneY),4);
        }
        // this constructor is for generating the child population
        // as it takes the values from the heredity class
        public Chromosome(double geneX, double geneY)
        {
            this.geneX = geneX;
            this.geneY = geneY;
            targetFuncRes = Math.Round((0.26 * (Math.Pow(geneX, 2) + Math.Pow(geneY, 2)) - 0.48 * geneX * geneY), 4);
        }

        public double GeneX { get => geneX; set => geneX = value; }
        public double GeneY { get => geneY; set => geneY = value; }


        public static List<Chromosome> CreatePop(int totalPop)
        {
            //Chromosome[] popArray = new Chromosome[totalPop];
            List<Chromosome> pop = new List<Chromosome>();
            //Starts at 0 as its an array
            for (int i = 0; i < totalPop; i++)
            {
                //popArray[i]= new Chromosome();
                Chromosome tba = new Chromosome();
                pop.Add(tba);
            }
            /*foreach (var item in popArray)
            {
                pop.Add(item);
            }*/
            return pop;
        }
    }
}
