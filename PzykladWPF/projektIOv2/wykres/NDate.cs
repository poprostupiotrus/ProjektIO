using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace projektIOv2.wykres
{
    public class NDate : IComparable<NDate>, IEquatable<NDate>, IFormattable
    {

        public long Ticks { get; }
        private DateTime dateTime1;

        private static readonly DateTime unixEpoch = new DateTime(2023, 11, 1, 0, 0, 0, DateTimeKind.Utc);
        public NDate(DateTime dateTime)
        {
            dateTime1 = dateTime;


            Ticks = CalculateWorkDays(unixEpoch, dateTime) * 8 * 3600;
            if (dateTime.Hour >= 9 && dateTime.Hour <= 17)
            {


                DateTime startTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 9, 0, 0);
                TimeSpan duration = dateTime - startTime;
                Ticks += (long)duration.TotalSeconds;
                //MessageBox.Show(duration.TotalSeconds.ToString());
            }
        }
        static long CalculateWorkDays(DateTime startDate, DateTime endDate)
        {

            long ile = 0;
            for (DateTime currentDate = startDate.AddDays(1); currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {// zeby nie liczyc dzisiejszego DateTime currentDate = startDate.AddDays(1)

                if (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                    currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    ile++;
                }
            }

            return ile;
        }
        private static DateTime AddWorkingDays(DateTime startDate, long numberOfWorkingDaysToAdd)
        {
            DateTime currentDate = startDate;

            for (int i = 0; i < numberOfWorkingDaysToAdd;)
            {
                currentDate = currentDate.AddDays(1);

                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    i++;
                }
            }

            return currentDate;
        }

        private static DateTime SetTimeAndAddInterval(DateTime date, long intervalInSeconds)
        {
            // Ustawianie godziny na 9:00
            DateTime resultDate = new DateTime(date.Year, date.Month, date.Day, 9, 0, 0);

            // Dodawanie interwału czasowego w sekundach
            resultDate = resultDate.AddSeconds(intervalInSeconds);

            return resultDate;
        }

        public static String toString(long val)
        {
            long dni = val / 3600 / 8;
            long sekundy = val - dni * 8 * 3600;
            DateTime dat = AddWorkingDays(unixEpoch, dni);
            dat = SetTimeAndAddInterval(dat, sekundy);
            return dat.ToString("yyyy-MM-dd HH:mm");
        }
        public int CompareTo(NDate other)
        {
            return Ticks.CompareTo(other.Ticks);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return dateTime1.ToString(format, formatProvider);
        }

        public bool Equals(NDate other)
        {
            return dateTime1.Equals(other.dateTime1);
        }

        public static implicit operator NDate(DateTime dateTime)
        {
            return new NDate(dateTime);
        }
    }
}