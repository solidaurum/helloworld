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
    using WindowsFormsApplication1.src.Entities.TradeRules;
    using WindowsFormsApplication1.src.Interfaces;

    /// <summary>
    /// Implementation of a genetic mutating algorithm for trade conditions.
    /// </summary>
    public class TradeConditionMutation : IGeneticMutating
    {
        /// <summary>
        /// Random number generator.
        /// </summary>
        private Random rand;

        /// <summary>
        /// The mutation rate.
        /// </summary>
        private double rate;

        /// <summary>
        /// The indicator helper to generate a new trade rule with.
        /// </summary>
        private IndicatorHelper indicatorHelper;

        private int[] index;

        /// <summary>
        /// Initializes a new instance of the TradeConditionMutation class.
        /// </summary> 
        /// <param name="rate">The mutation rate.</param>
        /// <param name="indicatorHelper">The indicator helper to mutate with.</param>
        public TradeConditionMutation(double rate, IndicatorHelper indicatorHelper)
        {
            this.indicatorHelper = indicatorHelper;
            this.rate = rate;
            this.rand = new Random();
        }

        /// <summary>
        /// Mutates a population based on the mutating algorithm.
        /// </summary>
        /// <param name="chromosomeList">The chromosomes to be mutated.</param>
        public void Mutate(ref TradeSystemChromosome[] chromosomeList)
        {
            
            for (int i = 0; i < rate * chromosomeList.Count(); i++)
            {
                Mutate(chromosomeList[ rand.Next(chromosomeList.Count() - 1)]);
            }

        }

        /// <summary>
        /// Mutate the chrmosome.
        /// type identifies what will be mutated
        /// x=1 is an indicator
        /// x=2 is a comparetype
        /// x=3 is a join rule
        /// buysell identifies which traderule will be mutated
        /// x = 1 buyrule
        /// x = 2 sellrule
        /// </summary>
        /// <param name="tradeSystemChromosome">The chromosome to mutate.</param>
        private void Mutate(TradeSystemChromosome tradeSystemChromosome)
        {
            int type = rand.Next(3);
            int buysell = rand.Next(2);
            switch (buysell)
            {
                case 1:
                    switch (type)
                    {
                        case 1:
                            if (tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count == 0)
                            {
                                if (rand.Next(2) == 1)
                                {

                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName1 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName2, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].CompareType);
                                }
                                else
                                {
                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName2 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName1, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].CompareType);
                                }
                            }
                            else
                            {
                                int location = rand.Next(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count);
                                if (rand.Next(2) == 1)
                                {

                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName1 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName2, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].CompareType);
                                }
                                else
                                {
                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName2 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName1, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].CompareType);
                                }
                            }
                            break;
                        case 2:
                            if (tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count == 0)
                            {
                                
                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].CompareType = indicatorHelper.mutateCompareType();
                                
                            }
                            else
                            {
                                int location = rand.Next(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count);
                                tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].CompareType = indicatorHelper.mutateCompareType();
                            }
                            break;
                        case 3:
                            if (tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count == 0)
                            {

                                tradeSystemChromosome.ChromosomeValue.BuyCondition.RuleJoinTypes[0] = indicatorHelper.mutateRuleJoinType();

                            }
                            else
                            {
                                int location = rand.Next(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count);
                                tradeSystemChromosome.ChromosomeValue.BuyCondition.RuleJoinTypes[location] = indicatorHelper.mutateRuleJoinType();
                            }
                            break;
                        default:
                            if (tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count == 0)
                            {
                                if (rand.Next(2) == 1)
                                {

                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName1 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName2, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].CompareType);
                                }
                                else
                                {
                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName2 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].IndicatorName1, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[0].CompareType);
                                }
                            }
                            else
                            {
                                int location = rand.Next(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules.Count);
                                if (rand.Next(2) == 1)
                                {

                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName1 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName2, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].CompareType);
                                }
                                else
                                {
                                    tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName2 = indicatorHelper.mutateIndicator(tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].IndicatorName1, tradeSystemChromosome.ChromosomeValue.BuyCondition.TradeRules[location].CompareType);
                                }
                            }
                            break;
                    }
                    break;
                default:
                    
                    break;
            }
            
        
        }
    }
}
