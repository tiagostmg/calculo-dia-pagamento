using System;

namespace src
{
    public class DiaPagamento
    {
        public List<Cliente> ClientesAPagar(Cliente[] clientes)
        {
            int dia = DiaDeVencimentoAPagar().Day;
            List<Cliente> lista = [];
            foreach (Cliente c in clientes)
            {
                if (c.DiaPagamento == dia)
                {
                    lista.Add(c);
                }
            }
            return lista;
        }
        public DateTime DiaDeVencimentoAPagar()
        {
            int[] dias = [5, 10, 15, 20, 25, 30];
            foreach (int dia in dias)
            {
                int mes = DateTime.Now.Month;
                int diaAtual = DateTime.Now.Day;
                if (dia > diaAtual)
                {
                    mes -= 1;
                }
                DateTime diaVencimento = new(DateTime.Now.Year, mes, Math.Min(dia, DateTime.DaysInMonth(DateTime.Now.Year, mes)));
                if (SomarDiasUteis(diaVencimento, 3).Date == DateTime.Now.Date)
                {
                    return diaVencimento.Date;
                }
            }
            return new DateTime();
        }
        public DateTime SomarDiasUteis(DateTime data, int diasUteis)
        {
            int adicionados = 0;
            while (adicionados < diasUteis)
            {
                data = data.AddDays(1);
                if (IsDiaUtil(data))
                {
                    adicionados++;
                }
            }
            return data;
        }
        public bool IsDiaUtil(DateTime dia)
        {
            int[] diasFeriados = [1, 12, 25]; // Exemplo de feriados

            return dia.DayOfWeek != DayOfWeek.Sunday &&
                   dia.DayOfWeek != DayOfWeek.Saturday &&
                   !diasFeriados.Contains(dia.Day);
        }
    }
}