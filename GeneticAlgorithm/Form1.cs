using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace GeneticAlgorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Chromosome c1 = new Chromosome();
            List<Chromosome> population = new List<Chromosome>();
            int totalPop = Convert.ToInt32(numPopulation.Value);
            population =Chromosome.CreatePop(totalPop);
            MessageBox.Show(population[1].GeneX.ToString() + "<<<<<<<<<<<" + population[1].GeneY.ToString() + "<<<<<<<<<<<<" + population[1].targetFuncRes.ToString());
            
            for (int iteration = 1; iteration <= Convert.ToInt32(numIteration.Value);iteration++)
            {
                population = Iteration(population,Convert.ToDouble(numMutation.Value),Convert.ToInt32(numPopulation.Value));
                double avgoftargetfunc = 0;
                for (int i = 0; i < population.Count; i++)
                {
                    avgoftargetfunc += population[i].targetFuncRes;
                }
                avgoftargetfunc /= population.Count;
                listBox1.Items.Add(Math.Round(avgoftargetfunc,4));
                DrawGraph(avgoftargetfunc);

            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numPopulation.Value%2==1)
            {
                numPopulation.Value += 1;
            }
        }

        private List<Chromosome> Iteration(List<Chromosome> pop,double numMut,int numPop)
        {
            int numpophalf = numPop / 2;
            while ( pop.Count > numpophalf)
            {
                pop = Selection.Tournament(pop);
            }
            pop= Heredity.HeredityFunc(pop, numMut);
            return pop;
        }
        private void DrawGraph(double avg)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Legends.Clear();
            try
            {
                Series average = chart1.Series.Add("Average Fitness");
                average.ChartType = SeriesChartType.Line;
                average.BorderWidth = 2;
                average.Color = Color.Red;


                Series min = chart1.Series.Add("Minimum Fitness");
                min.ChartType = SeriesChartType.Line;
                min.Color = Color.Blue;
                min.BorderWidth = 2;
            }
            catch (Exception)
            { }
            this.chart1.Series["Average Fitness"].Points.Add(avg);
            this.chart1.Series["Minimum Fitness"].Points.Add(0);
        }
    }
}