namespace src
{
    public class Program
    {
        public static void Main()
        {
            PaymentDay paymentDay = new();
            Client[] clientes = [
                new Client(
                    "tiago", 5
                )
            ];
            var c = paymentDay.ClientsToPay(clientes);
            PrintClientes(c);

            // int mes = DateTime.Now.Month;
            // int ano = DateTime.Now.Year;
            // DateTime dia9 = new(ano, mes, 9);
            // DateTime a = diaPagamento.SomarDiasUteis(dia9, 7);
            // Console.WriteLine(a);
        }

        public static void PrintClientes(List<Client> list)
        {
            foreach (Client c in list)
            {
                Console.WriteLine(c.Name + ": " + c.PaymentDay);
            }
        }
    }
}