using System;

namespace src
{
    public class PaymentDay
    {
        public List<Client> ClientsToPay(Client[] clients)
        {
            int day = DueDateToPay();
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
        public int DueDateToPay()
        {
            int[] dueDays = [5, 10, 15, 20, 25, 30];
            DateTimeNow dateTimeNow = new(DateTime.Now);
            DateTime now = dateTimeNow.GetDateTime();

            int currentMonth = now.Month;
            int currentYear = now.Year;
            int today = now.Day;

            foreach (int dueDay in dueDays)
            {
                if (dueDay > today)
                {
                    currentMonth -= 1;
                    if (currentMonth == 0)
                    {
                        currentMonth = 12;
                        currentYear -= 1;
                    }
                }
                int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
                int effectiveDay = Math.Min(dueDay, daysInMonth);

                DateTime dueDate = new(currentYear, currentMonth, effectiveDay);

                if (AddBusinessDays(dueDate, 3).Date == now.Date)
                {
                    return dueDay;
                }
            }

            return 0;
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