namespace WindowsFormsApplication1.src.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.MachineLearner;

    /// <summary>
    /// An interface for an implementation of a fitness algorithm.
    /// </summary>
    public interface IGeneticFitness
    {
        /// <summary>
        /// Sets the fitness of each chromosome.
        /// </summary>
        /// <param name="chromosomeList">The chromosomes of a population.</param>
        void SetFitness(TradeSystemChromosome[] chromosomeList);

        Dictionary<string, double> getFitness();
    }
}
