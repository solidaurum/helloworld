///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.src
{
    public class TestData
    {
        /// <summary>
        /// The indicators split from the csv.
        /// </summary>
        private string[] indicators;

        /// <summary>
        /// The stream reader for the csv file.
        /// </summary>
        private StreamReader streamReader;

        /// <summary>
        /// The file path for the indicator library.
        /// </summary>
        private string testDataFile;

        /// <summary>
        /// The stock point for the current line in the indicator library.
        /// </summary>
        private DatePoint datePoint;

        /// <summary>
        /// The dictionary object for the file
        /// </summary>
        private Dictionary<DateTime, Dictionary<string, double>> TDD = new Dictionary<DateTime,Dictionary<string,double>>();

        /// <summary>
        /// Initializes a new instance of the IndicatorLibraryAdapter class.
        /// </summary>
        /// <param name="indicatorFile">A file path for the csv file to read.</param>
        public TestData(string testFile)
        {
            this.testDataFile = testFile;
            this.IndicatorLocations = new Dictionary<string, int>();
            this.streamReader = new StreamReader(File.Open(this.testDataFile, System.IO.FileMode.Open));
            this.MoveNext();
            for (int i = 0; i < this.indicators.Length; i++)
            {
                this.IndicatorLocations.Add(this.indicators[i].Trim(), i);
            }

            this.MoveNext();
        }
        
        /// <summary>
        /// Gets the indicator names and the associated column.
        /// </summary>
        public Dictionary<string, int> IndicatorLocations
        {
            get;
            private set;
        }

        /// <summary>
        /// Moves to the next line of the input.
        /// </summary>
        /// <returns>false if it's at the end of the file.</returns>
        public bool MoveNext()
        {
            if (this.streamReader == null)
            {
                return false;
            }

            if (this.streamReader.EndOfStream)
            {
                this.streamReader.Close();
                this.streamReader = null;
                return false;
            }

            this.datePoint = null;
            this.indicators = this.streamReader.ReadLine().Split(',');
            return true;
        }

        /// <summary>
        /// Moves the library adapter to a given date time.
        /// </summary>
        /// <param name="dateTime">The date time to move the library to.</param>
        /// <returns>True if the dateTime is found. False if EOF is reached.</returns>
        public bool MoveToDate(DateTime dateTime)
        {
            while (this.GetStockPoint().PointDateTime < dateTime)
            {
                if (!this.MoveNext())
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Restarts the position of the adapter at the second line of the stream
        /// </summary>
        public void Restart()
        {
            this.CloseFile();
            this.streamReader = new StreamReader(File.Open(this.testDataFile, System.IO.FileMode.Open));
            this.MoveNext();
            this.MoveNext();
        }

        /// <summary>
        /// Closes the file stream.
        /// </summary>
        public void CloseFile()
        {
            if (this.streamReader != null)
            {
                this.streamReader.Close();
            }
        }

        /// <summary>
        /// Gets an indicator for the current line based on its name.
        /// A name beginning with # will return the rest of the string as a double
        /// </summary>
        /// <param name="indicatorName">Indicator name</param>
        /// <returns>Indicator value</returns>
        public double? GetIndicator(string indicatorName)
        {
            if (indicatorName.ElementAt(0) == '#')
            {
                return Double.Parse(indicatorName.Remove(0, 1));
            }
            else
            {
                int i = this.IndicatorLocations[indicatorName];
                string indicator = this.indicators[i];
                if (indicator.Trim() == string.Empty)
                {
                    return 0;
                }

                return double.Parse(indicator);
            }
        }

        public DateTime? getDateTime(string indicatorName)
        {
            if (indicatorName.ElementAt(0) == '#')
            {
                return DateTime.Parse(indicatorName.Remove(0, 1));
            }
            else
            {
                int i = this.IndicatorLocations[indicatorName];
                string indicator = this.indicators[i];
                DatePoint newpoint = new DatePoint();
                if (indicator.Trim() == string.Empty)
                {
                    return null;
                }
                
                return newpoint.ParseDateTime(indicator);
            }
        }

        /// <summary>
        /// Gets a stock point object for the current line.
        /// </summary>
        /// <returns>A stock point object for the current line.</returns>
        public DatePoint GetStockPoint()
        {
            if (this.datePoint == null)
            {
                this.datePoint = new DatePoint(
                    this.indicators[this.IndicatorLocations["timestamp"]]);
            }

            return this.datePoint;
        }

        public Dictionary<DateTime, Dictionary<string, double>> getDictionary()
        {
            do{
                for(int i = 0; i < this.indicators.Count(); i++)
                {
                    if (TDD.ContainsKey(GetStockPoint().PointDateTime))
                    {
                        if (this.indicators[i].CompareTo("timestamp") > 0)
                        {
                            //TDD[GetStockPoint().PointDateTime].Add(this.IndicatorLocations.Keys.ElementAt(i), (DateTime)getDateTime(this.IndicatorLocations.Keys.ElementAt(i)));
                        }
                        else if (!TDD[GetStockPoint().PointDateTime].ContainsKey(this.indicators[i]))
                        {
                            TDD[GetStockPoint().PointDateTime].Add(this.IndicatorLocations.Keys.ElementAt(i), (double)GetIndicator(this.IndicatorLocations.Keys.ElementAt(i)));
                        }
                    }
                    else
                    {
                        Dictionary<string, double> temp = new Dictionary<string, double>();
                        if (this.IndicatorLocations.Keys.ElementAt(i) == "timestamp" || this.IndicatorLocations.Keys.ElementAt(i) == "Timestamp")
                        {

                        }
                        else
                        {
                            temp.Add(this.IndicatorLocations.Keys.ElementAt(i), (double)GetIndicator(this.IndicatorLocations.Keys.ElementAt(i)));
                            TDD.Add(GetStockPoint().PointDateTime, temp);
                        }
                        
                    }
                }
            }while(this.MoveNext());

            return TDD;
        }
    }
}
