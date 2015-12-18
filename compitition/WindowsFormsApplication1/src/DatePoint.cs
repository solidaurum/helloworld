///
///Copyright 2015 by Ammon Pickett
///Licensed under the MIT License
///

namespace WindowsFormsApplication1.src
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Contains the OHLCV data for a specific stock points in time.
    /// </summary>
    public class DatePoint : IEquatable<DatePoint>
    {
        /// <summary>
        /// Cached value for ValidationErrors
        /// </summary>
        private List<string> validationErrors = null;

        /// <summary>
        /// Initializes a new instance of the StockPoint class.
        /// </summary>
        public DatePoint()
        {
            /// *********************************************
            /// GDBCup - Code may be needed here
            /// *********************************************
        }

        /// <summary>
        /// Initializes a new instance of the StockPoint class with the given values.
        /// </summary>
        /// <param name="time">The ending time for the point's period</param>
        /// <param name="date">The date of the point</param>
        public DatePoint(string timeDate)
        {
            this.PointDateTime = this.ParseDateTime(timeDate);
        }

        /// <summary>
        /// Gets the date and time of the stock point
        /// </summary>
        public DateTime PointDateTime { get; private set; }

        /// <summary>
        /// Gets the date string passed in
        /// </summary>
        public string Date { get; private set; }

        /// <summary>
        /// Gets the time string passed in
        /// </summary>
        public string Time { get; private set; }
        
        /// <summary>
        /// ToString override.
        /// </summary>
        /// <returns>Comma seperated list of Date, Time, and OHLCV values</returns>
        public override string ToString()
        {
            return this.Date + ", " + this.Time;
        }

        /// <summary>
        /// Converts a string date and string time to a datetime object. 
        /// </summary>
        /// <param name="dateString">The date as a string.</param>
        /// <param name="timeString">The time as a string.</param>
        /// <returns>
        /// DateTime object with the given date and time.
        /// Returns the minimum date if the dateString is invalid.
        /// </returns>
        private DateTime ParseDateTime(string dateString, string timeString)
        {
            int closingYear, closingMonth, closingDay, closingHour, closingMin;
            if (dateString.Length == 8)
            {
                closingYear = Int32.Parse(dateString.Substring(0, 4));
                closingMonth = Int32.Parse(dateString.Substring(4, 2));
                closingDay = Int32.Parse(dateString.Substring(6, 2));
            }
            else
            {
                closingYear = 0;
                closingMonth = 0;
                closingDay = 0;
            }

            string[] temp = timeString.Split(':');
            if (temp.Length == 2)
            {
                closingHour = Int32.Parse(temp[0]);
                closingMin = Int32.Parse(temp[1]);
            }
            else
            {
                closingHour = 0;
                closingMin = 0;
            }

            if (closingYear != 0)
            {
                return new DateTime(closingYear, closingMonth, closingDay, closingHour, closingMin, 0);
            }

            return DateTime.MinValue;
        }
        public DateTime ParseDateTime(string date)
        {
            String justDate;
            String justTime;
            justDate = date.Split(' ')[0];
            justTime = date.Split(' ')[1];
            int dPointYear;
            int dPointMonth;
            int dPointDay;
            int dPointHour;
            int dPointMinute;
            int dPointSecond;
            if (date.Length != null)
            {
                dPointMonth = Int32.Parse(justDate.Split('/')[0]);
                dPointDay = Int32.Parse(justDate.Split('/')[1]);
                dPointYear = Int32.Parse(justDate.Split('/')[2]);
                dPointHour = Int32.Parse(justTime.Split(':')[0]);
                dPointMinute = Int32.Parse(justTime.Split(':')[1]);
                dPointSecond = Int32.Parse(justTime.Split(':')[2]);


            }
            else
            {
                dPointMonth = 0;
                dPointDay = 0;
                dPointYear = 0;
                dPointHour = 0;
                dPointMinute = 0;
                dPointSecond = 0;

            }



            if (dPointYear != 0)
            {
                return new DateTime(dPointYear, dPointMonth, dPointDay, dPointHour,
                    dPointMinute, dPointSecond);
            }
            return DateTime.MinValue;
        }

        public bool Equals(DatePoint obj)
        {
            return Equals(obj as DatePoint);
        }
    }
}
