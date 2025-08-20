using System;

namespace src
{
    public class DiaPagamento
    {
        public List<Cliente> ClientesAPagar(Cliente[] clientes)
        {
            int dia = DiaDeVencimentoAPagar().Day;
            List<Cliente> lista = new List<Cliente>();
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
                int ano = DateTime.Now.Year;
                int diaAtual = DateTime.Now.Day;
                if (dia > diaAtual)
                {
                    mes -= 1;
                    if (mes == 0)
                    {
                        mes = 12;
                        ano -= 1;
                    }
                }
                if (dia > DateTime.DaysInMonth(ano, mes))
                {
                    continue;
                }

                DateTime diaVencimento = new(ano, mes, Math.Min(dia, DateTime.DaysInMonth(ano, mes)));
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
            int[] diasFeriados = new Feriados().GetFeriados();
            return dia.DayOfWeek != DayOfWeek.Sunday &&
                   dia.DayOfWeek != DayOfWeek.Saturday &&
                   !diasFeriados.Contains(dia.Day);
        }
    }
}