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

    /// <summary>
    /// The trade system for backtesting. (Buy/Sell rules, financial settings, and backtest period/method)
    /// </summary>
    [Serializable]
    public class TradeSystem
    {
        /// <summary>
        /// Initializes a new instance of the TradeSystem class.
        /// Default constructor needed for serialization.
        /// </summary>
        public TradeSystem()
        {
            this.BuyCondition = null;
        }

        /// <summary>
        /// Initializes a new instance of the TradeSystem class.
        /// </summary>
        /// <param name="buyCondition">Buy conditions for the trade system</param>
        /// <param name="sellCondition">Sell conditions for the trade system</param>
        /// <param name="startDate">Date to start trading</param>
        /// <param name="endDate">Date to stop trading</param>
        /// <param name="financialSettings">Financial settings for the trade system</param>
        /// <param name="shorts">Short trades are allowed.</param>
        /// <param name="longs">Long trades are allowed.</param>
        public TradeSystem(
            TradeCondition buyCondition  
            )
        {
            this.BuyCondition = buyCondition;
            
        }

        /// <summary>
        /// Gets or sets the buy conditions for the trade system.
        /// </summary>
        public TradeCondition BuyCondition
        {
            get;
            set;
        }


        /// <summary>
        /// Creates a copy of this trade system.
        /// </summary>
        /// <returns>A copy of this trade system.</returns>
        public TradeSystem Clone()
        {
            TradeSystem clone = new TradeSystem();
            clone.BuyCondition = DeepCopy.getDeepCopy(this.BuyCondition);
            return clone;
        }

        /// <summary>
        /// Creates a copy of this trade system with new trade conditions.
        /// </summary>
        /// <param name="buyCondition">The buy condition.</param>
        /// <param name="sellCondition">The sell condition.</param>
        /// <returns>A copy of this trade system with new trade conditions.</returns>
        public TradeSystem CloneWithNewRules(TradeCondition buyCondition, TradeCondition sellCondition)
        {
            TradeSystem clone = this.Clone();
            clone.BuyCondition = buyCondition;
            return clone;
        }
    }
}
