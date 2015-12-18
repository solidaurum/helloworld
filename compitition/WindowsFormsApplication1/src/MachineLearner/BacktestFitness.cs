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
    using System.Threading;
    using WindowsFormsApplication1.src.Entities;
    using WindowsFormsApplication1.src.Interfaces;
    using WindowsFormsApplication1.src.Library;
    using WindowsFormsApplication1.src;


    /// <summary>
    /// Implementation of a fitness algorithm using backtest results.
    /// </summary>
    public class BacktestFitness : IGeneticFitness
    {
        /// <summary>
        /// The indicator library adapter to run the backtest with.
        /// </summary>
        private TestData indicatorLibraryAdapter;

        private Dictionary<DateTime, Dictionary<string, double>> ILA = new Dictionary<DateTime, Dictionary<string, double>>();
        ///<summary>
        ///The list of chomosomes with fitness value
        ///</summary>
        private Dictionary<string, double> fitnessValue = new Dictionary<string, double>();
        private List<DateTime> error;
        private FitnessTest fit;
        /// <summary>
        /// Initializes a new instance of the BacktestFitness class.
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The indicator library adapter to run the backtest with.</param>
        public BacktestFitness(TestData indicatorLibraryAdapter, Dictionary<DateTime, Dictionary<string, double>> ILA, List<DateTime> error, FitnessTest fitTest)
        {
            this.indicatorLibraryAdapter = indicatorLibraryAdapter;
            this.ILA = ILA;
            this.error = error;
            this.fit = fitTest;
        }
        public Dictionary<string, double> getFitness()
        {
            return fitnessValue;
        }
        /// <summary>
        /// Sets the fitness of each chromosome based on backtest results.
        /// </summary>
        /// <param name="chromosomeList">Array of chromosomes to backtest.</param>
        public void SetFitness(TradeSystemChromosome[] chromosomeList)
        {
            fitnessValue.Clear();
            foreach (TradeSystemChromosome c in chromosomeList)
            {
                TradeHelper th = new TradeHelper(c.ChromosomeValue);
                th.RunBacktest(indicatorLibraryAdapter, ILA);
                fit.getFitnessTest(this.error, th.occuranceCount);
                double percent = fit.getResults();
                if (!fitnessValue.ContainsKey(c.getUniqueID()))
                {
                    fitnessValue.Add(c.getUniqueID(), percent);
                }
            }
            
        }
        
    }
}
