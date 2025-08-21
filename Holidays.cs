using System;

namespace src
{
    public class Holidays
    {
        private int[] holidays;

        public Holidays()
        {
            holidays = [1, 11, 15, 25];
        }

        public int[] GetHolidays()
        {
            return holidays;
        }
    }
}