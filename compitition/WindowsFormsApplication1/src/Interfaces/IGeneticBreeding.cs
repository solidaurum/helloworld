﻿namespace WindowsFormsApplication1.src.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.MachineLearner;

    /// <summary>
    /// An interface for an implementation of a breeding algorithm.
    /// </summary>
    public interface IGeneticBreeding
    {
        /// <summary>
        /// Returns a new population based on the breeding algorithm.
        /// </summary>
        /// <param name="chromosomeList">The chromosomes of a population.</param>
        /// <returns>A new population.</returns>
        TradeSystemChromosome[] Breed(TradeSystemChromosome[] chromosomeList);
    }
}
