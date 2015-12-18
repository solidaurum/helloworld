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
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// A derived class of TradeRule which compares two indicators
    /// </summary>
    [Serializable]
    public class CrossesCompareTradeRule : TradeRule
    {
        double indicator1a = 0;
        double indicator2a = 0;
        double indicator1 = 0;
        double indicator2 = 0;
        /// <summary>
        /// Initializes a new instance of the SimpleCompareTradeRule class.
        /// </summary>
        /// <param name="indicator1">First indicator.</param>
        /// <param name="compareType">Type of comparison.</param>
        /// <param name="indicator2">Second indicator.</param>
        public CrossesCompareTradeRule(string indicator1, IndicatorCompareType compareType, string indicator2)
            : base(indicator1, compareType, indicator2)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the SimpleCompareTradeRule class.
        /// Default constructor for XML Serialization.
        /// </summary>
        public CrossesCompareTradeRule()
        {
        }
        static DateTime lasttime;
        static DateTime prevTime;
        /// <summary>
        /// Evaluates the two indicators as passed
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The indicatorLibraryAdapter to use for the indicator evaluation.</param>
        /// <returns>A boolean value of the evaluation.</returns>
        public override bool Eval(TestData testData)
        {
            indicator1 = (double)testData.GetIndicator(this.IndicatorName1);
            indicator2 = (double)testData.GetIndicator(this.IndicatorName2);
            if (lasttime != null)
            {
                if (lasttime.Date.CompareTo(testData.GetStockPoint().PointDateTime.Date) != 0)
                {
                    indicator1a = 0;
                    indicator2a = 0;
                    prevTime = lasttime;
                }
                else
                {
                    indicator1a = getPrevIndicator(this.IndicatorName1, testData.GetStockPoint().PointDateTime, testData);
                    indicator2a = getPrevIndicator(this.IndicatorName2, testData.GetStockPoint().PointDateTime, testData);
                }
            }
            lasttime = testData.GetStockPoint().PointDateTime;
            if (indicator1 == null || indicator2 == null)
            {
                return false;
            }
            if (indicator1a == 0 || indicator2a == 0)
            {
                indicator1a = indicator1;
                indicator2a = indicator2;
                return false;
            }
            switch (this.CompareType)
            {
                case IndicatorCompareType.crossesAbove:
                    if (indicator1a < indicator2 && indicator1 > indicator2)
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return true;
                    }
                    else
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return false;
                    }
                case IndicatorCompareType.crossesBelow:
                    if (indicator1a > indicator2 && indicator1 < indicator2)
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return true;
                    }
                    else
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return false;
                    }

                default:
                    throw new Exception("Compare Type not defined");
            }
        }
        
        /// <summary>
        /// Evaluates the two indicators as passed
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The indicatorLibraryAdapter to use for the indicator evaluation.</param>
        /// <returns>A boolean value of the evaluation.</returns>
        public override bool Eval(Dictionary<DateTime, Dictionary<string, double>> indicatorLibraryAdapter, DatePoint point)
        {
            //double? indicator1 = (double)indicatorLibraryAdapter[point][this.IndicatorName1];
            //double? indicator2 = (double)indicatorLibraryAdapter[point][this.IndicatorName2];
            DateTime test = new DateTime();
            if (lasttime != null)
            {
                if (lasttime.Date.CompareTo(point.PointDateTime.Date) != 0)
                {
                    indicator1a = 0;
                    indicator2a = 0;
                    prevTime = lasttime;
                }
                else
                {
                    indicator1 = (double)indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName1];
                    indicator2 = (double)indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName2];
                    if (lasttime.CompareTo(point.PointDateTime) == 0)
                    {
                        if (prevTime == test)
                        {
                            prevTime = lasttime;
                        }
                        else
                        {
                            indicator1a = indicatorLibraryAdapter[prevTime][this.IndicatorName1];
                            indicator2a = indicatorLibraryAdapter[prevTime][this.IndicatorName1];
                        }
                    }
                    else
                    {
                        indicator1a = indicatorLibraryAdapter[lasttime][this.IndicatorName1];
                        indicator2a = indicatorLibraryAdapter[lasttime][this.IndicatorName1];
                        prevTime = lasttime;
                    }
                }
            }
            
            lasttime = point.PointDateTime;
            if (indicator1 == 0 || indicator2 == 0)
            {
                return false;
            }
            if (indicator1a == 0 || indicator2a == 0)
            {
                return false;
            }
            switch (this.CompareType)
            {
                case IndicatorCompareType.crossesAbove:
                    if (indicator1a < indicator2 && indicator1 > indicator2)
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return true;
                    }
                    else
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return false;
                    }
                case IndicatorCompareType.crossesBelow:
                    if (indicator1a > indicator2 && indicator1 < indicator2)
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return true;
                    }
                    else
                    {
                        indicator1a = indicator1;
                        indicator2a = indicator2;
                        return false;
                    }

                default:
                    throw new Exception("Compare Type not defined");
            }
        }
        private double getPrevIndicator(String Indicator, DateTime date, TestData ILA)
        {
            TimeSpan fiveMinuet = new TimeSpan(0, 5, 0);
            ILA.Restart();
            ILA.MoveToDate(date.AddMinutes(-5));
            if (ILA.GetIndicator(Indicator) != null)
            {
                double value = (double)ILA.GetIndicator(Indicator);
                ILA.MoveNext();
                return value;
            }
            else
            {
                ILA.MoveNext();
                return 0;
            }
        }
    }
}
