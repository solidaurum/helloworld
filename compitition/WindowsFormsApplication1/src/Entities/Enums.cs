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
    /// To be determined.
    /// </summary>
    public enum CrossOverType
    {
    }

    /// <summary>
    /// Trade rule type
    /// </summary>
    public enum RuleType
    {
    }

    /// <summary>
    /// Rule compare type
    /// </summary>
    public enum IndicatorCompareType
    {
        /// <summary>
        /// Greater Than
        /// </summary>
        GT,

        /// <summary>
        /// Less Than--
        /// </summary>
        LT,

        ///<summary>
        ///crosses
        ///</summary>
        crossesAbove,
        crossesBelow,

        ///<summary>
        ///divergence
        ///</summary>
        positiveDiverge,
        negativeDiverge
        

        
    }

    /// <summary>
    /// To be determined.
    /// </summary>
    public enum TechnicalIndicator
    {
    }

    /// <summary>
    /// The join types for two trade rules
    /// </summary>
    public enum RuleJoinType
    {
        /// <summary>
        /// No join type
        /// </summary>
        none,

        /// <summary>
        /// Join with an and
        /// </summary>
        and,

        /// <summary>
        /// Join with an or
        /// </summary>
        or
    }

   
}
