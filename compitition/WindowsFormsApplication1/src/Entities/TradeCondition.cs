///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

namespace WindowsFormsApplication1.src.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using WindowsFormsApplication1.src.Entities.TradeRules;

    /// <summary>
    /// A trade condition that is a set of joined trade rules.
    /// </summary>
    [Serializable]
    public class TradeCondition 
    {
        private Dictionary<DateTime, Dictionary<string, double>> map = new Dictionary<DateTime,Dictionary<string,double>>();
        /// <summary>
        /// Initializes a new instance of the TradeCondition class.
        /// </summary>
        public TradeCondition()
        {
            this.TradeRules = new List<TradeRule>();
            this.RuleJoinTypes = new List<RuleJoinType>();
        }

        /// <summary>
        /// Gets or sets the set of trade rules.
        /// </summary>
        [XmlArray("tradeRules")]
        [XmlArrayItem("SimpleCompareTradeRule", typeof(SimpleCompareTradeRule))]
        [XmlArrayItem("CrossesCompareTradeRule", typeof(CrossesCompareTradeRule))]
        [XmlArrayItem("DivergeCompareTradeRule", typeof(DivergeCompareTradeRule))]
        [XmlArrayItem("TradeRule", typeof(TradeRule))]
        /// **********************************************
        /// GDBCup - More compares could be added here
        /// **********************************************
        public List<TradeRule> TradeRules
        {
            get;
            set;
        }

        ///  <summary>
        /// Gets or sets the set of joins for the trade rules.
        /// </summary>
        [XmlArray("ruleJoinTypes")]
        public List<RuleJoinType> RuleJoinTypes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the name of the trade condition.
        /// </summary>
        public string Name
        {
            get
            {
                string name = string.Empty;
                for (int i = 0; i < this.TradeRules.Count-1; i++)
                {
                    name += this.TradeRules[i].Name + " " + this.RuleJoinTypes[i].ToString();
                }
                name += this.TradeRules[this.TradeRules.Count - 1].Name;

                return name;
            }
        }

        /// <summary>
        /// Add a new trade rule and join condition.
        /// </summary>
        /// <param name="tradeRule">The trade rule to add.</param>
        /// <param name="ruleJoinType">The join condition to add.</param>
        public void Add(TradeRule tradeRule, RuleJoinType ruleJoinType)
        {
            if (this.RuleJoinTypes.Count > 0 && this.RuleJoinTypes.Last() == RuleJoinType.none)
            {
                throw new TradeRuleException("Can not add another trade rule. The previous join type was none.");
            }

            this.TradeRules.Add(tradeRule);
            this.RuleJoinTypes.Add(ruleJoinType);
        }

        /// <summary>
        /// Evaluates the trade rule for the current indicatorLibraryAdapter line.
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The data source to evaluate.</param>
        /// <returns>A boolean value for the conditionon this line.</returns>
        public bool Eval(TestData indicatorLibraryAdapter)
        {
            if (this.TradeRules.Count == 0)
            {
                throw new TradeRuleException("Trade rules not defined.");
            }
            DatePoint newPoint = indicatorLibraryAdapter.GetStockPoint();
            TradeRule[] traderule1 = new TradeRule[TradeRules.Count];
            
            bool evalValue = false;

            if (TradeRules.Count >= 2)
            {
                bool[] tradeeval = new bool[TradeRules.Count];
                for (int i = 0; i < TradeRules.Count; i++)
                {
                    string indicator1 = TradeRules[i].IndicatorName1;
                    string indicator2 = TradeRules[i].IndicatorName2;
                    TradeRule nT= TradeRuleFactory.GenerateTradeRule(indicator1, TradeRules[i].CompareType, indicator2);
                    traderule1[i] = nT;
                    
                }
                for (int i = 0; i < TradeRules.Count; i++)
                {

                    tradeeval[i] = traderule1[i].Eval(indicatorLibraryAdapter);

                }
                for (int i = 0; i < RuleJoinTypes.Count; i++)
                {
                    if (i != 0 && RuleJoinTypes[i - 1] == RuleJoinType.and)
                    {
                    }
                    else
                    {
                        while (RuleJoinTypes[i] == RuleJoinType.and)
                        {
                            if (tradeeval[i] && tradeeval[i + 1])
                            {
                                evalValue = true;
                            }
                            else
                            {
                                evalValue = false;
                                break;
                            }
                            i++;
                            if (i >= RuleJoinTypes.Count)
                            {
                                i--;
                                break;
                            }
                        }
                    }
                    if (evalValue == true)
                    {
                        break;
                    }
                    if (RuleJoinTypes[i] == RuleJoinType.or)
                    {
                        if (i >= RuleJoinTypes.Count)
                        {
                        }
                        else if (RuleJoinTypes[i + 1] == RuleJoinType.and)
                        {
                            while (RuleJoinTypes[i] == RuleJoinType.and)
                            {
                                if (tradeeval[i] && tradeeval[i + 1])
                                {
                                    evalValue = true;
                                }
                                else
                                {
                                    evalValue = false;
                                }
                                i++;
                            }
                            if (evalValue == true)
                            {
                                break;
                            }
                        }
                        else
                        {
                            if (tradeeval[i])
                            {
                                evalValue = true;
                                break;
                            }
                        }
                    }
                }



            }
            else
            {
                string indicator1 = TradeRules[0].IndicatorName1;
                string indicator2 = TradeRules[0].IndicatorName2;
                traderule1[0] = TradeRuleFactory.GenerateTradeRule(indicator1, TradeRules[0].CompareType, indicator2);
                evalValue = traderule1[0].Eval(indicatorLibraryAdapter);
            }
            
            
            
            return evalValue;
        }

        /// <summary>
        /// Evaluates the trade rule for the current indicatorLibraryAdapter line.
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The data source to evaluate.</param>
        /// <returns>A boolean value for the conditionon this line.</returns>
        public bool Eval(Dictionary<DateTime, Dictionary<string, double>> indicatorLibraryAdapter, DatePoint point)
        {
            if (this.TradeRules.Count == 0)
            {
                throw new TradeRuleException("Trade rules not defined.");
            }
            DatePoint newPoint = point;
            TradeRule[] traderule1 = new TradeRule[TradeRules.Count];

            bool evalValue = false;

            if (TradeRules.Count >= 2)
            {
                bool[] tradeeval = new bool[TradeRules.Count];
                int tradeevalcount = 0;
                for (int i = 0; i < TradeRules.Count; i++)
                {
                    string indicator1 = TradeRules[i].IndicatorName1;
                    string indicator2 = TradeRules[i].IndicatorName2;
                    TradeRule nT = TradeRuleFactory.GenerateTradeRule(indicator1, TradeRules[i].CompareType, indicator2);
                    traderule1[i] = nT;

                }
                for (int i = 0; i < TradeRules.Count; i++)
                {

                    tradeeval[i] = traderule1[i].Eval(indicatorLibraryAdapter, point);

                }
                for (int i = 0; i < RuleJoinTypes.Count; i++)
                {
                    #region and jointype
                    if (RuleJoinTypes[i] == RuleJoinType.and)
                    {
                        int andCount = 0;
                        int j = 0;
                        while (RuleJoinTypes[i] == RuleJoinType.and)
                        {
                            for (int k = 0; k < 2; k++)
                            {
                                if (tradeevalcount >= tradeeval.Count())
                                {
                                    break;
                                }
                                if (tradeeval[tradeevalcount++])
                                {
                                    andCount++;
                                    j++;
                                }
                                else
                                {
                                    j++;
                                }
                            }
                            if (i >= RuleJoinTypes.Count - 1)
                            {
                                //i--;
                                break;
                            }
                            if (RuleJoinTypes[i + 1] == RuleJoinType.and)
                                {
                                    tradeevalcount--;
                                }
                            
                            i++;
                            
                        }
                        if (j == andCount)
                        {
                            return true;
                        }
                    }
                    #endregion
                    #region or jointype
                    if (RuleJoinTypes[i] == RuleJoinType.or)
                    {
                        /*if (i == 0)
                        {
                            if (tradeeval[tradeevalcount++])
                            {
                                return true;
                            }
                        }
                        else if (RuleJoinTypes[i - 1] == RuleJoinType.or && RuleJoinTypes[i+1] != RuleJoinType.and)
                        {
                            if (tradeeval[tradeevalcount++])
                            {
                                return true;
                            }
                        }
                        else */if (i >= RuleJoinTypes.Count-1)
                        {
                            if (tradeeval[tradeevalcount++])
                            {
                                return true;
                            }
                        }
                        else if (RuleJoinTypes[i + 1] == RuleJoinType.and)
                        {
                            int andCount = 0;
                            int j = 0;
                            while (RuleJoinTypes[i+1] == RuleJoinType.and)
                            {
                                for (int k = 0; k < 2; k++)
                                {
                                    if (tradeevalcount >= tradeeval.Count())
                                    {
                                        break;
                                    }
                                    if (tradeeval[tradeevalcount++])
                                    {
                                        andCount++;
                                        j++;
                                    }
                                    else
                                    {
                                        j++;
                                    }
                                }
                                if (RuleJoinTypes[i + 1] == RuleJoinType.and)
                                {
                                    tradeevalcount--;
                                }
                                i++;
                                if (i >= RuleJoinTypes.Count-1)
                                {
                                    //i--;
                                    break;
                                }
                            }
                            if (andCount == j)
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (tradeevalcount >= tradeeval.Count())
                            {
                                break;
                            }
                            if (tradeeval[tradeevalcount++])
                            {
                                return true;
                            }
                        }
                    }
                }
                    #endregion


            }
            else
            {
                string indicator1 = TradeRules[0].IndicatorName1;
                string indicator2 = TradeRules[0].IndicatorName2;
                traderule1[0] = TradeRuleFactory.GenerateTradeRule(indicator1, TradeRules[0].CompareType, indicator2);
                evalValue = traderule1[0].Eval(indicatorLibraryAdapter, point);
            }



            return evalValue;
        }
        /// <summary>
        /// Deep clone the object by creating new objects all the way down.
        /// </summary>
        /// <returns>A new object with a different reference and same data.</returns>
        internal TradeCondition Clone()
        {
            TradeCondition tc = new TradeCondition();
            for (int i = 0; i < this.TradeRules.Count; i++)
            {
                TradeCondition temp = new TradeCondition();
                temp.TradeRules.Add(this.TradeRules[0]);
                temp.TradeRules.ElementAt(0).IndicatorName1 = this.TradeRules.ElementAt(i).IndicatorName1;
                temp.TradeRules.ElementAt(0).IndicatorName2 = this.TradeRules.ElementAt(i).IndicatorName2;
                temp.TradeRules.ElementAt(0).CompareType = this.TradeRules.ElementAt(i).CompareType;
                
                tc.TradeRules.Add(temp.TradeRules[0]);
            }
            for (int i = 0; i < this.RuleJoinTypes.Count; i++)
            {
                tc.RuleJoinTypes.Add(DeepCopy.getDeepCopy(this.RuleJoinTypes.ElementAt(i)));
            }
            //tc.RuleJoinTypes = this.RuleJoinTypes;
            //tc.TradeRules = this.TradeRules;
            return tc;
        }
        /// <summary>
        /// Add a value to the dictionary for the graph.
        /// </summary>
        /// <param name="key1">The date and time of the value.</param>
        /// <param name="key2">The name of the line to graph.</param>
        /// <param name="value">The value to graph.</param>
        /// <param name="map">The dictonary to add the point to.</param>
        public void AddValue(DateTime key1, string key2, int value)
        {
            if (this.map.ContainsKey(key1))
            {
                if (!this.map[key1].ContainsKey(key2))
                {
                    this.map[key1].Add(key2, value);
                }
            }
            else
            {
                Dictionary<string, double> temp = new Dictionary<string, double>();
                temp.Add(key2, value);
                this.map.Add(key1, temp);
            }
        }
    }

    
}
