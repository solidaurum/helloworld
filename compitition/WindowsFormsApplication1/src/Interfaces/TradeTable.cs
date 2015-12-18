using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.src.Library
{
    public interface TradeTable
    {
        /// <summary>
        /// Gets the result of the trade eval
        /// 0 means false
        /// 1 means true
        /// </summary>
        double[] Values { get; }


        /// <summary>
        /// Gets a list of the keys which correspond to the Values outputted
        /// </summary>
        string[] Keys { get; set; }

        
    }
}
