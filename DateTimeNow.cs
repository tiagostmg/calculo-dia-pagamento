using System;

namespace src
{
    public class DateTimeNow
    {
        private DateTime dateTime;

        public DateTimeNow(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }
    }
}