///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///


namespace WindowsFormsApplication1.src
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using WindowsFormsApplication1.src.Entities;
    using WindowsFormsApplication1.src.Library;

    /// <summary>
    /// Class contains buy/sell rule generator methods, populate trade base on input data and input buy/sell rule
    /// </summary>
    public class TradeHelper
    {
        List<DateTime> occurance;
        TradeSystem tradeSystem;
        /// Initializes a new instance of the TradeHelper class.
        /// </summary>
        /// <param name="tradeSystem">The trading system to use.</param>
        public TradeHelper(TradeSystem tradeSystem)
        {
            occurance = new List<DateTime>();
            this.tradeSystem = tradeSystem;
        }
        
        
        /// <summary>
        /// Gets the number of trades.
        /// </summary>
        public List<DateTime> occuranceCount
        {
            get
            {
                return this.occurance;
            }
        }


        /// <summary>
        /// Calculates all the buys and sells against the dataset.
        /// </summary>
        /// <param name="indicatorLibraryAdapter">Moves through each row of the indicatorLibraryAdapter to find the buy and sell points.</param>
        public void RunBacktest(TestData indicatorLibraryAdapter, Dictionary<DateTime, Dictionary<string, double>> ILA)
        {
            
            TradeCondition newbuyCondition = tradeSystem.BuyCondition;
            indicatorLibraryAdapter.Restart();
            DatePoint point = indicatorLibraryAdapter.GetStockPoint();
            do
            {
                if (newbuyCondition.Eval(ILA, point))
                {
                    occurance.Add(indicatorLibraryAdapter.GetStockPoint().PointDateTime);
                }
                point = indicatorLibraryAdapter.GetStockPoint();
            } while (indicatorLibraryAdapter.MoveNext());

        }

        public List<DateTime> Percent()
        {
            return occurance;
        }
    }
}
