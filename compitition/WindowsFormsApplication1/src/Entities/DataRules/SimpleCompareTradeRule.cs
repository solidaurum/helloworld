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
    public class SimpleCompareTradeRule : TradeRule
    {
        /// <summary>
        /// Initializes a new instance of the SimpleCompareTradeRule class.
        /// </summary>
        /// <param name="indicator1">First indicator.</param>
        /// <param name="compareType">Type of comparison.</param>
        /// <param name="indicator2">Second indicator.</param>
        public SimpleCompareTradeRule(string indicator1, IndicatorCompareType compareType, string indicator2)
            : base(indicator1, compareType, indicator2)
        { 
        }

        /// <summary>
        /// Initializes a new instance of the SimpleCompareTradeRule class.
        /// Default constructor for XML Serialization.
        /// </summary>
        public SimpleCompareTradeRule()
        {
        }
        
        /// <summary>
        /// Evaluates the two indicators as passed
        /// </summary>
        /// <param name="indicatorLibraryAdapter">The indicatorLibraryAdapter to use for the indicator evaluation.</param>
        /// <returns>A boolean value of the evaluation.</returns>
        public override bool Eval(TestData testData)
        {
            double? indicator1 = testData.GetIndicator(this.IndicatorName1);
            double? indicator2 = testData.GetIndicator(this.IndicatorName2);

            if (indicator1 == null || indicator2 == null)
            {
                return false;
            }

            switch (this.CompareType)
            {
                case IndicatorCompareType.GT:
                    return indicator1 > indicator2;
                case IndicatorCompareType.LT:
                    return indicator1 < indicator2;
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
            double? indicator1 = indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName1];
            double? indicator2 = indicatorLibraryAdapter[point.PointDateTime][this.IndicatorName2];

            if (indicator1 == null || indicator2 == null)
            {
                return false;
            }

            switch (this.CompareType)
            {
                case IndicatorCompareType.GT:
                    return indicator1 > indicator2;
                case IndicatorCompareType.LT:
                    return indicator1 < indicator2;
                default:
                    throw new Exception("Compare Type not defined");
            }
        }
    }
}
