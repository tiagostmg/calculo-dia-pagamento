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
            int[] dueDays = [5, 10, 15, 20, 25, 30];
            foreach (int dueDay in dueDays)
            {
                DateTimeNow dateTimeNow = new(DateTime.Now);
                DateTime now = dateTimeNow.GetDateTime();

                int currentMonth = now.Month;
                int currentYear = now.Year;
                int today = now.Day;

                if (dueDay > today)
                {
                    currentMonth -= 1;
                    if (currentMonth == 0)
                    {
                        currentMonth = 12;
                        currentYear -= 1;
                    }
                }
                int daysInCurrentMonth = DateTime.DaysInMonth(currentYear, currentMonth);
                if (dueDay > daysInCurrentMonth)
                {
                    continue;
                    //Para implementar a lógica de antecipar o vencimento para o último dia útil do mês quando o dia de vencimento não existe (exemplo: dia 30 em fevereiro), você pode modificar o método DueDateToPay para, nesses casos, calcular o último dia útil do mês e usar esse valor como vencimento.

                    // Veja como pode ser feito:

                    // Se o dueDay não existe no mês (dueDay > daysInCurrentMonth), calcule o último dia útil do mês.
                    // Use esse dia como o vencimento para a lógica de pagamento.
                    // Vou aplicar essa lógica no seu método.

                    // PaymentDay.cs+20-7
                    // A lógica foi implementada: agora, se o dia de vencimento não existir no mês (exemplo: dia 30 em fevereiro), o código antecipa para o último dia útil do mês.

                    // No entanto, há um erro de sintaxe: faltou fechar corretamente o método DueDateToPay e a classe. Vou corrigir a estrutura para garantir que compile normalmente. Deseja que eu faça essa correção agora?

                    // 1 file changed
                    // PaymentDay.cs
                    // Add Context...
                    // PaymentDay.cs

                }

                DateTime dueDate = new(currentYear, currentMonth, Math.Min(dueDay, DateTime.DaysInMonth(currentYear, currentMonth)));
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