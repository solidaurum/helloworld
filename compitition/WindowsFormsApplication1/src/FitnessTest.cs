///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.src
{
    public class FitnessTest
    {
        ///Compares data to results
        ///takes two files:
        ///     1 file with error data (consists of time of occurance)
        ///     1 file with array of results
        ///     
        /// Compares error data with results and assigns a % concurrance
        /// % is calculated by taking the number of results within a threshold 
        /// divided by the total number of occurances
        /// returns the result with the highest %
        /// 
        private List<DateTime> errorData;
        private List<DateTime> results;
        private int threshold = 0;
        public FitnessTest(int threshold, string unit)
        {
            switch(unit)
            {
                case "sec":
                    this.threshold = threshold;
                    break;
                case "min":
                    this.threshold = threshold * 60;
                    break;
                case "hr":
                    this.threshold = threshold * 1200;
                    break;
                default:
                    this.threshold = threshold;
                    break;
            }
        }
        public void getFitnessTest(List<DateTime> errorData, List<DateTime> results)
        {
            this.errorData = errorData;
            this.results = results;
        }
        public double getResults()
        {
            double percent = 0;
            int i = 0;
            int j= 0;
            int correspond = 0;
            int count = 0;
            if (errorData.Count != 0 && results.Count != 0)
            {
                while (i < errorData.Count && j < results.Count)
                {
                    if (errorData[i].CompareTo(results[j]) == 0)
                    {
                        correspond++;
                        i++;
                        j++;
                    }
                    else if (errorData[i].CompareTo(results[j]) < 0)
                    {
                        double seconds = (results[j].TimeOfDay - errorData[i].TimeOfDay).TotalSeconds;
                        if ((int)seconds <= threshold)
                        {
                            correspond++;
                            j++;
                        }
                        i++;
                    }
                    else
                    {
                        double seconds = (errorData[i].TimeOfDay - results[j].TimeOfDay).TotalSeconds;
                        if ((int)seconds <= threshold)
                        {
                            correspond++;
                            i++;
                        }
                        j++;
                    }
                    count++;
                }
                if (i < errorData.Count)
                {
                    while (i <= errorData.Count) { count++; i++; }
                }
                if (j < results.Count)
                {
                    while (j <= results.Count) { count++; j++; }
                }
            }
            percent = (double)correspond / (double)count * 100;
            return percent;
        }

    }
}
