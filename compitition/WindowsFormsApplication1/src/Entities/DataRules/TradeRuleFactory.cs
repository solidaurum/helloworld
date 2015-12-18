﻿namespace WindowsFormsApplication1.src.Entities.TradeRules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class used to generate the TradeRules based on CompareType and indicators
    /// </summary>
    public class TradeRuleFactory
    {
        /// <summary>
        /// Returns a TradeRule generated with two indicators and a CompareType
        /// </summary>
        /// <param name="indicator1">The first indicator</param>
        /// <param name="compareType">The comparison type</param>
        /// <param name="indicator2">The last indicator</param>
        /// <returns>Returns a new TradeRule object</returns>
        public static TradeRule GenerateTradeRule(string indicator1, IndicatorCompareType compareType, string indicator2)
        {
            try
            {
                TradeRule tr = null;
                switch (compareType)
                {
                    case IndicatorCompareType.GT:
                    case IndicatorCompareType.LT:
                        tr = new SimpleCompareTradeRule(indicator1, compareType, indicator2);
                        break;
                    case IndicatorCompareType.crossesAbove:
                    case IndicatorCompareType.crossesBelow:
                        tr = new CrossesCompareTradeRule(indicator1, compareType, indicator2);
                        break;
                    case IndicatorCompareType.positiveDiverge:
                    case IndicatorCompareType.negativeDiverge:
                        tr = new DivergeCompareTradeRule(indicator1, compareType, indicator2);
                        break;
                    default:
                        tr = null;
                        break;
                }

                return tr;
            }
            catch (TradeRuleException)
            {
                throw;
            }
        }
    }
}