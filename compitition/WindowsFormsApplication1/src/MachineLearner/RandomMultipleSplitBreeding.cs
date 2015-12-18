///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

namespace WindowsFormsApplication1.src.MachineLearner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.Entities;
    using WindowsFormsApplication1.src.Interfaces;

    /// <summary>
    /// Implementation of a genetic breeding algorithm splitting the chromosomes at random locations.
    /// </summary>
    public class RandomMultipleSplitBreeding : IGeneticBreeding
    {
        /// <summary>
        /// Probability for breeding the chromosomes based on fitness.
        /// </summary>
        private double[] probability;

        /// <summary>
        /// A random number generator.
        /// </summary>
        private Random rand = new Random();

        TradeSystemChromosome[] newChromosomes;

        /// <summary>
        /// Returns a new population based on the breeding algorithm.
        /// </summary>
        /// <param name="oldChromosomes">The chromosomes of a population.</param>
        /// <returns>A new population.</returns>
        public TradeSystemChromosome[] Breed(TradeSystemChromosome[] oldChromosomes)
        {
            newChromosomes = new TradeSystemChromosome[oldChromosomes.Length];
            for (int i = 0; i < oldChromosomes.Length; i++)
            {
                newChromosomes[i] = oldChromosomes[i];
            }
            for (int i = 2; i < oldChromosomes.Length; )
            {
                CrossBuyTradeConditions(newChromosomes[i], newChromosomes[i+1]);
                
                i += 2;
            }

            return newChromosomes;
        }

        /// <summary>
        /// Cross the buy trade conditions.
        /// </summary>
        /// <param name="chromosome1">First chromosome to cross.</param>
        /// <param name="chromosome2">Second chromosome to cross.</param>
        private void CrossBuyTradeConditions(TradeSystemChromosome chromosome1, TradeSystemChromosome chromosome2)
        {
            int c1 = GetRandomPosition(chromosome1.ChromosomeValue.BuyCondition.TradeRules.Count);
            int c2 = GetRandomPosition(chromosome2.ChromosomeValue.BuyCondition.TradeRules.Count);
            TradeRule c1tr = chromosome1.ChromosomeValue.BuyCondition.TradeRules[c1];
            TradeRule c2tr = chromosome2.ChromosomeValue.BuyCondition.TradeRules[c2];
            chromosome1.ChromosomeValue.BuyCondition.TradeRules[c1] = c2tr;
            chromosome2.ChromosomeValue.BuyCondition.TradeRules[c2] = c1tr;
            
        }

        /// <summary>
        /// Gets the split locations based on 
        /// </summary>
        /// <param name="numSplits">The number of splits locations.</param>
        /// <param name="length">The length of the chromosomes.</param>
        /// <returns>An array of split locations.</returns>
        private int[] GetSplitLocations(int numSplits, int length)
        {
            int[] splitLocations = new int[numSplits];
            /// *********************************************
            /// GDBCup - Code goes here
            /// *********************************************

            return splitLocations;
        }

        /// <summary>
        /// Cross the sell trade conditions.
        /// </summary>
        /// <param name="chromosome1">First chromosome to cross.</param>
        /// <param name="chromosome2">Second chromosome to cross.</param>
        

        /// <summary>
        /// Gets a position at random based on the probability.
        /// </summary>
        /// <returns>The position to reference.</returns>
        private int GetRandomPosition(int chromSize)
        {
            int position = 0;
            position = rand.Next(chromSize);

            return position;
        }
    }
}
