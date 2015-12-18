///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

namespace WindowsFormsApplication1.src.MachineLearner
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.Entities;
    using WindowsFormsApplication1.src.Entities.TradeRules;
    using WindowsFormsApplication1.src.Interfaces;

    /// <summary>
    /// A chromosome based on a trade system.
    /// </summary>
    [Serializable]
    public class TradeSystemChromosome
    {
        /// <summary>
        /// Chromosome size.
        /// </summary>
        private int size;

        /// <summary>
        /// The indicator helper for randomizing the chromosome.
        /// </summary>
        private IndicatorHelper indicatorHelper;
        public DataTable TradeTable = new DataTable();
        private String UniqueID = " ";
        /// <summary>
        /// Initializes a new instance of the TradeSystemChromosome class.
        /// </summary>
        /// <param name="tradeSystem">The trade system the chromosome represents.</param>
        /// <param name="indicatorHelper">The indicator helper for randomizing the chromosome.</param>
        /// <param name="size">Chromosome size.</param>
        public TradeSystemChromosome(TradeSystem tradeSystem, IndicatorHelper indicatorHelper, int size)
        {
            TradeSystem temp = new TradeSystem();
            temp.BuyCondition = new TradeCondition();
            this.size = size;
            this.ChromosomeValue = temp;
            this.indicatorHelper = indicatorHelper;
        }

        /// <summary>
        /// Gets or sets the trade system the chromosome represents.
        /// </summary>
        public TradeSystem ChromosomeValue
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the value of the chromosome's fitness.
        /// </summary>
        public double Fitness 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Gets or sets the ending capital balance.
        /// </summary>
        public double Capital
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the value of the fitness statistics.
        /// </summary>
        public string FitnessStats
        {
            get
            {
                string stats = "Compound Rate of Return: $" + Math.Round(Capital, 2) + " with " + FitnessWinners +
                    " winning trades and " + FitnessLosers + " losing trades. The buy and sell rules were as follows: "
                    + this.UniqueID + "\r\n";
                return stats; /// Revise once coded up
            }
        }

        /// <summary>
        /// Gets or sets a unique identifier for the chromosome.
        /// </summary>
        public string getUniqueID()
        {
            return UniqueID;
            
        }

        /// <summary>
        /// Gets or sets the fitness value for number of winning trades.
        /// </summary>
        public int FitnessWinners
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the fitness value for number of losing trades.
        /// </summary>
        public int FitnessLosers
        {
            get;
            set;
        }

        /// <summary>
        /// Randomizes the chromosome.
        /// </summary>
        public void Randomize()
        {
            TradeSystemChromosome newChrom = new TradeSystemChromosome(this.ChromosomeValue, this.indicatorHelper, size);
            int i = 1;
            Random rand = new Random();
            string indicatorbuy1 = null;
            string indicatorbuy2 = null;
            IndicatorCompareType mixbuy = new IndicatorCompareType(); 
            this.indicatorHelper.GetRandomIndicators(out indicatorbuy1, out mixbuy, out indicatorbuy2);
            this.ChromosomeValue.BuyCondition.TradeRules.Add(TradeRuleFactory.GenerateTradeRule(indicatorbuy1, mixbuy, indicatorbuy2));
            
            while (i < size && rand.Next(100) > 40)
            {
                string indicator1 = null;
                string indicator2 = null;
                IndicatorCompareType mix = new IndicatorCompareType();
                this.ChromosomeValue.BuyCondition.RuleJoinTypes.Add( indicatorHelper.GetRandomRuleJoinType());
                indicatorHelper.GetRandomIndicators(out indicator1, out mix, out indicator2);
                this.ChromosomeValue.BuyCondition.TradeRules.Add(TradeRuleFactory.GenerateTradeRule(indicator1, mix, indicator2));
                
                i++;
            }
            
            this.Clone();
            this.newID();
        }
        public void newID()
        {
            this.UniqueID = "Buy Conditions: ";
            this.UniqueID += string.Join(",", this.ChromosomeValue.BuyCondition.Name);
        }
        
        /// <summary>
        /// Creates a new instance of the chromosome with the same values.
        /// </summary>
        /// <returns>A new instance of the chromosome with the same values.</returns>
        internal TradeSystemChromosome Clone()
        {
            TradeCondition nBuy = new TradeCondition();
            nBuy = this.ChromosomeValue.BuyCondition.Clone();
            TradeSystemChromosome tc = new TradeSystemChromosome(
                new TradeSystem(
                    nBuy),
                this.indicatorHelper, 
                this.size);
            tc.Capital = this.Capital;
            tc.FitnessLosers = this.FitnessLosers;
            tc.FitnessWinners = this.FitnessWinners;
            tc.Fitness = this.Fitness;
            tc.UniqueID = this.UniqueID;
            tc.TradeTable = this.TradeTable;
            return tc;
        }

        /// <summary>
        /// Creates a new instance of the chromosome with the same values but blank fitness.
        /// </summary>
        /// <returns>A new instance of the chromosome with the same values but blank fitness.</returns>
        internal TradeSystemChromosome CloneWithoutFitness()
        {
            return new TradeSystemChromosome(
                new TradeSystem(
                    this.ChromosomeValue.BuyCondition.Clone()), 
                this.indicatorHelper, 
                this.size);
        }
    }
}
