namespace WindowsFormsApplication1.src.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.MachineLearner;

    /// <summary>
    /// An interface for an implementation of a mutating algorithm.
    /// </summary>
    public interface IGeneticMutating
    {
        /// <summary>
        /// Returns a new population based on the mutating algorithm.
        /// </summary>
        /// <param name="chromosomeList">The chromosomes of a population.</param>
        void Mutate(ref TradeSystemChromosome[] chromosomeList);
    }
}
