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
    public class DivergeCompareTradeRule : TradeRule
    {
        static double PrevDifference = 0;
        static DatePoint prevPoint;
        /// <summary>
        /// Initializes a new instance of the SimpleCompareTradeRule class.
        /// </summary>
        /// <param name="indicator1">First indicator.</param>
        /// <param name="compareType">Type of comparison.</param>
        /// <param name="indicator2">Second indicator.</param>
        public DivergeCompareTradeRule(string indicator1, IndicatorCompareType compareType, string indicator2)
            : base(indicator1, compareType, indicator2)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the SimpleCompareTradeRule class.
        /// Default constructor for XML Serialization.
        /// </summary>
        public DivergeCompareTradeRule()
        {
        }
        static DatePoint lasttime;
        
        /// <summary>
        /// Evaluates the two indicators as passed
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The indicatorLibraryAdapter to use for the indicator evaluation.</param>
        /// <returns>A boolean value of the evaluation.</returns>
        public override bool Eval(TestData testData)
        {
            double? indicator1 = testData.GetIndicator(this.IndicatorName1);
            double? indicator2 = testData.GetIndicator(this.IndicatorName2);
            if (lasttime != null)
            {
                if (lasttime.PointDateTime.Date.CompareTo(testData.GetStockPoint().PointDateTime.Date) != 0)
                {
                    PrevDifference = 0;
                }
            }
            lasttime = testData.GetStockPoint();
            if (indicator1 == null || indicator2 == null)
            {
                return false;
            }
            double currentDifference = Math.Abs((double)indicator1 - (double)indicator2);
            if (PrevDifference == 0)
            {
                PrevDifference = Math.Abs((double)indicator1 - (double)indicator2);
                return false;
            }

            switch (this.CompareType)
            {
                case IndicatorCompareType.positiveDiverge:
                    if (currentDifference > PrevDifference)
                    {
                        PrevDifference = currentDifference;
                        return true;
                    }
                    else
                    {
                        PrevDifference = currentDifference;
                        return false;
                    }
                case IndicatorCompareType.negativeDiverge:
                    if (currentDifference < PrevDifference)
                    {
                        PrevDifference = currentDifference;
                        return true;
                    }
                    else
                    {
                        PrevDifference = currentDifference;
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
        /// lasttime makes sure program is circulating through different indicators of the same date/time
        /// prevTime is used to find the difference between the previous date/time
        /// <returns>A boolean value of the evaluation.</returns>
        public override bool Eval(Dictionary<DateTime, Dictionary<string, double>> indicatorLibraryAdapter, DatePoint point)
        {
            double? indicator1 = indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName1];
            double? indicator2 = indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName2];
            if (lasttime != null)
            {
                if (lasttime.PointDateTime.CompareTo(point.PointDateTime) != 0)
                {
                    prevPoint = lasttime;
                }
                if(prevPoint.Date.CompareTo(point.PointDateTime.Date)!=0)
                {
                    prevPoint = point;
                    lasttime = point;
                    return false;
                }
            }
            
            if (indicator1 == 0 || indicator2 == 0)
            {
                return false;
            }
            double currentDifference = Math.Abs((double)indicator1 - (double)indicator2);
            point.PointDateTime.AddMinutes(-5);
            double? indicator1a = indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName1];
            double? indicator2b = indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName2];
            point.PointDateTime.AddMinutes(5);
            double prevDifference = Math.Abs((double)indicator1a - (double)indicator2b);

            switch (this.CompareType)
            {
                case IndicatorCompareType.positiveDiverge:
                    if (currentDifference > PrevDifference)
                    {
                        PrevDifference = currentDifference;
                        return true;
                    }
                    else
                    {
                        PrevDifference = currentDifference;
                        return false;
                    }
                case IndicatorCompareType.negativeDiverge:
                    if (currentDifference < PrevDifference)
                    {
                        PrevDifference = currentDifference;
                        return true;
                    }
                    else
                    {
                        PrevDifference = currentDifference;
                        return false;
                    }

                default:
                    throw new Exception("Compare Type not defined");
            }
        }
    }
}
