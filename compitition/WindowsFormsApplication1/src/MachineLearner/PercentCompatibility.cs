///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.src.MachineLearner
{
    static class PercentCompatibility
    {
        public static double getPercent(List<DateTime> error, List<DateTime> chromosome)
        {
            int i = 0;
            int j = 0;
            int withinLimit = 0;
            while (error.Count > i || chromosome.Count > j)
            {
                if (error[i] == chromosome[j])
                {
                    withinLimit++;
                    i++;
                    j++;
                }
                else if (error[i] > chromosome[j])
                {
                    j++;
                }
                else if (error[i] < chromosome[j])
                {
                    i++;
                }
            }
            double percent = (double)withinLimit / (double)error.Count * 100;
            return percent;
        }
    }
}
