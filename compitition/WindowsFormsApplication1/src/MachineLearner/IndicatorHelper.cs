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

    /// <summary>
    /// A helper class for generating indicators at random.
    /// </summary>
    [Serializable]
    public class IndicatorHelper
    {
        /// <summary>
        /// A list of all the indicators.
        /// </summary>
        private string[] indicators;

        /// <summary>
        /// A random number generator.
        /// </summary>
        private Random rand;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group A is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupA;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group B is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupB;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group C is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupC;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group D is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupD;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group E is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupE;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group F is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupF;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group G is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupG;

        /// <summary>
        /// A set of comparable indicators.
        /// GDBCup - Group H is a set of indicators that can be compared to each other
        /// </summary>
        private string[] indicatorsGroupH;

        /// <summary>
        /// Initializes a new instance of the IndicatorHelper class.
        /// </summary>
        /// <param name="indicators">The indicators to use for generation.</param>
        public IndicatorHelper(string[] indicators)
        {
            this.indicators = indicators;
            this.rand = new Random();
            this.PopulateIndicatorGroups();
        }

        /// <summary>
        /// Get a set of 2 random indicators and a compare type.
        /// </summary>
        /// <param name="indicator1">The first random indicator.</param>
        /// <param name="compareType">The compare type for the indicator set.</param>
        /// <param name="indicator2">The second random indicator.</param>
        public void GetRandomIndicators(out string indicator1, out IndicatorCompareType compareType, out string indicator2)
        {   
            indicator1 = this.GetRandomIndicator();
            compareType = this.GetRandomCompareType();
            indicator2 = this.GetRandomIndicator(indicator1, compareType);
        }

        /// <summary>
        /// Gets a rule join type at random (and, or) with or's being less frequent.
        /// </summary>
        /// <returns>a random rule join type (and, or)</returns>
        public RuleJoinType GetRandomRuleJoinType()
        {
            int num = this.rand.Next(10);
            if (num < 3)
            {
                return RuleJoinType.or;
            }
            else
            {
                return RuleJoinType.and;
            }
        }

        /// <summary>
        /// Gets an indicator from the set at random.
        /// </summary>
        /// <returns>An indicator </returns>
        private string GetRandomIndicator()
        {
            int num;
            do
            {
                num = this.rand.Next(this.indicators.Length);
            } 
            while (num < 7 && !(num >= 2 && num <= 5));
            return this.indicators[num];
        }

        /// <summary>
        /// Gets a second indicator that can be used with the given indicator and compare type.
        /// </summary>
        /// <param name="indicator">Indicator to compare to.</param>
        /// <param name="compareType">Compare type for the indicators.</param>
        /// <returns>A random indicator to caompare with indicator and compareType.</returns>
        private string GetRandomIndicator(string indicator, IndicatorCompareType compareType)
        {
            int num;
            num = this.rand.Next(this.indicatorsGroupA.Length);
            while (indicatorsGroupA[num] == indicator)
            {
                num = this.rand.Next(this.indicatorsGroupA.Length);
            }
            return this.indicatorsGroupA[num];
            
            
            /*
            else if (indicator.StartsWith("Schaff", true, null) ||
                    indicator.StartsWith("RSI", true, null) ||
                    indicator.StartsWith("Stochastics", true, null) ||
                    indicator.StartsWith("Constant", true, null)||
                    indicator.StartsWith("Aroon", true, null))
            {
                num = this.rand.Next(this.indicatorsGroupB.Length);
                while (indicatorsGroupB[num] == indicator)
                {
                    num = this.rand.Next(this.indicatorsGroupB.Length);
                }
                return this.indicatorsGroupB[num]; 
            }
            else if (indicator.StartsWith("MACD", true, null))
            {
                num = this.rand.Next(this.indicatorsGroupC.Length);
                while (indicatorsGroupC[num] == indicator)
                {
                    num = this.rand.Next(this.indicatorsGroupC.Length);
                }
                return this.indicatorsGroupC[num]; 
            }
            else if (indicator.StartsWith("Histogram", true, null)||
                    indicator.StartsWith("Volume", true, null))
            {
                num = this.rand.Next(this.indicatorsGroupD.Length);
                while (indicatorsGroupD[num] == indicator)
                {
                    num = this.rand.Next(this.indicatorsGroupD.Length);
                }
                return this.indicatorsGroupD[num]; 
            }
            else if (indicator.StartsWith("Chaikin", true, null) ||
                     indicator.StartsWith("Force", true, null))
            {
                num = this.rand.Next(this.indicatorsGroupE.Length);
                while (indicatorsGroupE[num] == indicator)
                {
                    num = this.rand.Next(this.indicatorsGroupE.Length);
                }
                return this.indicatorsGroupE[num];
            }
            else //if (indicator.StartsWith("Force", true, null))
            {
                num = this.rand.Next(this.indicatorsGroupF.Length);
                while (indicatorsGroupF[num] == indicator)
                {
                    num = this.rand.Next(this.indicatorsGroupF.Length);
                }
                return this.indicatorsGroupF[num];
            }*/
        }

        /// <summary>
        /// Get an indicator compare type at random.
        /// </summary>
        /// <returns>An indicator compare type.</returns>
        private IndicatorCompareType GetRandomCompareType()
        {
            int num = this.rand.Next(10);
            switch (num)
            {
                case 0: return IndicatorCompareType.GT;
                case 1: return IndicatorCompareType.LT;
                case 2: return IndicatorCompareType.crossesAbove;
                case 3: return IndicatorCompareType.crossesBelow;
                case 4: return IndicatorCompareType.positiveDiverge;
                case 5: return IndicatorCompareType.negativeDiverge;
                case 6: return IndicatorCompareType.crossesAbove;
                case 7: return IndicatorCompareType.positiveDiverge;
                case 8: return IndicatorCompareType.crossesBelow;
                case 9: return IndicatorCompareType.negativeDiverge;
                default: return IndicatorCompareType.GT;
            }
        }

        /// <summary>
        /// Fill the indicator groups with the indicators.
        /// </summary>
        private void PopulateIndicatorGroups()
        {
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            List<string> listD = new List<string>();
            List<string> listE = new List<string>();
            List<string> listF = new List<string>();
            List<string> listG = new List<string>();
            List<string> listH = new List<string>();

            /// *****************************************************
            /// GDBCup - Statements in for loop below need some work
            /// You may need to add/delete lines and replace terms
            /// *****************************************************

            foreach (string indicator in this.indicators)
            {
                if (indicator.StartsWith("Whole", true, null)||
                    indicator.StartsWith("timestamp", true, null)||
                    indicator.StartsWith("Timestamp", true, null))
                {

                }
                else
                {
                    listA.Add(indicator);
                }


            }
            this.indicatorsGroupA = listA.ToArray();
            
        }
        public string mutateIndicator(string indicator1, IndicatorCompareType compareType)
        {
            string newindicator2 = this.GetRandomIndicator(indicator1, compareType);
            return newindicator2;
        }
        public IndicatorCompareType mutateCompareType()
        {
            return GetRandomCompareType();
        }
        public RuleJoinType mutateRuleJoinType()
        {
            return GetRandomRuleJoinType();
        }
    }
}
