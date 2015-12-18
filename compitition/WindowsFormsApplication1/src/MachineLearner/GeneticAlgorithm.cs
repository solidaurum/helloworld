///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

namespace WindowsFormsApplication1.src.MachineLearner
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.Entities;
    using WindowsFormsApplication1.src.Interfaces;

    /// <summary>
    /// Genetic Algorithm class
    /// </summary>
    public class GeneticAlgorithm
    {
        /// <summary>
        /// Number of generations to run.
        /// </summary>
        private int generations;

        /// <summary>
        /// The chromosomes making up the population.
        /// </summary>
        private TradeSystemChromosome[] chromosomes;

        /// <summary>
        /// The best chromosome
        /// </summary>
        private TradeSystemChromosome bestChromosome = null;
        
        /// <summary>
        /// The algorithm to breed with.
        /// </summary>
        private IGeneticBreeding breedingAlgorithm;

        /// <summary>
        /// The algorithm to mutuate with.
        /// </summary>
        private IGeneticMutating mutatingAlgorithm;

        /// <summary>
        /// The algorithm to set fitness with.
        /// </summary>
        private IGeneticFitness fitnessAlgorithm;

        /// <summary>
        /// The number of seeded chromosomes.
        /// </summary>
        private int seeded = 0;

        /// <summary>
        /// The progress of the genetic algorithm.
        /// </summary>
        private double progress;

        /// <summary>
        /// Initializes a new instance of the GeneticAlgorithm class.
        /// </summary>
        /// <param name="chromosomes">The number of chromosomes in the population.</param>
        /// <param name="generations">The number of generations to run.</param>
        /// <param name="chromosomeSize">The size of the chromosomes.</param>
        /// <param name="tradeSystemTemplate">A template to make TradeSystemChromosomes with</param>
        /// <param name="indicatorHelper">The indicator helper for generating new chromosomes.</param>
        /// <param name="breedingAlgorithm">The algorithm to breed with.</param>
        /// <param name="mutatingAlgorithm">The algorithm to mutate with.</param>
        /// <param name="fitnessAlgorithm">The algorithm to calculate fitness.</param>
        public GeneticAlgorithm(int chromosomes, int generations, int chromosomeSize, TradeSystem tradeSystemTemplate, IndicatorHelper indicatorHelper, IGeneticBreeding breedingAlgorithm, IGeneticMutating mutatingAlgorithm, IGeneticFitness fitnessAlgorithm)
        {
            this.chromosomes = new TradeSystemChromosome[chromosomes];
            for (int i = 0; i < chromosomes; i++)
            {
                TradeSystemChromosome newchromosome = new TradeSystemChromosome(tradeSystemTemplate, indicatorHelper, chromosomeSize);
                this.chromosomes[i] = newchromosome;
            }
            this.generations = generations;
            this.breedingAlgorithm = breedingAlgorithm;
            this.fitnessAlgorithm = fitnessAlgorithm;
            this.mutatingAlgorithm = mutatingAlgorithm;
            GeneratePopulation();
        }

        /// <summary>
        /// Gets or sets the current best chromosome
        /// </summary>
        public TradeSystemChromosome BestChromosome
        {
            get
            {
                return this.bestChromosome;
            }
        }
        
        /// <summary>
        /// Run the genetic algorithm.
        /// </summary>
        /// <param name="worker">The background worker object.</param>
        /// <param name="e">Do work event args.</param>
        public void Run(BackgroundWorker worker, DoWorkEventArgs e)
        {
                fitnessAlgorithm.SetFitness(chromosomes);
                Dictionary<string, double> fitnessResult = fitnessAlgorithm.getFitness();
                IEnumerable<KeyValuePair<string, double>> temp = fitnessResult.OrderByDescending(d => d.Value);
                chromosomes = chromosomes.OrderByDescending(d => d.Capital).ToArray();
                bestChromosome = DeepCopy.getDeepCopy( chromosomes[0]);
                chromosomes = breedingAlgorithm.Breed(chromosomes);
                mutatingAlgorithm.Mutate(ref chromosomes);
                for (int j = 0; j < chromosomes.Count(); j++)
                {
                    chromosomes[j].newID();
                }
                
            
        }


        /// <summary>
        /// Gets the chromosome with the besst fitness.
        /// </summary>
        /// <returns>The most fit chromosome.</returns>
        private TradeSystemChromosome GetBest()
        {
            return this.chromosomes.OrderByDescending(x => x.Fitness).First();
        }

        /// <summary>
        /// Generate a random population.
        /// </summary>
        private void GeneratePopulation()
        {
            for (int i = 0; i < chromosomes.Count(); i++ )
            {
               chromosomes[i].Randomize();
               //chromosomes[i] = chromosomes[i].Clone();
            }
        }

        
    }
}
