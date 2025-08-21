using System;

namespace src
{
    public class PaymentDay
    {
        public List<Client> ClientsToPay(Client[] clients)
        {
            int day = DueDateToPay().Day;
            List<Client> list = new List<Client>();
            foreach (Client c in clients)
            {
                if (c.PaymentDay == day)
                {
                    list.Add(c);
                }
            }
            return list;
        }
        public DateTime DueDateToPay()
        {
            int[] dueDays = { 5, 10, 15, 20, 25, 30 };
            foreach (int currDay in dueDays)
            {
                DateTimeNow dateTimeNow = new(DateTime.Now);
                DateTime now = dateTimeNow.GetDateTime();

                int month = now.Month;
                int year = now.Year;
                int currentDay = now.Day;
                if (currDay > currentDay)
                {
                    month -= 1;
                    if (month == 0)
                    {
                        month = 12;
                        year -= 1;
                    }
                }
                if (currDay > DateTime.DaysInMonth(year, month))
                {
                    continue;
                }

                DateTime dueDate = new(year, month, Math.Min(currDay, DateTime.DaysInMonth(year, month)));
                if (AddBusinessDays(dueDate, 3).Date == DateTime.Now.Date)
                {
                    return dueDate.Date;
                }
            }
            return new DateTime();
        }
        public DateTime AddBusinessDays(DateTime date, int businessDaysToAdd)
        {
            int countedBusinessDays = 0;
            while (countedBusinessDays < businessDaysToAdd)
            {
                date = date.AddDays(1);
                if (IsBusinessDay(date))
                {
                    countedBusinessDays++;
                }
            }
            return date;
        }
        public bool IsBusinessDay(DateTime day)
        {
            int[] holidays = new Holidays().GetHolidays();
            return day.DayOfWeek != DayOfWeek.Sunday &&
                   day.DayOfWeek != DayOfWeek.Saturday &&
                   !holidays.Contains(day.Day);
        }
    }
}